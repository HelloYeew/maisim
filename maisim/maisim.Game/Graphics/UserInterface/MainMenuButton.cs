using maisim.Game.Graphics.Sprites;
using osu.Framework.Allocation;
using osu.Framework.Audio.Sample;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Audio;
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
        private DrawableSample drawableHoverSample;
        private DrawableSample drawableClickSample;
        private readonly string buttonText;
        private readonly IconUsage buttonIcon;
        private readonly Color4 buttonColor;

        public MainMenuButton(string buttonText, IconUsage buttonIcon, Color4 buttonColor)
        {
            this.buttonText = buttonText;
            this.buttonIcon = buttonIcon;
            this.buttonColor = buttonColor;
        }

        [BackgroundDependencyLoader]
        private void load(ISampleStore sampleStore)
        {
            InternalChild = new Container
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Size = new Vector2(500, 70),
                Masking = true,
                CornerRadius = 35,
                BorderThickness = 5,
                BorderColour = Color4.White,
                Children = new Drawable[]
                {
                    new Box
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
                                            Size = new Vector2(40),
                                            Colour = Color4Extensions.FromHex("ffffff")
                                        }
                                    }
                                },new Container
                                {
                                    Anchor = Anchor.CentreLeft,
                                    Origin = Anchor.CentreLeft,
                                    Size = new Vector2(400, 70),
                                    Child = new MaisimSpriteText()
                                    {
                                        Anchor = Anchor.CentreLeft,
                                        Origin = Anchor.CentreLeft,
                                        Text = buttonText,
                                        Font = MaisimFont.GetFont(size: 40f)
                                    }
                                }
                            }
                        }
                    }
                }
            };

            drawableHoverSample = new DrawableSample(sampleStore.Get("hover.wav"));
            drawableClickSample = new DrawableSample(sampleStore.Get("click.wav"));
        }

        protected override bool OnHover(HoverEvent e)
        {
            drawableHoverSample.Play();
            return base.OnHover(e);
        }

        protected override bool OnClick(ClickEvent e)
        {
            drawableClickSample.Play();
            return base.OnClick(e);
        }
    }
}
