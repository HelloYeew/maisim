using System;
using maisim.Game.Beatmaps;
using osu.Framework.Bindables;

namespace maisim.Game.Graphics.UserInterface.Overlays
{
    /// <summary>
    /// A class that provide the bindable for the current <see cref="BeatmapSet"/> and <see cref="DifficultyLevel"/> of the game.
    /// </summary>
    public class CurrentWorkingBeatmap
    {
        /// <summary>
        /// The bindable for the current <see cref="BeatmapSet"/>.
        /// </summary>
        private Bindable<BeatmapSet> currentBeatmapSet = new Bindable<BeatmapSet>();

        /// <summary>
        /// The bindable for the current <see cref="DifficultyLevel"/>.
        /// </summary>
        private Bindable<DifficultyLevel> currentDifficultyLevel = new Bindable<DifficultyLevel>();

        /// <summary>
        /// Get the current <see cref="BeatmapSet"/> of the game.
        /// </summary>
        public BeatmapSet BeatmapSet => currentBeatmapSet.Value;

        /// <summary>
        /// Get the current <see cref="DifficultyLevel"/> of the game.
        /// </summary>
        public DifficultyLevel DifficultyLevel => currentDifficultyLevel.Value;

        /// <summary>
        /// Bind <see cref="ValueChangedEvent{T}"/> of the <see cref="BeatmapSet"/> to the <see cref="BeatmapSet"/> bindable.
        /// </summary>
        /// <param name="onChange">The action to perform when <see cref="BeatmapSet"/> changes.</param>
        /// <param name="runOnceImmediately">Whether the action provided in <paramref name="onChange"/> should be run once immediately.</param>
        public void BindBeatmapSetChanged(Action<ValueChangedEvent<BeatmapSet>> onChange, bool runOnceImmediately = false) => currentBeatmapSet.BindValueChanged(onChange, runOnceImmediately);

        /// <summary>
        /// Bind <see cref="ValueChangedEvent{T}"/> of the <see cref="DifficultyLevel"/> to the <see cref="DifficultyLevel"/> bindable.
        /// </summary>
        /// <param name="onChange">The action to perform when <see cref="DifficultyLevel"/> changes.</param>
        /// <param name="runOnceImmediately">Whether the action provided in <paramref name="onChange"/> should be run once immediately.</param>
        public void BindDifficultyLevelChanged(Action<ValueChangedEvent<DifficultyLevel>> onChange, bool runOnceImmediately = false) => currentDifficultyLevel.BindValueChanged(onChange, runOnceImmediately);

        /// <summary>
        /// Set the value of the <see cref="BeatmapSet"/> bindable.
        /// </summary>
        /// <param name="beatmapSet">The new value of the <see cref="BeatmapSet"/> bindable.</param>
        public void SetCurrentBeatmapSet(BeatmapSet beatmapSet)
        {
            currentBeatmapSet.Value = beatmapSet;
        }

        /// <summary>
        /// Set the value of the <see cref="DifficultyLevel"/> bindable.
        /// </summary>
        /// <param name="difficultyLevel">The new value of the <see cref="DifficultyLevel"/> bindable.</param>
        public void SetCurrentDifficultyLevel(DifficultyLevel difficultyLevel)
        {
            currentDifficultyLevel.Value = difficultyLevel;
        }
    }
}
