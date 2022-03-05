namespace maisim.Game.Beatmaps
{
    /// <summary>
    /// Class that provide the essential track metadata that's normally bind to the beatmap.
    /// </summary>
    /// <seealso cref="maisim.Game.Beatmaps.Beatmap"/>
    public class TrackMetadata
    {
        public TrackMetadata(string title, string artist, string coverPath, float bpm)
        {
            Title = title;
            Artist = artist;
            CoverPath = coverPath;
            Bpm = bpm;
        }

        public string Title { get; set; }

        public string Artist { get; set; }

        public string CoverPath { get; set; }

        public float Bpm { get; set; }
    }
}
