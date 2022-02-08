using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Textures;
using osuTK;
using osuTK.Graphics;

namespace maisim.Game.Component
{
    public class SongSelectionBackground : CompositeDrawable
    {
        private readonly Color4 backgroundColor;

        public SongSelectionBackground(Color4 backgroundColor)
        {
            this.backgroundColor = backgroundColor;
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            InternalChildren = new Drawable[]
            {
                new Box
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    RelativePositionAxes = Axes.Both,
                    RelativeSizeAxes = Axes.X,
                    Colour = backgroundColor,
                    Size = new Vector2(320,320)
                },
                new Circle
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    RelativePositionAxes = Axes.Both,
                    RelativeSizeAxes = Axes.Both,
                    Colour = backgroundColor,
                    Size = new Vector2(1.7f)
                }
            };
        }
    }
}
