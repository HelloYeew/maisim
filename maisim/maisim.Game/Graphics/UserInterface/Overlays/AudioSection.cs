using osu.Framework.Graphics;
using osu.Framework.Localisation;

namespace maisim.Game.Graphics.UserInterface.Overlays
{
    public class AudioSection : SettingsSection
    {
        public override bool EnableSeperator => true;
        public override LocalisableString Header => "audio";

        public AudioSection()
        {
            Children = new Drawable[]
            {
                new VolumeSettings()
            };
        }
    }
}
