using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Screens;

namespace maisim.Game.Screen
{
    public class MaisimScreenStack : ScreenStack
    {
        [Cached]
        private BackgroundScreenStack backgroundScreenStack;

        public MaisimScreenStack()
        {
            InternalChild = new Container
            {
                RelativeSizeAxes = Axes.Both,
                Child = backgroundScreenStack = new BackgroundScreenStack
                {
                    RelativeSizeAxes = Axes.Both
                }
            };
        }
    }
}
