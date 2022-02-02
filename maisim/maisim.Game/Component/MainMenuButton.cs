using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osuTK;
using osuTK.Graphics;

namespace maisim.Game.Component
{
    public class MainMenuButton : CompositeDrawable
    {
        [BackgroundDependencyLoader]
        private void load()
        {
            InternalChild = new Container
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Size = new Vector2(250, 250),
                Children = new Drawable[]
                {
                    new Circle
                    {
                        RelativeSizeAxes = Axes.Both,
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Colour = Color4.White,
                    },
                    new GridContainer
                    {
                        RelativeSizeAxes = Axes.Both,
                        Content = new[]
                        {
                            new Drawable[]
                            {
                                new SpriteText()
                                {
                                    Text = "Play",
                                    Font = new FontUsage(size: 30),
                                    Anchor = Anchor.Centre,
                                    Origin = Anchor.Centre,
                                    Colour = Color4.Black
                                },
                                new SpriteIcon
                                {
                                    Anchor = Anchor.Centre,
                                    Origin = Anchor.Centre,
                                    Icon = FontAwesome.Solid.Play,
                                    Size = new Vector2(100,100),
                                    Colour = Colour4.Black
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}
