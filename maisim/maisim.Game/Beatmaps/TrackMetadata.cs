namespace maisim.Game.Beatmaps
{
    /// <summary>
    /// Class that provide the essential track metadata that's normally bind to the beatmap.
    /// </summary>
    /// <seealso cref="maisim.Game.Beatmaps.Beatmap"/>
    public class TrackMetadata
    {
        public string Title { get; set; }

        public string Artist { get; set; }

        public string CoverPath { get; set; }

        public float Bpm { get; set; }
    }
}
