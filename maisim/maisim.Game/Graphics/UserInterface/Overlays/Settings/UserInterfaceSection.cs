using maisim.Game.Graphics.UserInterface.Overlays.Settings.UserInterface;
using osu.Framework.Graphics;
using osu.Framework.Localisation;

namespace maisim.Game.Graphics.UserInterface.Overlays
{
    public class UserInterfaceSection : SettingsSection
    {
        public override bool EnableSeperator => true;
        public override LocalisableString Header => "user interface";

        public UserInterfaceSection()
        {
            Children = new Drawable[]
            {
                new GeneralSection()
            };
        }
    }
}
