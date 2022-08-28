using maisim.Game.Utils;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osuTK;

namespace maisim.Game.Graphics.UserInterfaceV2
{
    public class BeatmapSetSelection : CompositeDrawable
    {
        [BackgroundDependencyLoader]
        private void load()
        {
            // This container need to be wide equal to the screen width to prevent the scroll bar from being cut off.
            Anchor = Anchor.TopLeft;
            Origin = Anchor.TopLeft;
            RelativeSizeAxes = Axes.Y;
            Position = new Vector2(120, 0);
            Size = new Vector2(400, 1);
            InternalChildren = new Drawable[]
            {
                new Box
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    RelativeSizeAxes = Axes.Both,
                    Colour = MaisimColour.SongSelectionContainerColor,
                    Alpha = 0.5f
                },
                new BeatmapSetCard(new BeatmapSetTestFixture().BeatmapSet)
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Scale = new Vector2(0.6f, 0.6f),
                }
            };
        }
    }
}
