using maisim.Game.Beatmaps;

namespace maisim.Game.Scores
{
    /// <summary>
    /// Class include the structure of the score object.
    /// </summary>
    public class Score
    {
        public Beatmap Beatmap { get; set; }

        public int Tap { get; set; }

        public int Hold { get; set; }

        public int Slide { get; set; }

        public int Touch { get; set; }

        public float Accuracy { get; set; }

        public ScoreRank Rank { get; set; }

        public int Combo { get; set; }

        public int SeasonalScore { get; set; }
    }
}
