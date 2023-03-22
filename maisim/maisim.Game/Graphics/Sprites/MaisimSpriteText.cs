using osu.Framework.Graphics.Sprites;

namespace maisim.Game.Graphics.Sprites
{
    /// <summary>
    /// <see cref="SpriteText"/> with a default font used in the game.
    /// </summary>
    public partial class MaisimSpriteText : SpriteText
    {
        public MaisimSpriteText()
        {
            Font = MaisimFont.Default;
            Shadow = true;
        }
    }
}
