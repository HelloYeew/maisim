using maisim.Game.Screen.Gameplay;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;

namespace maisim.Game.Component.Gameplay.Notes
{
    /// <summary>
    /// Class represent the BREAK note.
    /// </summary>
    public class DrawableBreakNote : DrawableNote
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
                    Texture = textureStore.Get("Notes/Break.png")
                }
            };
        }

        public override string GetEncodeString()
        {
            return "";
        }
        
        public override bool CanDespawn => false;
    }
}
