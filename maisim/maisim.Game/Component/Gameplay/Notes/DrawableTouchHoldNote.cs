using maisim.Game.Screen.Gameplay;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;

namespace maisim.Game.Component.Gameplay.Notes
{
    /// <summary>
    /// Class represent the TOUCH HOLD note.
    /// </summary>
    public class TouchHold : DrawableNote
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
                    Texture = textureStore.Get("Notes/TouchHold.png")
                }
            };
        }

        public override void UpdatePosition(Playfield playfield)
        {

        }

        public override bool CanDespawn => false;
    }
}
