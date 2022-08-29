using maisim.Game.Beatmaps;
using maisim.Game.Graphics.UserInterfaceV2;
using NUnit.Framework;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;

namespace maisim.Game.Tests.Visual.ComponentV2;

public class TestSceneBeatmapCard : maisimTestScene
{
    private Bindable<DifficultyLevel> difficultyLevel;

    public TestSceneBeatmapCard()
    {
        Children = new Drawable[]
        {
            new BeatmapSetInfoBox(difficultyLevel = new Bindable<DifficultyLevel>())
            {
                Anchor = Anchor.TopRight,
                Origin = Anchor.TopRight,
                RelativeSizeAxes = Axes.Y,
            },
            new SpriteText()
            {
                Anchor = Anchor.TopLeft,
                Origin = Anchor.TopLeft,
                Text = "difficultyLevel : " + difficultyLevel.Value
            }
        };
    }

    [SetUp]
    public void SetUp()
    {
        AddStep("Set difficulty level to basic", () => difficultyLevel.Value = DifficultyLevel.Basic);
        AddStep("Set difficulty level to advanced", () => difficultyLevel.Value = DifficultyLevel.Advanced);
        AddStep("Set difficulty level to expert", () => difficultyLevel.Value = DifficultyLevel.Expert);
        AddStep("Set difficulty level to master", () => difficultyLevel.Value = DifficultyLevel.Master);
    }
}
