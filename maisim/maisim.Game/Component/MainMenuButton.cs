using osu.Framework.Allocation;
using osu.Framework.Audio.Sample;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Audio;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Input.Events;
using osuTK;
using osuTK.Graphics;

namespace maisim.Game.Component
{
    public class MainMenuButton : CompositeDrawable
    {
        private DrawableSample drawableHoverSample;
        private DrawableSample drawableClickSample;
        private readonly string buttonText;
        private readonly IconUsage buttonIcon;

        public MainMenuButton(string buttonText, IconUsage buttonIcon)
        {
            this.buttonText = buttonText;
            this.buttonIcon = buttonIcon;
        }

        [BackgroundDependencyLoader]
        private void load(ISampleStore sampleStore)
        {
            InternalChild = new CircularContainer
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
                        Colour = Color4Extensions.FromHex("73bfe9"),
                        BorderThickness = 10,
                        BorderColour = Color4.White,
                        Masking = true,
                    },
                    new GridContainer
                    {
                        RelativeSizeAxes = Axes.Both,
                        RowDimensions = new[]
                        {
                            new Dimension(GridSizeMode.Absolute, 175),
                            new Dimension(GridSizeMode.Absolute, 75),
                        },
                        Content = new[]
                        {
                            new Drawable[]
                            {
                                new SpriteIcon
                                {
                                    Anchor = Anchor.Centre,
                                    Origin = Anchor.Centre,
                                    Icon = buttonIcon,
                                    Size = new Vector2(80,80),
                                    Colour = Colour4.White
                                }
                            },new Drawable[]
                            {
                                new SpriteText
                                {
                                    Text = buttonText,
                                    Font = new FontUsage("Mplus1p",30),
                                    Anchor = Anchor.TopCentre,
                                    Origin = Anchor.TopCentre,
                                    Colour = Color4.White
                                }
                            }
                        }
                    }
                }
            };

            drawableHoverSample = new DrawableSample(sampleStore.Get("hover.wav"));
            drawableClickSample = new DrawableSample(sampleStore.Get("click2.wav"));
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
