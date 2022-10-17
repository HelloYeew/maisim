using maisim.Game.Graphics.Sprites;
using maisim.Game.Graphics.UserInterface;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Input.Events;
using osu.Framework.Logging;
using osuTK;
using osuTK.Graphics;
using osuTK.Input;

namespace maisim.Game.Graphics.UserInterfaceV2
{
    /// <summary>
    /// A button used on the main menu screen.
    /// </summary>
    public class PlayButton : Button
    {
        // TODO: Bind color with diff color
        private readonly Color4 buttonColor = Color4.Aqua;
        private readonly Box buttonBox;

        public PlayButton()
        {
            InternalChild = new Container
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Size = new Vector2(300, 80),
                Masking = true,
                CornerRadius = 40,
                Children = new Drawable[]
                {
                    buttonBox = new Box
                    {
                        RelativeSizeAxes = Axes.Both,
                        Anchor = Anchor.CentreRight,
                        Origin = Anchor.CentreRight,
                        Colour = buttonColor
                    },
                    new GridContainer
                    {
                        RelativeSizeAxes = Axes.Both,
                        ColumnDimensions = new[]
                        {
                            new Dimension(GridSizeMode.Absolute, 100),
                            new Dimension(GridSizeMode.Absolute, 400)
                        },
                        Content = new[]
                        {
                            new Drawable[]
                            {
                                new Container
                                {
                                    Anchor = Anchor.CentreLeft,
                                    Origin = Anchor.CentreLeft,
                                    Size = new Vector2(100, 70),
                                    Children = new Drawable[]
                                    {
                                        new SpriteIcon
                                        {
                                            Anchor = Anchor.Centre,
                                            Origin = Anchor.Centre,
                                            Icon = FontAwesome.Solid.ArrowRight,
                                            Size = new Vector2(30),
                                            Colour = Color4Extensions.FromHex("ffffff")
                                        }
                                    }
                                },
                                new Container
                                {
                                    Anchor = Anchor.CentreLeft,
                                    Origin = Anchor.CentreLeft,
                                    Size = new Vector2(400, 70),
                                    Child = new MaisimSpriteText()
                                    {
                                        Anchor = Anchor.CentreLeft,
                                        Origin = Anchor.CentreLeft,
                                        Text = "let's go !",
                                        Font = MaisimFont.GetFont(size: 45f)
                                    }
                                }
                            }
                        }
                    },
                    new ClickHoverSounds()
                }
            };
        }

        protected override bool OnHover(HoverEvent e)
        {
            buttonBox.Colour = buttonColor.Darken(0.25f);
            return base.OnHover(e);
        }

        protected override void OnHoverLost(HoverLostEvent e)
        {
            buttonBox.Colour = buttonColor;
            base.OnHoverLost(e);
        }

        protected override bool OnMouseDown(MouseDownEvent e)
        {
            if (e.Button == MouseButton.Left)
            {
                buttonBox.FadeColour(Color4.Cyan.Darken(0.5f), 100);
                this.ScaleTo(0.9f, 500, Easing.OutElastic);
            }
            return base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseUpEvent e)
        {
            if (e.Button == MouseButton.Left)
            {
                buttonBox.FadeColour(Color4.Cyan, 100);
                this.ScaleTo(1, 500, Easing.OutElastic);
            }
            base.OnMouseUp(e);
        }
    }
}
