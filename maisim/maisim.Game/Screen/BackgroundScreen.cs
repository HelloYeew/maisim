using maisim.Game.Component;
using osu.Framework.Allocation;
using osu.Framework.Graphics;

namespace maisim.Game.Screen
{
    /// <summary>
    /// A screen that holds a stack of backgrounds for the other screens.
    /// </summary>
    public class BackgroundScreen : osu.Framework.Screens.Screen
    {
        [BackgroundDependencyLoader]
        private void load()
        {
            InternalChildren = new Drawable[]
            {
                new BackgroundComponent("testbackground2")
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
