using maisim.Game.Component.Gameplay.Notes;
using maisim.Game.Screen;
using maisim.Game.Screen.Gameplay;
using maisim.Game.Utils;
using NUnit.Framework;
using osu.Framework.Graphics;
using osu.Framework.Screens;
using osuTK;

namespace maisim.Game.Tests.Visual.Screen;

public class TestScenePlayfieldScreen : maisimTestScene
{
    private PlayfieldScreen playfieldScreen;

    private RandomFloat randomFloat = new(-300, 300);

    [SetUp]
    public void SetUp()
    {
        Add(playfieldScreen = new PlayfieldScreen() {RelativeSizeAxes = Axes.Both});

        AddStep("spawn note", () => playfieldScreen.Playfield.spawnNote(new DrawableTouchNote
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            Position = new Vector2(randomFloat.GetRandom(), randomFloat.GetRandom()),
            Scale = new Vector2(1.5f)
        }));
    }
}
