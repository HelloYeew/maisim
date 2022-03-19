using System;
using System.Linq;
using maisim.Game.Component.Gameplay.Notes;
using maisim.Game.Utils;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osuTK;

namespace maisim.Game.Screen.Gameplay
{
    /// <summary>
    /// A main playfield that contains all the notes and manages their rendering.
    /// </summary>
    public class Playfield : osu.Framework.Screens.Screen
    {
        public static readonly float SPAWNER_MULTIPLIER = 75f;

        public static readonly float NOTE_SPEED = 2f;

        public static readonly float DISTANCE_ON_DESPAWN = 40f;

        [BackgroundDependencyLoader]
        private void load()
        {

        }

        /// <summary>
        /// Spawn a desired <see cref="DrawableNote"/>
        /// </summary>
        /// <param name="note">A desired <see cref="DrawableNote"/>.</param>
        public void SpawnNote(DrawableNote note)
        {
            AddInternal(note);
        }

        /// <summary>
        /// Spawn <see cref="DrawableTapNote"/> on the desired lane.
        /// </summary>
        /// <param name="lane">The <see cref="NoteLane"/> that the <see cref="DrawableTapNote"/> want to spawn.</param>
        public void SpawnTapNote(NoteLane lane)
        {
            AddInternal(new DrawableTapNote
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Position = new Vector2(
                    -(SPAWNER_MULTIPLIER * (float)Math.Cos((NoteLaneExtension.GetAngle(lane) + 90f) * (float)(Math.PI / 180))),
                    -(SPAWNER_MULTIPLIER * (float)Math.Sin((NoteLaneExtension.GetAngle(lane) + 90f) * (float)(Math.PI / 180)))
                    ),
                Scale = new Vector2(1.2f),
                Margin = new MarginPadding(10),
                Lane = lane
            });
        }

        protected override void Update()
        {
            foreach (Drawable note in InternalChildren.ToList())
            {
                // TODO: Make the note despawn when it's out of the ring

                // We have a lot of note type so we need to check on its type before we can update it
                if (note is DrawableTapNote tapNote)
                {
                    Vector2 spawnerPosition = NoteLaneExtension.GetSpawnerPosition(tapNote.Lane);
                    Vector2 sensorPosition = NoteLaneExtension.GetSensorPosition(tapNote.Lane);
                    Vector2 notePosition = tapNote.Position;

                    if (MathUtils.CalculateDistance(spawnerPosition, sensorPosition) + DISTANCE_ON_DESPAWN <
                        MathUtils.CalculateDistance(notePosition, spawnerPosition))
                    {
                        note.FadeOut(100, Easing.InBounce);
                        Scheduler.AddDelayed(() => RemoveInternal(note), 500);
                    }
                    else
                    {
                        note.Position += new Vector2(
                            -(NOTE_SPEED * (float)Math.Cos((NoteLaneExtension.GetAngle(tapNote.Lane) + 90f) *
                                                           (float)(Math.PI / 180))),
                            -(NOTE_SPEED * (float)Math.Sin((NoteLaneExtension.GetAngle(tapNote.Lane) + 90f) *
                                                           (float)(Math.PI / 180)))
                        );
                    }
                }
            }

            base.Update();
        }
    }
}
