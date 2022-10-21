using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;

namespace maisim.Game.Graphics.UserInterface
{
    /// <summary>
    /// A drawable background component that's always staying at the bottom of the screen.
    /// </summary>
    public class BackgroundComponent : CompositeDrawable
    {
        private string backgroundName;

        public BackgroundComponent(string backgroundName)
        {
            this.backgroundName = backgroundName;
        }

        [BackgroundDependencyLoader]
        private void load(TextureStore textureStore)
        {
            InternalChild = new Sprite
            {
                RelativeSizeAxes = Axes.Both,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                FillMode = FillMode.Fill,
                Texture = textureStore.Get(backgroundName)
            };
        }
    }
}
