using maisim.Game.Graphics.Sprites;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Input.Events;
using osuTK;
using osuTK.Graphics;

namespace maisim.Game.Graphics.UserInterface
{
    /// <summary>
    /// A button used on the main menu screen.
    /// </summary>
    public class MainMenuButton : Button
    {
        private readonly Color4 buttonColor;
        private readonly Box buttonBox;

        public MainMenuButton(string buttonText, IconUsage buttonIcon, Color4 buttonColor)
        {
            this.buttonColor = buttonColor;

            InternalChild = new Container
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Size = new Vector2(400, 60),
                Masking = true,
                CornerRadius = 30,
                BorderThickness = 5,
                BorderColour = Color4.White,
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
                                            Icon = buttonIcon,
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
                                        Text = buttonText,
                                        Font = MaisimFont.GetFont(size: 35f)
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
            buttonBox.Colour = buttonColor.Darken(0.5f);
            return base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseUpEvent e)
        {
            buttonBox.Colour = buttonColor;
            base.OnMouseUp(e);
        }
    }
}
