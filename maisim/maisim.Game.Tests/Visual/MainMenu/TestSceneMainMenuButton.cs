using maisim.Game.Component;
using NUnit.Framework;
using osu.Framework.Graphics;
using osu.Framework.Screens;

namespace maisim.Game.Tests.Visual.MainMenu
{
    public class TestSceneMainMenuButton : maisimTestScene
    {
        [SetUp]
        public void SetUp()
        {
            Add(new ScreenStack(new MainMenuScreen()) {RelativeSizeAxes = Axes.Both});
        }
    }
}
