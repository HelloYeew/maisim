using System.Reflection;
using maisim.Game.Beatmaps;
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

    private string beatmapList;
    private TextFlowContainer beatmapListContainer;

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
            new BeatmapSetInfoBox()
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
        currentWorkingBeatmap.BeatmapSet = new BeatmapSetTestFixture().BeatmapSet;
        currentWorkingBeatmap.BindValueChanged(_ => updateBeatmapInfo(), true);
        updateBeatmapInfo();
    }

    [SetUp]
    public void SetUp()
    {
        AddStep("Set difficulty level to basic", () => currentWorkingBeatmap.DifficultyLevel = DifficultyLevel.Basic);
        AddStep("Set difficulty level to advanced", () => currentWorkingBeatmap.DifficultyLevel = DifficultyLevel.Advanced);
        AddStep("Set difficulty level to expert", () => currentWorkingBeatmap.DifficultyLevel = DifficultyLevel.Expert);
        AddStep("Set difficulty level to master", () => currentWorkingBeatmap.DifficultyLevel = DifficultyLevel.Master);
        AddStep("Get a new beatmap set", () => currentWorkingBeatmap.BeatmapSet = new BeatmapSetTestFixture().BeatmapSet);
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
