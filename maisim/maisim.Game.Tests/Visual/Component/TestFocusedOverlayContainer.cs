using maisim.Game.Component;
using osu.Framework.Graphics.Containers;

namespace maisim.Game.Tests.Visual.Component
{
    public class TestFocusedOverlayContainer : maisimTestScene
    {
        private MaisimFocusedOverlayContainer testContainer;

        public TestFocusedOverlayContainer()
        {
            AddStep("add new container", () => { testContainer = new MaisimFocusedOverlayContainer(); });
            AddStep("show container", () => { testContainer.Show(); });
        }
    }
}
