using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;

namespace maisim.Game.Graphics.UserInterface.Toolbar
{
    public class ToolbarUserButton : ToolbarButton
    {
        public ToolbarUserButton()
        {
            Text = "Dummy";
            AutoSizeAxes = Axes.X;
        }

        [BackgroundDependencyLoader]
        private void load(TextureStore textureStore)
        {
            SetIcon(new Sprite
            {
                Texture = textureStore.Get("dummyprofile"),
            });
        }
    }
}
