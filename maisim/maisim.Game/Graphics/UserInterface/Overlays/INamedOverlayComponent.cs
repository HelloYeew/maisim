using osu.Framework.Graphics;
using osu.Framework.Localisation;

namespace maisim.Game.Graphics.UserInterface.Overlays
{
    /// <summary>
    /// An overlay component interface that's bind with the <see cref="Toolbar"/>
    /// </summary>
    public interface INamedOverlayComponent
    {
        Drawable Icon { get; }

        LocalisableString Title { get; }

        LocalisableString Description { get; }
    }
}
