namespace maisim.Game.Beatmaps
{
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
    }
}
