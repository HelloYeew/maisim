using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osuTK.Graphics;

namespace maisim.Game.Graphics.UserInterface.Toolbar
{
    public class ToolbarNotificationsButton : ToolbarButton
    {
        protected override Anchor TooltipAnchor => Anchor.TopRight;

        public ToolbarNotificationsButton()
        {
            SetIcon(new SpriteIcon()
            {
                Icon = FontAwesome.Solid.Bell,
                Colour = Color4.White
            });
            TooltipMainText = "notifications";
            TooltipSubText = "see what's happening";
        }
    }
}
