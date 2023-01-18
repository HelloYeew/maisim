using osu.Framework.Graphics;
using maisim.Game.Graphics.UserInterface;

namespace maisim.Game.Tests.Visual;

public partial class TestSceneMaisimLogo : maisimTestScene
{
    public TestSceneMaisimLogo()
    {
        Child = new MaisimLogo
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
        };
    }
}
