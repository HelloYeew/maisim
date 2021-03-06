using osu.Framework.Graphics;
using osu.Framework.Screens;

namespace maisim.Game.Screen
{
    public class BackgroundScreenStack : ScreenStack
    {
        public BackgroundScreenStack() : base(false)
        {
            RelativeSizeAxes = Axes.Both;
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            InternalChild = new BackgroundScreen();
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
