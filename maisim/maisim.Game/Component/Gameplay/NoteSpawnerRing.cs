using System;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osuTK;

namespace maisim.Game.Component.Gameplay
{
    /// <summary>
    /// A circle that include <see cref="NoteSpawner"/> that is target to angles in <see cref="MaisimRing"/>.
    ///
    /// This spawner use to spawn a note that's spawn from the center of the playfield. (TAP, BREAK, HOLD)
    /// </summary>
    public class NoteSpawnerRing : CircularContainer
    {
        // TODO: Make more clarification from Maimai player on the size of spawner ring.
        private static readonly float SPAWNER_MULTIPLIER = 75f;

        /// <summary>
        /// Show ring of spawner and all spawner.
        /// </summary>
        public bool ShowSpawners { get; set; }

        [BackgroundDependencyLoader]
        private void load()
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            Size = MaisimRing.PLAYFIELD_SIZE;

            foreach (var angle in MaisimRing.LANE_ANGLES)
            {
                AddInternal(new NoteSpawner
                {
                    Position = new Vector2(
                        -(SPAWNER_MULTIPLIER * (float)Math.Cos((angle + 90f) * (float)(Math.PI / 180))),
                        -(SPAWNER_MULTIPLIER * (float)Math.Sin((angle + 90f) * (float)(Math.PI / 180)))
                    ),
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Size = new Vector2(2),
                    TargetAngles = angle,
                    ShowOutline = ShowSpawners
                });
            }
        }
    }
}
