using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osuTK.Graphics;

namespace maisim.Game.Graphics.UserInterface.Toolbar
{
    public class ToolbarNowPlayingButton : ToolbarButton
    {
        protected override Anchor TooltipAnchor => Anchor.TopRight;

        public ToolbarNowPlayingButton()
        {
            SetIcon(new SpriteIcon()
            {
                Icon = FontAwesome.Solid.Play,
                Colour = Color4.Black
            });
            TooltipMainText = "now playing";
            TooltipSubText = "what's playing now";
        }
    }
}
