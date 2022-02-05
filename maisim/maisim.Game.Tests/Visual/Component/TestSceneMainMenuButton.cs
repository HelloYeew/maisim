using maisim.Game.Component;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osuTK;
using osuTK.Graphics;

namespace maisim.Game.Tests.Visual.MainMenu
{
    public class TestSceneMainMenuButton : maisimTestScene
    {
        public TestSceneMainMenuButton()
        {
            Child = new Container
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Size = new Vector2(300),
                Masking = true,
                Children = new Drawable[]
                {
                    new Box
                    {
                        RelativeSizeAxes = Axes.Both,
                        Colour = Color4.DimGray
                    },
                    new MainMenuButton("Test", FontAwesome.Solid.Smile)
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Size = new Vector2(250)
                    }
                }
            };
        }
    }
}
