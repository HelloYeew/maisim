using maisim.Game.Beatmaps;
using maisim.Game.Utils;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics.Containers;

namespace maisim.Game.Graphics.UserInterface.Overlays
{
    /// <summary>
    /// The object that use to get the information of the current beatmap that is being played.
    /// </summary>
    public class WorkingBeatmap : CompositeDrawable
    {
        public Bindable<BeatmapSet> CurrentBeatmapSet { get; } = new Bindable<BeatmapSet>();
        public Bindable<DifficultyLevel> CurrentDifficultyLevel { get; } = new Bindable<DifficultyLevel>();

        [BackgroundDependencyLoader]
        private void load()
        {
            CurrentBeatmapSet.Value = new BeatmapSetTestFixture().BeatmapSet;
            CurrentDifficultyLevel.Value = DifficultyLevel.Basic;
        }
    }
}
