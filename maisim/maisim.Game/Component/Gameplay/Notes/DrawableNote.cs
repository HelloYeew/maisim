using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Textures;
using osuTK;

namespace maisim.Game.Component.Gameplay.Notes
{
    /// <summary>
    /// A base abstract class for notes in the gameplay.
    /// </summary>
    public abstract class DrawableNote : CompositeDrawable
    {
        [BackgroundDependencyLoader]
        private void load(TextureStore textureStore)
        {
            InternalChild = new Container
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Size = new Vector2(50),
                Children = AddNoteParts(textureStore)
            };
        }

        protected abstract Drawable[] AddNoteParts(TextureStore textureStore);
    }
}
