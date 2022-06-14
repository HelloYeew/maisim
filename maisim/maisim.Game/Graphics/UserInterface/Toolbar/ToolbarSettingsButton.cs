using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Input.Events;
using osuTK.Graphics;
using osuTK;

namespace maisim.Game.Graphics.UserInterface.Toolbar
{
    public class ToolbarSettingsButton : ToolbarButton
    {
        public ToolbarSettingsButton()
        {
            SetIcon(new SpriteIcon()
            {
                Icon = FontAwesome.Solid.Cog,
                Colour = Color4.Black
            });
            TooltipMainText = "settings";
            TooltipSubText = "adjust your maisim settings";
        }
    }
}
