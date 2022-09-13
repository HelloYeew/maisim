using maisim.Game.Graphics.UserInterface.Overlays;
using maisim.Game.Screen;
using NUnit.Framework;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osuTK;

namespace maisim.Game.Tests.Visual.Component;

public class TestSceneNowPlayingOverlay : maisimTestScene
{
    private NowPlayingOverlay nowPlayingOverlay { get; set; }

    [SetUp]
    public void SetUp()
    {
        Add(new BackgroundScreenStack());
        Add(nowPlayingOverlay = new NowPlayingOverlay()
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            Size = new Vector2(420,200)
        });
        AddStep("show overlay", () => nowPlayingOverlay.State.Value = Visibility.Visible);
        AddStep("hide overlay", () => nowPlayingOverlay.State.Value = Visibility.Hidden);
    }
}
