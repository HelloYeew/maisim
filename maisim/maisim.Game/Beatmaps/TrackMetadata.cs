using System.ComponentModel.DataAnnotations;

namespace maisim.Game.Beatmaps
{
    /// <summary>
    /// Class that provide the essential track metadata that's normally bind to the beatmap.
    /// </summary>
    /// <seealso cref="maisim.Game.Beatmaps.Beatmap"/>
    public class TrackMetadata
    {
        [Key]
        public int ID { get; set; }

        public BeatmapSet ConnectBeatmapSet { get; set; }

        public string Title { get; set; }

        public string TitleUnicode { get; set; }

        public string Artist { get; set; }

        public string ArtistUnicode { get; set; }

        public string Source { get; set; }

        public string CoverPath { get; set; }

        public float Bpm { get; set; }
    }
}
