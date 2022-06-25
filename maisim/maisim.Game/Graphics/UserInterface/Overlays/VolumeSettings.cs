using osu.Framework.Allocation;
using osu.Framework.Audio;
using osu.Framework.Graphics;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Localisation;
using osuTK;

namespace maisim.Game.Graphics.UserInterface.Overlays
{
    public class VolumeSettings : SettingsSubsection
    {
        protected override LocalisableString Header => "volume";

        [BackgroundDependencyLoader]
        private void load(AudioManager audio)
        {
            Children = new Drawable[]
            {
                new BasicSliderBar<double>
                {
                    Current = audio.Volume,
                    KeyboardStep = 0.01f,
                    Size = new Vector2(SettingsPanel.WIDTH - 20, 20),
                }
            };
        }
    }
}
