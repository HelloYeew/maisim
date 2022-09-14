using maisim.Game.Beatmaps;

namespace maisim.Game.Utils
{
    /// <summary>
    /// An extension tool for the beatmaps related classes.
    /// </summary>
    public class BeatmapUtils
    {
        /// <summary>
        /// Return the min and max value of the difficulty rating in the target <see cref="BeatmapSet"/>.
        /// </summary>
        /// <param name="beatmapset">Target <see cref="BeatmapSet"/></param>
        /// <returns>Min and max value of the difficulty rating</returns>
        public static (double, double) GetDifficultyRatingRange(BeatmapSet beatmapset)
        {
            double min = double.MaxValue;
            double max = double.MinValue;
            foreach (Beatmap beatmap in beatmapset.Beatmaps)
            {
                double starDifficulty = beatmap.DifficultyRating;
                if (starDifficulty < min)
                    min = starDifficulty;
                if (starDifficulty > max)
                    max = starDifficulty;
            }
            return (min, max);
        }

        /// <summary>
        /// Return the note designer of the target <see cref="DifficultyLevel"/> in the list of <see cref="Beatmap"/>
        /// inside the target <see cref="BeatmapSet"/>.
        /// </summary>
        /// <param name="beatmapSet">Target <see cref="BeatmapSet"/></param>
        /// <param name="difficultyLevel">Target <see cref="DifficultyLevel"/></param>
        /// <returns>Note designer name</returns>
        public static string GetNoteDesignerFromBeatmapSet(BeatmapSet beatmapSet, DifficultyLevel difficultyLevel)
        {
            foreach (Beatmap beatmap in beatmapSet.Beatmaps)
            {
                if (beatmap.DifficultyLevel == difficultyLevel)
                    return beatmap.NoteDesigner;
            }
            return "unknown";
        }

        /// <summary>
        /// Get a string represent the target <see cref="Beatmap"/>.
        /// </summary>
        /// <param name="beatmap">The target <see cref="Beatmap"/></param>
        /// <returns></returns>
        public static string GetBeatmapString(Beatmap beatmap)
        {
            return $"{beatmap.BeatmapID} - {beatmap.DifficultyRating} stars ({beatmap.DifficultyLevel}) by {beatmap.NoteDesigner}";
        }

        /// <summary>
        /// Get a string represent the target <see cref="BeatmapSet"/>.
        /// </summary>
        /// <param name="beatmapSet">The target <see cref="BeatmapSet"/></param>
        /// <returns></returns>
        public static string GetBeatmapSetString(BeatmapSet beatmapSet)
        {
            return $"{beatmapSet.BeatmapSetID}) {beatmapSet.TrackMetadata.Title} - {beatmapSet.TrackMetadata.Artist}";
        }
    }
}
