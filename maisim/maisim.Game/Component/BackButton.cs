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

namespace maisim.Game.Component
{
    public class BackButton : Button
    {

        private DrawableSample drawableHoverSample;
        private DrawableSample drawableClickSample;

        [BackgroundDependencyLoader]
        private void load(ISampleStore sampleStore)
        {
            InternalChildren = new Drawable[]
            {
                new Circle
                {
                    RelativeSizeAxes = Axes.Both,
                    Anchor = Anchor.BottomLeft,
                    Origin = Anchor.Centre,
                    Size = new Vector2(1),
                    Colour = Color4Extensions.FromHex("205ac8"),
                },new Container
                {
                    RelativeSizeAxes = Axes.Both,
                    Anchor = Anchor.BottomLeft,
                    Origin = Anchor.Centre,
                    Size = new Vector2(.4f),
                    Child = new MaisimSpriteText
                    {
                        Text = "Back",
                        Anchor = Anchor.TopRight,
                        Origin = Anchor.Centre,
                        Font = MaisimFont.GetFont(size: 50f)
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
