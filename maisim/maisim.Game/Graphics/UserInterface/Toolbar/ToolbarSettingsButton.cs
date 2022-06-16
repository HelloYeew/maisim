using osu.Framework.Graphics.Sprites;
using osuTK.Graphics;

namespace maisim.Game.Graphics.UserInterface.Toolbar
{
    public class ToolbarSettingsButton : ToolbarButton
    {
        public ToolbarSettingsButton()
        {
            SetIcon(new SpriteIcon()
            {
                Icon = FontAwesome.Solid.Cog,
                Colour = Color4.White
            });
            TooltipMainText = "settings";
            TooltipSubText = "adjust your maisim settings";
        }
    }
}
