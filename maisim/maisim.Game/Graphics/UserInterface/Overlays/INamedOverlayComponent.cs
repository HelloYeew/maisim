using osu.Framework.Graphics;
using osu.Framework.Localisation;

namespace maisim.Game.Graphics.UserInterface.Overlays
{
    /// <summary>
    /// An interface for an overlay whose visibility state is bound to one of the buttons on the <see cref="Toolbar"/>
    /// </summary>
    public interface INamedOverlayComponent
    {
        Drawable Icon { get; }

        LocalisableString Title { get; }

        LocalisableString Description { get; }
    }
}
