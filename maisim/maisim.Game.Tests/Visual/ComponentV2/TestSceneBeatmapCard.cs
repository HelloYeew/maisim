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
    private static BeatmapSet mockBeatmapSet = new BeatmapSetTestFixture().BeatmapSet;

    private Bindable<DifficultyLevel> difficultyLevel = new Bindable<DifficultyLevel>();

    private Bindable<BeatmapSet> beatmapSet =  new Bindable<BeatmapSet>(mockBeatmapSet);

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
        updateBeatmapInfo();
    }

    [SetUp]
    public void SetUp()
    {
        AddStep("Set difficulty level to basic", () =>
        {
            difficultyLevel.Value = DifficultyLevel.Basic;
            updateBeatmapInfo();
        });
        AddStep("Set difficulty level to advanced", () =>
        {
            difficultyLevel.Value = DifficultyLevel.Advanced;
            updateBeatmapInfo();
        });
        AddStep("Set difficulty level to expert", () =>
        {
            difficultyLevel.Value = DifficultyLevel.Expert;
            updateBeatmapInfo();
        });
        AddStep("Set difficulty level to master", () =>
        {
            difficultyLevel.Value = DifficultyLevel.Master;
            updateBeatmapInfo();
        });
        AddStep("Get a new beatmap set", () =>
        {
            beatmapSet.Value = new BeatmapSetTestFixture().BeatmapSet;
            updateBeatmapInfo();
        });
    }

    private void updateBeatmapInfo()
    {
        beatmapList = "";
        beatmapList += "difficultyLevel : " + difficultyLevel.Value + "\n";
        beatmapList += "beatmapSet : " + beatmapSet.Value + "\n";
        beatmapList += "info : " + "\n";
        foreach (PropertyInfo property in beatmapSet.Value.GetType().GetProperties())
        {
            beatmapList += property.Name + " - " + property.GetValue(beatmapSet.Value) + "\n";
        }
        beatmapList += "list : \n";
        foreach (var beatmap in beatmapSet.Value.Beatmaps)
        {
            beatmapList += beatmap + "\n";
        }
        beatmapListContainer.Text = beatmapList;
    }
}
