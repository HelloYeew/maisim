using maisim.Game.Component;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Screens;
using osuTK;

namespace maisim.Game
{
    public class SongSelectionScreen : Screen
    {
        [BackgroundDependencyLoader]
        private void load()
        {
            InternalChildren = new Drawable[]
            {
                new BackButton
                {
                    Anchor = Anchor.BottomLeft,
                    Origin = Anchor.Centre,
                    Size = new Vector2(0.5f),
                    RelativeSizeAxes = Axes.Both,
                },
            };
        }
    }
}
