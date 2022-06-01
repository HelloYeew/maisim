using System;
using System.Collections.Generic;
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
            Add(note);
        }

        /// <summary>
        /// Spawn <see cref="DrawableTapNote"/> on the desired lane.
        /// </summary>
        /// <param name="lane">The <see cref="NoteLane"/> that the <see cref="DrawableTapNote"/> want to spawn.</param>
        public void SpawnTapNote(NoteLane lane)
        {
            Add(new DrawableTapNote
            {
                Lane = lane,
                TargetTime = Clock.CurrentTime + TIME_NOTE_APPEARS + 100
            });
        }

    }
}
