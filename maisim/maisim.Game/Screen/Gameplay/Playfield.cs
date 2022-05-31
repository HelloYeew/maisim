using System;
using System.Collections.Generic;
using System.Linq;
using maisim.Game.Component.Gameplay.Notes;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osuTK;

namespace maisim.Game.Screen.Gameplay
{
    /// <summary>
    /// A main playfield that contains all the notes and manages their rendering.
    /// </summary>
    public class Playfield : Container
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
            RelativeSizeAxes = Axes.Both;
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

            // Update the position of the notes
            foreach (Drawable note in InternalChildren.ToList())
            {
                if (note is DrawableNote drawableNote)
                {
                    if (drawableNote.CanDespawn())
                    {
                        Scheduler.AddDelayed(() => RemoveInternal(drawableNote), 500);
                    }
                    else
                    {
                        drawableNote.UpdatePosition(this);
                    }
                }
            }

            base.Update();
        }
    }
}
