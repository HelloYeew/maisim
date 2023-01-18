using maisim.Game.Screen;
using NUnit.Framework;
using osu.Framework.Graphics;
using osu.Framework.Screens;

namespace maisim.Game.Tests.Visual.Screen
{
    public partial class TestSceneBackgroundScreen : maisimTestScene
    {
        [SetUp]
        public void SetUp()
        {
            Add(new ScreenStack(new BackgroundScreen()) {RelativeSizeAxes = Axes.Both});
        }
    }
}
