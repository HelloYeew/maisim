using maisim.Game.Graphics.UserInterface.Toolbar;
using maisim.Game.Screen;

namespace maisim.Game.Tests.Visual.Component;

public partial class TestSceneToolbar : maisimTestScene
{
    public TestSceneToolbar()
    {
        Add(new BackgroundScreenStack());
        Add(new Toolbar());
    }
}
