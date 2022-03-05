using System;
using maisim.Game.Beatmaps;

namespace maisim.Game.Scores
{
    /// <summary>
    /// Class include the structure of the score object.
    /// </summary>
    public class Score
    {
        public Score(Beatmap beatmap, int tap, int hold, int slide, int touch, float accuracy, int combo, int seasonalScore)
        {
            Beatmap = beatmap;
            Tap = tap;
            Hold = hold;
            Slide = slide;
            Touch = touch;
            Accuracy = accuracy;
            Combo = combo;
            SeasonalScore = seasonalScore;
        }

        public Beatmap Beatmap { get; set; }

        public int Tap { get; set; }

        public int Hold { get; set; }

        public int Slide { get; set; }

        public int Touch { get; set; }

        public float Accuracy { get; set; }

        public int Combo { get; set; }

        public int SeasonalScore { get; set; }

        public ScoreRank CalculateRank()
        {
            // TODO: If the score calculation function is implement we need to move it there.
            if (Accuracy >= 100.5f)
            {
                return ScoreRank.SSSPlus;
            }

            if (Accuracy >= 100 && Accuracy <= 100.49f)
            {
                return ScoreRank.SSS;
            }

            if (Accuracy >= 99.5f && Accuracy <= 99.99f)
            {
                return ScoreRank.SSPlus;
            }

            if (Accuracy >= 99 && Accuracy <= 99.49f)
            {
                return ScoreRank.SS;
            }

            if (Accuracy >= 98 && Accuracy <= 98.99f)
            {
                return ScoreRank.SPlus;
            }

            if (Accuracy >= 97 && Accuracy <= 97.99f)
            {
                return ScoreRank.S;
            }

            if (Accuracy >= 94 && Accuracy <= 96.99f)
            {
                return ScoreRank.AAA;
            }

            if (Accuracy >= 90 && Accuracy <= 93.99f)
            {
                return ScoreRank.AA;
            }

            if (Accuracy >= 80 && Accuracy <= 89.99f)
            {
                return ScoreRank.A;
            }

            if (Accuracy >= 75 && Accuracy <= 79.99f)
            {
                return ScoreRank.BBB;
            }

            if (Accuracy >= 70 && Accuracy <= 74.99f)
            {
                return ScoreRank.BB;
            }

            if (Accuracy >= 60 && Accuracy <= 69.99f)
            {
                return ScoreRank.B;
            }

            if (Accuracy >= 50 && Accuracy <= 59.99f)
            {
                return ScoreRank.C;
            }

            if (Accuracy <= 49.99f)
            {
                return ScoreRank.D;
            }

            throw new ArgumentOutOfRangeException(nameof(Accuracy));
        }
    }
}
