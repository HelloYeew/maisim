using maisim.Game.Graphics.UserInterface.Overlays.Settings.Graphics;
using osu.Framework.Graphics;
using osu.Framework.Localisation;

namespace maisim.Game.Graphics.UserInterface.Overlays
{
    public class GraphicsSection : SettingsSection
    {
        public override bool EnableSeperator => true;
        public override LocalisableString Header => "graphics";

        public GraphicsSection()
        {
            Children = new Drawable[]
            {
                new RendererSettings()
            };
        }
    }
}
