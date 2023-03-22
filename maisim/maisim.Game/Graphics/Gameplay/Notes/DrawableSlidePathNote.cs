using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osuTK;

namespace maisim.Game.Graphics.Gameplay.Notes
{
    /// <summary>
    /// Class represent the arrow path in the slider of SLIDE note.
    /// </summary>
    public partial class DrawableSlidePathNote : DrawableNote
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
                    Scale = new Vector2(0.5f),
                    Texture = textureStore.Get("Notes/SlidePath.png")
                }
            };
        }

        public override bool CanDespawn => false;
    }
}
