using maisim.Game.Component;
using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
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
                        new FillFlowContainer
                        {
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            RelativeSizeAxes = Axes.X,
                            RelativePositionAxes = Axes.Y,
                            Children = new Drawable[]
                            {
                                new MainMenuButton("Play",FontAwesome.Solid.Play)
                                {
                                    Anchor = Anchor.Centre,
                                    Origin = Anchor.Centre,
                                    Size = new Vector2(300,300)
                                },new MainMenuButton("Edit",FontAwesome.Solid.Edit)
                                {
                                    Anchor = Anchor.Centre,
                                    Origin = Anchor.Centre,
                                    Size = new Vector2(300,300)
                                },new MainMenuButton("Browse",FontAwesome.Solid.ListUl)
                                {
                                    Anchor = Anchor.Centre,
                                    Origin = Anchor.Centre,
                                    Size = new Vector2(300,300)
                                },new MainMenuButton("Exit",FontAwesome.Solid.DoorOpen)
                                {
                                    Anchor = Anchor.Centre,
                                    Origin = Anchor.Centre,
                                    Size = new Vector2(300,300)
                                }
                            }
                        }
                    }
                }
            };
        }

        public override void OnEntering(IScreen last)
        {
            base.OnEntering(last);

            this.FadeInFromZero(500);
        }
    }
}
