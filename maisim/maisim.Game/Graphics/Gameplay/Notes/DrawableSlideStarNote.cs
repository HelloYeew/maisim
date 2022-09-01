using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;

namespace maisim.Game.Graphics.Gameplay.Notes
{
    /// <summary>
    /// Class represent the star in SLIDE note.
    /// </summary>
    public class DrawableSlideStarNote : DrawableNote
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
                    Texture = textureStore.Get("Notes/SlideStar.png")
                }
            };
        }

        public override bool CanDespawn => false;
    }
}
