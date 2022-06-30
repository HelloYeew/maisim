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

        /// <summary>
        /// The time that the note need to be hit in milliseconds.
        /// </summary>
        public double TargetTime;

        /// <summary>
        /// Add the note sprite parts to the main class container.
        /// </summary>
        /// <param name="textureStore"><see cref="TextureStore"/> in load operation.</param>
        /// <returns>List of drawable include all note part that will be initialize on load.</returns>
        protected abstract Drawable[] AddNoteParts(TextureStore textureStore);

        /// <summary>
        /// Get string representation of the note in beatmap file.
        /// </summary>
        /// <returns></returns>
        public abstract string GetEncodeString();
    }
}
