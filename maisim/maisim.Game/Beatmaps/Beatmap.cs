namespace maisim.Game.Beatmaps
{
    /// <summary>
    /// Class that represents a beatmap that includes all the information needed on beatmap.
    /// </summary>
    public class Beatmap
    {
        // TODO: Implement SongSet when it's available

        public float DifficultyRating { get; set; }

        public DifficultyLevel DifficultyLevel { get; set; }

        public bool IsRemaster { get; set; }

        public TrackMetadata TrackMetadata { get; set; }

        public float MaxSeasonalScore { get; set; }

        public string NoteDesigner { get; set; }
    }
}
