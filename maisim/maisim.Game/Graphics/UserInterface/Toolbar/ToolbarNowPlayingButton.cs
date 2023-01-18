using maisim.Game.Graphics.UserInterface.Overlays;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osuTK.Graphics;

namespace maisim.Game.Graphics.UserInterface.Toolbar
{
    public partial class ToolbarNowPlayingButton : ToolbarOverlayToggleButton
    {
        protected override Anchor TooltipAnchor => Anchor.TopRight;

        public ToolbarNowPlayingButton()
        {
            SetIcon(new SpriteIcon()
            {
                Icon = FontAwesome.Solid.Play,
                Colour = Color4.White
            });
            TooltipMainText = "now playing";
            TooltipSubText = "what's playing now";
        }

        [BackgroundDependencyLoader(true)]
        private void load(NowPlayingOverlay nowPlayingOverlay)
        {
            StateContainer = nowPlayingOverlay;
        }
    }
}
