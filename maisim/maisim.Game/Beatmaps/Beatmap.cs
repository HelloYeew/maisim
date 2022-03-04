namespace maisim.Game.Beatmaps
{
    /// <summary>
    /// Class that represents a beatmap that includes all the information needed on beatmap.
    /// </summary>
    public class Beatmap
    {
        private readonly float difficultyRating;
        private readonly DifficultyLevel difficultyLevel;
        private readonly bool isRemaster;
        private readonly TrackMetadata trackMetadata;
        private readonly float maxSeasonalScore;
        private readonly string noteDesigner;

        // TODO: Implement SongSet when it's available

        public Beatmap(TrackMetadata trackMetadata, DifficultyLevel difficultyLevel, float difficultyRating, bool isRemaster, float maxSeasonalScore, string noteDesigner)
        {
            this.trackMetadata = trackMetadata;
            this.difficultyRating = difficultyRating;
            this.difficultyLevel = difficultyLevel;
            this.isRemaster = isRemaster;
            this.maxSeasonalScore = maxSeasonalScore;
            this.noteDesigner = noteDesigner;
        }

        public float DifficultyRating => difficultyRating;

        public DifficultyLevel DifficultyLevel => difficultyLevel;

        public bool IsRemaster => isRemaster;

        public TrackMetadata TrackMetadata => trackMetadata;

        public float MaxSeasonalScore => maxSeasonalScore;

        public string NoteDesigner => noteDesigner;
    }
}
