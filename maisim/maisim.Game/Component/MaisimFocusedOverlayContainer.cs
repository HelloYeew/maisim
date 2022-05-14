using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osuTK.Graphics;

namespace maisim.Game.Component
{
    public class MaisimFocusedOverlayContainer : FocusedOverlayContainer
    {
        public MaisimFocusedOverlayContainer()
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;

            Children = new Drawable[]
            {
                new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    Colour = Color4.Cyan,
                    Alpha = 0.5f
                }
            };
        }
    }
}
