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

        /// <summary>
        /// The time that note need to be spawn before the note's target time.
        /// </summary>
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
                Position = new Vector2(
                    -(SPAWNER_MULTIPLIER *
                      (float)Math.Cos((NoteLaneExtension.GetAngle(lane) + 90f) * (float)(Math.PI / 180))),
                    -(SPAWNER_MULTIPLIER *
                      (float)Math.Sin((NoteLaneExtension.GetAngle(lane) + 90f) * (float)(Math.PI / 180)))
                ),
                Lane = lane
            });
        }

        /// <summary>
        /// Update the target <see cref="DrawableNote"/>'s position.
        /// </summary>
        /// <param name="tapNote">The <see cref="DrawableTapNote"/> that want to update.</param>
        private void updateTapNotePosition(DrawableTapNote tapNote)
        {
            if (MathUtils.EuclideanDistance(NoteLaneExtension.GetSpawnerPosition(tapNote.Lane), NoteLaneExtension.GetSensorPosition(tapNote.Lane)) + DISTANCE_ON_DESPAWN <
                MathUtils.EuclideanDistance(tapNote.Position, NoteLaneExtension.GetSpawnerPosition(tapNote.Lane)))
            {
                // Enter despawning state
                tapNote.FadeOut(50, Easing.InBounce);
                Scheduler.AddDelayed(() => RemoveInternal(tapNote), 500);
            }
            else
            {
                if (tapNote.TargetTime != 0f)
                {
                    // Update the position
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
                    // This is for the note that spawn using SpawnTapNote method and no TargetTime specified in the test scene.
                    // Will remove it when the note spawn system is complete.
                    tapNote.Position += new Vector2(
                        -(NOTE_SPEED * (float)Math.Cos((NoteLaneExtension.GetAngle(tapNote.Lane) + 90f) *
                                                       (float)(Math.PI / 180))),
                        -(NOTE_SPEED * (float)Math.Sin((NoteLaneExtension.GetAngle(tapNote.Lane) + 90f) *
                                                       (float)(Math.PI / 180)))
                    );
                }
            }
        }

        /// <summary>
        /// Spawn the note from the pool to the playfield and remove it from the pool.
        /// </summary>
        /// <param name="note">The target note</param>
        private void spawnNoteFromPool(DrawableNote note)
        {
            // We have a lot of note type so we need to check on its type before we can update it
            if (note is DrawableTapNote tapNote)
            {
                if (tapNote.TargetTime != 0f && Clock.TimeInfo.Current >= tapNote.TargetTime - TIME_NOTE_APPEARS)
                {
                    // Add note to the drawable and remove it from the pool
                    note.Position = new Vector2(
                        -(SPAWNER_MULTIPLIER *
                          (float)Math.Cos((NoteLaneExtension.GetAngle(tapNote.Lane) + 90f) * (float)(Math.PI / 180))),
                        -(SPAWNER_MULTIPLIER *
                          (float)Math.Sin((NoteLaneExtension.GetAngle(tapNote.Lane) + 90f) * (float)(Math.PI / 180)))
                    );
                    AddInternal(note);
                    NotesPool.Remove(tapNote);
                }
            }
        }

        protected override void Update()
        {
            // Add note from the pool to the playfield drawable
            if (NotesPool != null)
            {
                foreach (DrawableNote note in NotesPool.ToList())
                {
                    spawnNoteFromPool(note);
                }
            }

            // Update the position of the notes
            foreach (Drawable note in InternalChildren.ToList())
            {
                if (note is DrawableTapNote tapNote)
                {
                    updateTapNotePosition(tapNote);
                }
            }

            base.Update();
        }
    }
}
