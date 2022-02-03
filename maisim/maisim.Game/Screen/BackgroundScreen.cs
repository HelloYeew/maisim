using maisim.Game.Component;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Screens;

namespace maisim.Game
{
    public class BackgroundScreen : Screen
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
