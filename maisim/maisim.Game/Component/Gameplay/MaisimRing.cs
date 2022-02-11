using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osuTK;
using osuTK.Graphics;

namespace maisim.Game.Component.Gameplay
{
    public class MaisimRing : CircularContainer
    {
        [BackgroundDependencyLoader]
        private void load()
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            Size = new Vector2(250, 250);
            Children = new Drawable[]
            {
                new Circle()
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    RelativeSizeAxes = Axes.Both,
                    Colour = Color4.White,
                    BorderThickness = 10,
                    BorderColour = Color4.Pink,
                    Masking = true
                }
            };
        }
    }
}
