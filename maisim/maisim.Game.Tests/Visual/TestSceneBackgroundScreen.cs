using osu.Framework.Graphics;
using osu.Framework.Screens;

namespace maisim.Game.Tests.Visual
{
    public class TestSceneBackgroundScreen : maisimTestScene
    {
        public TestSceneBackgroundScreen()
        {
            Add(new ScreenStack(new BackgroundScreen()) {RelativeSizeAxes = Axes.Both});
        }
    }
}
