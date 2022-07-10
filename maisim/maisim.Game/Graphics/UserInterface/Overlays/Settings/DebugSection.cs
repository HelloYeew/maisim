using maisim.Game.Graphics.UserInterface.Overlays.Settings.Debugs;
using osu.Framework.Graphics;
using osu.Framework.Localisation;

namespace maisim.Game.Graphics.UserInterface.Overlays
{
    public class DebugSection : SettingsSection
    {
        public override bool EnableSeperator => true;
        public override LocalisableString Header => "debug";

        public DebugSection()
        {
            Children = new Drawable[]
            {
                new FolderSettings()
            };
        }
    }
}
