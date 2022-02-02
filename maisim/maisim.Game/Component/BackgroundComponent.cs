using maisim.Game.Store;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Screens;
using osuTK;

namespace maisim.Game.Component
{
    public class BackgroundComponent : CompositeDrawable
    {
        [BackgroundDependencyLoader]
        private void load(TextureStore textureStore)
        {
            InternalChild = new Sprite
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Texture = textureStore.Get("background"),
                // Make it cover the whole screen
                Scale = new Vector2(1, 1),
                FillMode = FillMode.Fill
            };
        }
    }
}
