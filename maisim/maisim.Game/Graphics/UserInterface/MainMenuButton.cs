using maisim.Game.Graphics;
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

namespace maisim.Game.Component
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

        public MainMenuButton(string buttonText, IconUsage buttonIcon)
        {
            this.buttonText = buttonText;
            this.buttonIcon = buttonIcon;
        }

        [BackgroundDependencyLoader]
        private void load(ISampleStore sampleStore)
        {
            InternalChild = new Container
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Size = new Vector2(540, 80),
                CornerRadius = 5,
                Children = new Drawable[]
                {
                    new Box
                    {
                        RelativeSizeAxes = Axes.Both,
                        Anchor = Anchor.CentreRight,
                        Origin = Anchor.CentreRight,
                        Colour = Color4Extensions.FromHex("73bfe9")
                    },
                    new GridContainer
                    {
                        RelativeSizeAxes = Axes.Both,
                        ColumnDimensions = new[]
                        {
                            new Dimension(GridSizeMode.Absolute, 100),
                            new Dimension(GridSizeMode.Absolute, 175)
                        },
                        Content = new[]
                        {
                            new Drawable[]
                            {
                                new SpriteIcon
                                {
                                    Anchor = Anchor.Centre,
                                    Origin = Anchor.CentreLeft,
                                    Icon = buttonIcon,
                                    Size = new Vector2(50),
                                    Colour = Colour4.White
                                },new MaisimSpriteText
                                {
                                    Text = buttonText,
                                    Font = MaisimFont.GetFont(size: 40f),
                                    Anchor = Anchor.CentreLeft,
                                    Origin = Anchor.CentreLeft,
                                    Colour = Color4.White
                                },
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
