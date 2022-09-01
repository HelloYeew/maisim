using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace maisim.Game.Beatmaps
{
    /// <summary>
    /// Class that represents a beatmap that includes all the information needed on beatmap.
    /// </summary>
    public class Beatmap
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int DatabaseID { get; set; }

        public int BeatmapID { get; set; }

        public BeatmapSet BeatmapSet { get; set; }

        public float DifficultyRating { get; set; }

        public DifficultyLevel DifficultyLevel { get; set; }

        public TrackMetadata TrackMetadata { get; set; }

        public string NoteDesigner { get; set; }

        public override string ToString()
        {
            return $"{BeatmapID} - {DifficultyRating} stars ({DifficultyLevel}) by {NoteDesigner}";
        }
    }
}
