using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;

namespace maisim.Game.Component.Gameplay.Notes
{
    /// <summary>
    /// Class represent the normal TAP note.
    /// </summary>
    public class DrawableTapNote : DrawableNote
    {

        public NoteLane Lane { get; set; }

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
                    Texture = textureStore.Get("Notes/TapNormal.png")
                }
            };
        }
    }
}
