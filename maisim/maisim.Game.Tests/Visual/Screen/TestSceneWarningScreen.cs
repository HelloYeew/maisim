using maisim.Game.Screen;
using NUnit.Framework;
using osu.Framework.Graphics;
using osu.Framework.Screens;

namespace maisim.Game.Tests.Visual.Screen
{
    public class TestSceneWarningScreen : maisimTestScene
    {
        [SetUp]
        public void SetUp()
        {
            Add(new ScreenStack(new WarningScreen(null))
            {
                RelativeSizeAxes = Axes.Both
            });
        }
    }
}
