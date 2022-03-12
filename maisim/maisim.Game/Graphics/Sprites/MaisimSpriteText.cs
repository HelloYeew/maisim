using osu.Framework.Graphics.Sprites;

namespace maisim.Game.Graphics.Sprites
{
    public class MaisimSpriteText : SpriteText
    {
        public MaisimSpriteText()
        {
            Font = MaisimFont.Default;
            Shadow = true;
        }
    }
}
