using System.Reflection;
using maisim.Game.Beatmaps;
using maisim.Game.Configuration;
using maisim.Game.Graphics.UserInterface.Overlays;
using maisim.Game.Graphics.UserInterfaceV2;
using maisim.Game.Utils;
using NUnit.Framework;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;

namespace maisim.Game.Tests.Visual.ComponentV2;

public class TestSceneBeatmapCard : maisimTestScene
{
    [Cached]
    private WorkingBeatmapManager workingBeatmapManager = new WorkingBeatmapManager();

    [Cached]
    private CurrentWorkingBeatmap currentWorkingBeatmap = new CurrentWorkingBeatmap();

    [Resolved]
    private MaisimConfigManager configManager { get; set; }

    private string beatmapList;
    private TextFlowContainer beatmapListContainer;
    private BeatmapSetInfoBox beatmapSetInfoBox;

    [BackgroundDependencyLoader]
    private void load()
    {
        Dependencies.CacheAs(workingBeatmapManager);
        Dependencies.CacheAs(currentWorkingBeatmap);
    }

    public TestSceneBeatmapCard()
    {
        Children = new Drawable[]
        {
            beatmapSetInfoBox = new BeatmapSetInfoBox()
            {
                Anchor = Anchor.TopRight,
                Origin = Anchor.TopRight,
                RelativeSizeAxes = Axes.Y,
            },
            beatmapListContainer = new TextFlowContainer()
            {
                Anchor = Anchor.BottomCentre,
                Origin = Anchor.Centre,
                RelativeSizeAxes = Axes.Both,
                Text = ""
            }
        };
        currentWorkingBeatmap.SetCurrentBeatmapSet(new BeatmapSetTestFixture().BeatmapSet);
        currentWorkingBeatmap.BindBeatmapSetChanged(_ => updateBeatmapInfo(), true);
        updateBeatmapInfo();
    }

    [Test]
    public void DfficultyChangeTest()
    {
        AddStep("Set difficulty level to basic", () => currentWorkingBeatmap.SetCurrentDifficultyLevel(DifficultyLevel.Basic));
        AddStep("Set difficulty level to advanced", () => currentWorkingBeatmap.SetCurrentDifficultyLevel(DifficultyLevel.Advanced));
        AddStep("Set difficulty level to expert", () => currentWorkingBeatmap.SetCurrentDifficultyLevel(DifficultyLevel.Expert));
        AddStep("Set difficulty level to master", () => currentWorkingBeatmap.SetCurrentDifficultyLevel(DifficultyLevel.Master));
        AddStep("Get a new beatmap set", () => currentWorkingBeatmap.SetCurrentBeatmapSet(new BeatmapSetTestFixture().BeatmapSet));
    }

    [Test]
    public void UseUnicodeInfoSettingTest()
    {
        AddStep("Set use unicode info to true", () => configManager.SetValue(MaisimSetting.UseUnicodeInfo, true));
        AddAssert("TitleUnicode is used",
            () => beatmapSetInfoBox.BeatmapCard.GetTitleText() ==
                  currentWorkingBeatmap.BeatmapSet.TrackMetadata.TitleUnicode);
        AddAssert("ArtistUnicode is used",
            () => beatmapSetInfoBox.BeatmapCard.GetArtistText() ==
                  currentWorkingBeatmap.BeatmapSet.TrackMetadata.ArtistUnicode);
        AddStep("Set use unicode info to false", () => configManager.SetValue(MaisimSetting.UseUnicodeInfo, false));
        AddAssert("Title use original one",
            () => beatmapSetInfoBox.BeatmapCard.GetTitleText() ==
                  currentWorkingBeatmap.BeatmapSet.TrackMetadata.Title);
        AddAssert("Artist use original one",
            () => beatmapSetInfoBox.BeatmapCard.GetArtistText() ==
                  currentWorkingBeatmap.BeatmapSet.TrackMetadata.Artist);
    }

    private void updateBeatmapInfo()
    {
        beatmapList = "";
        beatmapList += "difficultyLevel : " + currentWorkingBeatmap.DifficultyLevel + "\n";
        beatmapList += $"beatmapSet : {BeatmapUtils.GetBeatmapSetString(currentWorkingBeatmap.BeatmapSet)}\n";
        beatmapList += "info : " + "\n";
        foreach (PropertyInfo property in currentWorkingBeatmap.BeatmapSet.GetType().GetProperties())
        {
            beatmapList += property.Name + " - " + property.GetValue(currentWorkingBeatmap.BeatmapSet) + "\n";
        }
        beatmapList += "list : \n";
        foreach (var beatmap in currentWorkingBeatmap.BeatmapSet.Beatmaps)
        {
            beatmapList += $"{BeatmapUtils.GetBeatmapString(beatmap)}\n";
        }
        beatmapListContainer.Text = beatmapList;
    }
}
