using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace maisim.Game.Beatmaps
{
    /// <summary>
    /// Class that provide the essential track metadata that's normally bind to the beatmap.
    /// </summary>
    /// <seealso cref="maisim.Game.Beatmaps.Beatmap"/>
    public class TrackMetadata
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }

        [ForeignKey("BeatmapSet")]
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
