using osu.Framework.Allocation;
using osu.Framework.Audio;
using osu.Framework.Audio.Sample;
using osu.Framework.Graphics;
using osu.Framework.Input.Events;

namespace maisim.Game.Graphics.UserInterface
{
    public partial class ClickHoverSounds : Drawable
    {
        private Sample hoverSample;

        private Sample clickSample;

        public ClickHoverSounds()
        {
            RelativeSizeAxes = Axes.Both;
        }

        [BackgroundDependencyLoader]
        private void load(AudioManager audioManager)
        {
            hoverSample = audioManager.Samples.Get("hover.wav");
            clickSample = audioManager.Samples.Get("click.wav");
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
