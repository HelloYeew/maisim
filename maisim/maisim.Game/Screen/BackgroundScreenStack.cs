using osu.Framework.Graphics;
using osu.Framework.Screens;

namespace maisim.Game
{
    public class BackgroundScreenStack : ScreenStack
    {
        public BackgroundScreenStack() : base(false)
        {
            RelativeSizeAxes = Axes.Both;
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
        }

        public bool Push(BackgroundScreen screen)
        {
            if (screen == null)
                return false;

            screen.Push(screen);
            return true;
        }
    }
}
