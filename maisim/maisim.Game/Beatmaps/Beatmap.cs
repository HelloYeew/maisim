namespace maisim.Game.Beatmaps
{
    public class Beatmap
    {
        private readonly float difficulty;
        private readonly bool isRemaster;
        private readonly TrackMetadata trackMetadata;
        private readonly float maxSeasonalScore;
        private readonly string noteDesigner;

        // TODO: Implement SongSet when it's available

        public Beatmap(TrackMetadata trackMetadata, float difficulty = 0, bool isRemaster = false, float maxSeasonalScore = 0, string noteDesigner = "None")
        {
            this.trackMetadata = trackMetadata;
            this.difficulty = difficulty;
            this.isRemaster = isRemaster;
            this.maxSeasonalScore = maxSeasonalScore;
            this.noteDesigner = noteDesigner;
        }
    }
}
