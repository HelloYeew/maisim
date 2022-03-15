using System;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osuTK;
using osuTK.Graphics;

namespace maisim.Game.Component.Gameplay
{
    public class VisualSpawner : CompositeDrawable
    {
        private static readonly float SPAWNER_MULTIPLIER = 75f;

        [BackgroundDependencyLoader]
        private void load()
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            Size = new Vector2(580, 580);

            foreach (var angle in MaisimRing.LANE_ANGLES)
            {
                AddInternal(new Circle
                {
                    Position = new Vector2(
                        -(SPAWNER_MULTIPLIER * (float)Math.Cos((angle + 90f) * (float)(Math.PI / 180))),
                        -(SPAWNER_MULTIPLIER * (float)Math.Sin((angle + 90f) * (float)(Math.PI / 180)))
                        ),
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Size = new Vector2(10),
                    Colour = Color4.White,
                });
            }
        }
    }
}
