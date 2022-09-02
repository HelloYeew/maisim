using maisim.Game.Graphics.Gameplay;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osuTK;

namespace maisim.Game.Tests.Visual.Component.Gameplay
{
    public class TestSceneMaisimRing : maisimTestScene
    {
        public TestSceneMaisimRing()
        {
            Child = new Container
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Size = new Vector2(1),
                Children = new Drawable[]
                {
                    new MaisimRing
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Size = new Vector2(1),
                    }
                }
            };
        }
    }
}
