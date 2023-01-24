using maisim.Game.Graphics.UserInterface;
using osu.Framework.Allocation;
using osu.Framework.Graphics;

namespace maisim.Game.Screen
{
    /// <summary>
    /// A screen that holds a stack of backgrounds for the other screens.
    /// </summary>
    public partial class BackgroundScreen : MaisimScreen
    {
        [BackgroundDependencyLoader]
        private void load()
        {
            InternalChildren = new Drawable[]
            {
                new BackgroundComponent("background")
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    FillMode = FillMode.Stretch,
                    RelativeSizeAxes = Axes.Both
                }
            };
        }

        public override float BackgroundParallaxAmount => 0f;
    }
}
