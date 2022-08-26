using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace maisim.Game.Beatmaps
{
    public class BeatmapSet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int DatabaseID { get; set; }

        public TrackMetadata TrackMetadata { get; set; }

        public string Creator { get; set; }

        public int BeatmapSetID { get; set; }

        public List<Beatmap> Beatmaps { get; set; }

        public string AudioFileName { get; set; }

        public int PreviewTime { get; set; }

        public override string ToString()
        {
            return $"({BeatmapSetID}) {TrackMetadata.Title} - {TrackMetadata.Artist}";
        }
    }
}
