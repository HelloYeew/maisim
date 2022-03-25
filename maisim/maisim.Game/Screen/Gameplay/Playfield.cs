using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using maisim.Game.Component.Gameplay.Notes;
using maisim.Game.Utils;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Logging;
using osuTK;

namespace maisim.Game.Screen.Gameplay
{
    /// <summary>
    /// A main playfield that contains all the notes and manages their rendering.
    /// </summary>
    public class Playfield : osu.Framework.Screens.Screen
    {
        public const float SPAWNER_MULTIPLIER = 75f;

        public const float NOTE_SPEED = 1f;

        public const float DISTANCE_ON_DESPAWN = 40f;

        public const float TIME_NOTE_APPEARS = 500f;

        public List<DrawableNote> NotesPool;

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
                Lane = lane
            });
        }

        protected override void Update()
        {
            if (NotesPool != null)
            {
                foreach (Drawable note in NotesPool.ToList())
                {
                    // We have a lot of note type so we need to check on its type before we can update it
                    if (note is DrawableTapNote tapNote)
                    {
                        if (tapNote.TargetTime != 0f && Clock.TimeInfo.Current >= tapNote.TargetTime - TIME_NOTE_APPEARS)
                        {
                            AddInternal(note);
                            NotesPool.Remove(tapNote);
                        }
                    }
                }
            }

            foreach (Drawable note in InternalChildren.ToList())
            {
                if (note is DrawableTapNote tapNote)
                {
                    if (MathUtils.EuclideanDistance(NoteLaneExtension.GetSpawnerPosition(tapNote.Lane), NoteLaneExtension.GetSensorPosition(tapNote.Lane)) + DISTANCE_ON_DESPAWN <
                        MathUtils.EuclideanDistance(tapNote.Position, NoteLaneExtension.GetSpawnerPosition(tapNote.Lane)))
                    {
                        // Enter despawning state
                        note.FadeOut(50, Easing.InBounce);
                        Scheduler.AddDelayed(() => RemoveInternal(note), 500);
                    }
                    else
                    {
                        if (tapNote.TargetTime != 0f)
                        {
                            double speed = MathUtils.EuclideanDistance(
                                NoteLaneExtension.GetSpawnerPosition(tapNote.Lane),
                                NoteLaneExtension.GetSensorPosition(tapNote.Lane)) / TIME_NOTE_APPEARS;
                            tapNote.Position = new Vector2(
                                (float) (tapNote.Position.X + ((float)(speed * (-(float)Math.Cos((NoteLaneExtension.GetAngle(tapNote.Lane) + 90f) * (float)(Math.PI / 180)))) * Clock.ElapsedFrameTime)),
                                (float) (tapNote.Position.Y + ((float)(speed * (-(float)Math.Sin((NoteLaneExtension.GetAngle(tapNote.Lane) + 90f) * (float)(Math.PI / 180)))) * Clock.ElapsedFrameTime))
                                );
                        }
                        else
                        {
                            // Update the position
                            note.Position += new Vector2(
                                -(NOTE_SPEED * (float)Math.Cos((NoteLaneExtension.GetAngle(tapNote.Lane) + 90f) *
                                                               (float)(Math.PI / 180))),
                                -(NOTE_SPEED * (float)Math.Sin((NoteLaneExtension.GetAngle(tapNote.Lane) + 90f) *
                                                               (float)(Math.PI / 180)))
                            );
                        }
                    }
                }
            }

            base.Update();
        }
    }
}
