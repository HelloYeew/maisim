using System;
using maisim.Game.Screen.Gameplay;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osuTK;
using osuTK.Graphics;

namespace maisim.Game.Graphics.Gameplay
{
    /// <summary>
    /// A note spawner at the center of the ring that show as the visual indicator, not the actual spawner.
    /// </summary>
    public class VisualSpawner : CompositeDrawable
    {
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
                        -(Playfield.SPAWNER_MULTIPLIER * (float)Math.Cos((angle + 90f) * (float)(Math.PI / 180))),
                        -(Playfield.SPAWNER_MULTIPLIER * (float)Math.Sin((angle + 90f) * (float)(Math.PI / 180)))
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
