using maisim.Game.Component;
using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Screens;
using osuTK;

namespace maisim.Game
{
    public class MainMenuScreen : Screen
    {
        [BackgroundDependencyLoader]
        private void load()
        {
            InternalChildren = new Drawable[]
            {
                new BackgroundComponent
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    FillMode = FillMode.Stretch,
                    RelativeSizeAxes = Axes.Both
                },
                new Container
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Size = new Vector2(400, 400),
                    RelativeSizeAxes = Axes.X,
                    Children = new Drawable[]
                    {
                        new Box
                        {
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            RelativeSizeAxes = Axes.X,
                            Size = new Vector2(300, 300),
                            Colour = Color4Extensions.FromHex("fbf2d7"),
                        },
                        new Container
                        {
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            RelativeSizeAxes = Axes.X,
                            Size = new Vector2(300, 300),
                            Children = new Drawable[]
                            {
                                new MainMenuButton
                                {
                                    Size = new Vector2(100, 100),
                                    Anchor = Anchor.Centre,
                                    Origin = Anchor.Centre,
                                    RelativePositionAxes = Axes.Both
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}
