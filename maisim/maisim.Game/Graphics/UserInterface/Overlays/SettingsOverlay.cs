using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Localisation;
using osuTK.Graphics;

namespace maisim.Game.Graphics.UserInterface.Overlays
{
    public class SettingsOverlay : SettingsPanel, INamedOverlayComponent
    {
        public Drawable Icon => new SpriteIcon()
        {
            Icon = FontAwesome.Solid.Cog,
            Colour = Color4.White
        };
        public LocalisableString Title => "settings";
        public LocalisableString Description => "adjust your maisim settings";

        public SettingsOverlay()
        {

        }

        [BackgroundDependencyLoader]
        private void load()
        {

        }
    }
}
