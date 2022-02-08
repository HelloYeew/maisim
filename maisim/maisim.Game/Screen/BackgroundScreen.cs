using maisim.Game.Component;
using osu.Framework.Allocation;
using osu.Framework.Graphics;

namespace maisim.Game.Screen
{
    /// <summary>
    /// The screen that always stay at the bottom of <see cref="MaisimScreenStack"/> include only the <see cref="BackgroundComponent"/>.
    /// </summary>
    public class BackgroundScreen : osu.Framework.Screens.Screen
    {
        [BackgroundDependencyLoader]
        private void load()
        {
            InternalChildren = new Drawable[]
            {
                new BackgroundComponent("background3")
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    FillMode = FillMode.Stretch,
                    RelativeSizeAxes = Axes.Both
                }
            };
        }
    }
}
