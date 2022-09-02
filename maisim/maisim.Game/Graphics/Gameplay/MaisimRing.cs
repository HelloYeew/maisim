using System;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osuTK;
using osuTK.Graphics;

namespace maisim.Game.Graphics.Gameplay
{
    public class MaisimRing : CircularContainer
    {
        public static readonly float[] LANE_ANGLES =
        {
            22.5f,
            67.5f,
            112.5f,
            157.5f,
            202.5f,
            247.5f,
            292.5f,
            337.5f
        };

        public const float LANE_MULTIPLIER = 284.5f; // TODO: Still not sure on this. But when the outline circle is working, this should be changed too.

        [BackgroundDependencyLoader]
        private void load()
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            Size = new Vector2(580, 580);
            Children = new Drawable[]
            {
                new Circle
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    RelativeSizeAxes = Axes.Both,
                    Colour = Color4.DarkCyan,
                    BorderThickness = 10,
                    BorderColour = Color4.Green,
                    Masking = true
                }
            };

            foreach (float angle in LANE_ANGLES)
            {
                AddInternal(new Circle
                {
                    Position = new Vector2(
                        -(LANE_MULTIPLIER * (float)Math.Cos((angle + 90f) * (float)(Math.PI / 180))),
                        -(LANE_MULTIPLIER * (float)Math.Sin((angle + 90f) * (float)(Math.PI / 180)))
                    ),
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Size = new Vector2(10)
                });
            }

            AddInternal(new Circle
            {
                Position = Vector2.Zero,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Size = new Vector2(10),
            });
        }
    }
}
