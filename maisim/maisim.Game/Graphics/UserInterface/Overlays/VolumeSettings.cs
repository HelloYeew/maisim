using maisim.Game.Graphics.Sprites;
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
                new MaisimSpriteText
                {
                    Text = "Master"
                },
                new BasicSliderBar<double>
                {
                    Current = audio.Volume,
                    KeyboardStep = 0.01f,
                    Size = new Vector2(SettingsPanel.WIDTH - (SettingsPanel.CONTENT_MARGINS * 2), 20),
                },
                new MaisimSpriteText
                {
                    Text = "Effect"
                },
                new BasicSliderBar<double>
                {
                    Current = audio.VolumeSample,
                    KeyboardStep = 0.01f,
                    Size = new Vector2(SECTION_WIDTH, 20),
                },
                new MaisimSpriteText
                {
                    Text = "Track"
                },
                new BasicSliderBar<double>
                {
                    Current = audio.VolumeTrack,
                    KeyboardStep = 0.01f,
                    Size = new Vector2(SECTION_WIDTH, 20),
                }
            };
        }
    }
}
