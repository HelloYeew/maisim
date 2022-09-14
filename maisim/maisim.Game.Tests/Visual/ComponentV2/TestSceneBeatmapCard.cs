using System.Reflection;
using maisim.Game.Beatmaps;
using maisim.Game.Graphics.UserInterfaceV2;
using maisim.Game.Utils;
using NUnit.Framework;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;

namespace maisim.Game.Tests.Visual.ComponentV2;

public class TestSceneBeatmapCard : maisimTestScene
{
    private Bindable<DifficultyLevel> difficultyLevel = new Bindable<DifficultyLevel>();

    private Bindable<BeatmapSet> beatmapSet =  new Bindable<BeatmapSet>(new BeatmapSetTestFixture().BeatmapSet);

    private string beatmapList;
    private TextFlowContainer beatmapListContainer;

    public TestSceneBeatmapCard()
    {
        Children = new Drawable[]
        {
            new BeatmapSetInfoBox(difficultyLevel, beatmapSet)
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
        difficultyLevel.BindValueChanged(_ => updateBeatmapInfo(), true);
        beatmapSet.BindValueChanged(_ => updateBeatmapInfo(), true);
        updateBeatmapInfo();
    }

    [SetUp]
    public void SetUp()
    {
        AddStep("Set difficulty level to basic", () => difficultyLevel.Value = DifficultyLevel.Basic);
        AddStep("Set difficulty level to advanced", () => difficultyLevel.Value = DifficultyLevel.Advanced);
        AddStep("Set difficulty level to expert", () => difficultyLevel.Value = DifficultyLevel.Expert);
        AddStep("Set difficulty level to master", () => difficultyLevel.Value = DifficultyLevel.Master);
        AddStep("Get a new beatmap set", () => beatmapSet.Value = new BeatmapSetTestFixture().BeatmapSet);
    }

    private void updateBeatmapInfo()
    {
        beatmapList = "";
        beatmapList += "difficultyLevel : " + difficultyLevel.Value + "\n";
        beatmapList += $"beatmapSet : ({beatmapSet.Value.BeatmapSetID}) {beatmapSet.Value.TrackMetadata.Title} - {beatmapSet.Value.TrackMetadata.Artist}\n";
        beatmapList += "info : " + "\n";
        foreach (PropertyInfo property in beatmapSet.Value.GetType().GetProperties())
        {
            beatmapList += property.Name + " - " + property.GetValue(beatmapSet.Value) + "\n";
        }
        beatmapList += "list : \n";
        foreach (var beatmap in beatmapSet.Value.Beatmaps)
        {
            beatmapList += $"{beatmap.BeatmapID} - {beatmap.DifficultyRating} stars ({beatmap.DifficultyLevel}) by {beatmap.NoteDesigner}\n";
        }
        beatmapListContainer.Text = beatmapList;
    }
}
