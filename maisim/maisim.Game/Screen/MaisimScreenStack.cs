using maisim.Game.Graphics.Containers;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Screens;

namespace maisim.Game.Screen
{
    public partial class MaisimScreenStack : ScreenStack
    {
        [Cached]
        private BackgroundScreenStack backgroundScreenStack;

        private readonly ParallaxContainer parallaxContainer;

        protected float ParallaxAmount => parallaxContainer.ParallaxAmount;

        public MaisimScreenStack()
        {
            InternalChild = parallaxContainer = new ParallaxContainer
            {
                RelativeSizeAxes = Axes.Both,
                Child = backgroundScreenStack = new BackgroundScreenStack
                {
                    RelativeSizeAxes = Axes.Both
                }
            };

            ScreenPushed += screenPushed;
            ScreenExited += ScreenChanged;
        }

        private void screenPushed(IScreen prev, IScreen next)
        {
            ScreenChanged(prev, next);
        }

        protected virtual void ScreenChanged(IScreen prev, IScreen next)
        {
            setParallax(next);
        }

        private void setParallax(IScreen next) =>
            parallaxContainer.ParallaxAmount = ParallaxContainer.DEFAULT_PARALLAX_AMOUNT * (((IMaisimScreen)next)?.BackgroundParallaxAmount ?? 1.0f);
    }
}
