using maisim.Game.Graphics;
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
    public class BackButton : Button
    {

        private DrawableSample drawableHoverSample;
        private DrawableSample drawableClickSample;
        private Circle button;
        private Container scaleContainer;

        [BackgroundDependencyLoader]
        private void load(ISampleStore sampleStore)
        {
            Anchor = Anchor.BottomLeft;
            Origin = Anchor.BottomLeft;
            Size = new Vector2(80);
            Position = new Vector2(20, -20);
            InternalChild = scaleContainer = new Container
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Size = new Vector2(80),
                Children = new Drawable[]
                {
                    button = new Circle
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        RelativeSizeAxes = Axes.Both,
                        Colour = MaisimColour.BackButtonColor,
                        BorderThickness = 10,
                        BorderColour = Color4.White,
                        Masking = true
                    },
                    new Container
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        RelativeSizeAxes = Axes.Both,
                        Child = new SpriteIcon
                        {
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            RelativeSizeAxes = Axes.Both,
                            Size = new Vector2(0.5f),
                            Icon = FontAwesome.Solid.ArrowLeft,
                            Colour = Color4.White
                        }
                    }
                }
            };

            drawableHoverSample = new DrawableSample(sampleStore.Get("hover.wav"));
            drawableClickSample = new DrawableSample(sampleStore.Get("click2.wav"));
        }

        protected override bool OnHover(HoverEvent e)
        {
            button.FadeColour(MaisimColour.BackButtonColor.Darken(0.25f), 100);
            drawableHoverSample.Play();
            return base.OnHover(e);
        }

        protected override void OnHoverLost(HoverLostEvent e)
        {
            button.Colour = MaisimColour.BackButtonColor;
            base.OnHoverLost(e);
        }

        protected override bool OnClick(ClickEvent e)
        {
            drawableClickSample.Play();
            return base.OnClick(e);
        }

        protected override bool OnMouseDown(MouseDownEvent e)
        {
            button.FadeColour(MaisimColour.BackButtonColor.Darken(0.5f), 100);
            scaleContainer.ScaleTo(0.9f, 100, Easing.OutQuint);
            return base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseUpEvent e)
        {
            button.FadeColour(MaisimColour.BackButtonColor, 100);
            scaleContainer.ScaleTo(1, 100, Easing.OutBack);
            base.OnMouseUp(e);
        }
    }
}

