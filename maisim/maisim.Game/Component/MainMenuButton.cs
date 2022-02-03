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
                        Colour = Color4Extensions.FromHex("ffe587")
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
                                    Text = buttonText,
                                    Font = new FontUsage(size: 30),
                                    Anchor = Anchor.Centre,
                                    Origin = Anchor.Centre,
                                    Colour = Color4.Black
                                },
                                new SpriteIcon
                                {
                                    Anchor = Anchor.Centre,
                                    Origin = Anchor.Centre,
                                    Icon = buttonIcon,
                                    Size = new Vector2(80,80),
                                    Colour = Colour4.Black
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
