using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;

namespace maisim.Game.Graphics.Gameplay.Notes
{
    /// <summary>
    /// Class represent the TAP note when it will appear at the same time.
    /// </summary>
    public class DrawableTapBothNote : DrawableNote
    {
        protected override Drawable[] AddNoteParts(TextureStore textureStore)
        {
            return new Drawable[]
            {
                new Sprite
                {
                    RelativeSizeAxes = Axes.Both,
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    FillMode = FillMode.Fill,
                    Texture = textureStore.Get("Notes/TapBoth.png")
                }
            };
        }

        public override bool CanDespawn => false;
    }
}
