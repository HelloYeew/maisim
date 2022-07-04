using System.Collections.Generic;
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

        protected override Drawable CreateHeader() => new SettingsHeader(Title, Description);

        protected override IEnumerable<SettingsSection> CreateSections() => new SettingsSection[]
        {
            new SettingsHeader(Title, Description),
            new AudioSection(),
            new UserInterfaceSection(),
            new GraphicsSection(),
            new DebugSection()
        };

        [BackgroundDependencyLoader]
        private void load()
        {

        }
    }
}
