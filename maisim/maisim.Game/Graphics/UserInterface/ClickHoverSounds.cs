using osu.Framework.Allocation;
using osu.Framework.Audio.Sample;
using osu.Framework.Graphics;
using osu.Framework.Input.Events;

namespace maisim.Game.Graphics.UserInterface
{
    public class ClickHoverSounds : Drawable
    {
        private Sample hoverSample;

        private Sample clickSample;

        public ClickHoverSounds()
        {
            RelativeSizeAxes = Axes.Both;
        }

        [BackgroundDependencyLoader]
        private void load(ISampleStore sampleStore)
        {
            hoverSample = sampleStore.Get("hover.wav");
            clickSample = sampleStore.Get("click.wav");
        }

        protected override bool OnHover(HoverEvent e)
        {
            hoverSample?.Play();
            return base.OnHover(e);
        }

        protected override bool OnClick(ClickEvent e)
        {
            clickSample?.Play();
            return base.OnClick(e);
        }
    }
}
