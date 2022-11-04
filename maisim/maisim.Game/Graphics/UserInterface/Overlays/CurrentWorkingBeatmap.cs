using maisim.Game.Beatmaps;
using osu.Framework.Bindables;

namespace maisim.Game.Graphics.UserInterface.Overlays
{
    /// <summary>
    /// A class that provide the bindable for the current <see cref="BeatmapSet"/> and <see cref="DifficultyLevel"/> of the game.
    /// </summary>
    public class CurrentWorkingBeatmap : Bindable<BeatmapSet>
    {
        /// <summary>
        /// The bindable for the current <see cref="DifficultyLevel"/>.
        /// </summary>
        private Bindable<DifficultyLevel> difficultyLevel = new Bindable<DifficultyLevel>();

        /// <summary>
        /// A current working <see cref="BeatmapSet"/>
        /// </summary>
        public BeatmapSet BeatmapSet
        {
            get => Value;
            set => Value = value;
        }

        /// <summary>
        /// A current <see cref="DifficultyLevel"/> of the working <see cref="BeatmapSet"/>.
        /// </summary>
        public DifficultyLevel DifficultyLevel
        {
            get => difficultyLevel.Value;
            set => difficultyLevel.Value = value;
        }

        protected override Bindable<BeatmapSet> CreateInstance()
        {
            CurrentWorkingBeatmap instance = new CurrentWorkingBeatmap();
            return instance;
        }

        public CurrentWorkingBeatmap()
        {
            difficultyLevel.BindValueChanged(_ => TriggerChange(), true);
        }
    }
}
