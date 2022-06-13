using maisim.Game.Graphics.UserInterface.Toolbar;

namespace maisim.Game.Tests.Visual.Screen;

public class TestSceneToolbar : maisimTestScene
{
    private osu.Framework.Screens.Screen toolbarScreen;

    public TestSceneToolbar()
    {
        Add(new Toolbar());
    }
}
