using maisim.Game.Graphics.UserInterface.Overlays;
using osu.Framework.Allocation;

namespace maisim.Game.Graphics.UserInterface.Toolbar
{
    public class ToolbarSettingsButton : ToolbarOverlayToggleButton
    {
        [BackgroundDependencyLoader(true)]
        private void load(SettingsOverlay settingsOverlay)
        {
            StateContainer = settingsOverlay;
        }
    }
}
