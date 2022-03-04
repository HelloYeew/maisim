using System;
using maisim.Game.Beatmaps;
using osu.Framework.Localisation;

namespace maisim.Game.Scores
{
    public class Score
    {
        private readonly Beatmap beatmap;
        private readonly int tap;
        private readonly int hold;
        private readonly int slide;
        private readonly int touch;
        private readonly float accuracy;
        private readonly int combo;
        private readonly int seasonalScore;

        public Score(int tap, int hold, int slide, int touch, float accuracy, int combo, int seasonalScore)
        {
            this.tap = tap;
            this.hold = hold;
            this.slide = slide;
            this.touch = touch;
            this.accuracy = accuracy;
            this.combo = combo;
            this.seasonalScore = seasonalScore;
        }

        public Beatmap Beatmap => beatmap;

        public int Tap => tap;

        public int Hold => hold;

        public int Slide => slide;

        public int Touch => touch;

        public float Accuracy => accuracy;

        public int Combo => combo;

        public int SeasonalScore => seasonalScore;

        public ScoreRank CalculateRank()
        {
            // TODO: If the score calculation function is implement we need to move it there.
            if (accuracy >= 100.5f)
            {
                return ScoreRank.SSSPlus;
            }

            if (accuracy >= 100 && accuracy <= 100.49f)
            {
                return ScoreRank.SSS;
            }

            if (accuracy >= 99.5f && accuracy <= 99.99f)
            {
                return ScoreRank.SSPlus;
            }

            if (accuracy >= 99 && accuracy <= 99.49f)
            {
                return ScoreRank.SS;
            }

            if (accuracy >= 98 && accuracy <= 98.99f)
            {
                return ScoreRank.SPlus;
            }

            if (accuracy >= 97 && accuracy <= 97.99f)
            {
                return ScoreRank.S;
            }

            if (accuracy >= 94 && accuracy <= 96.99f)
            {
                return ScoreRank.AAA;
            }

            if (accuracy >= 90 && accuracy <= 93.99f)
            {
                return ScoreRank.AA;
            }

            if (accuracy >= 80 && accuracy <= 89.99f)
            {
                return ScoreRank.A;
            }

            if (accuracy >= 75 && accuracy <= 79.99f)
            {
                return ScoreRank.BBB;
            }

            if (accuracy >= 70 && accuracy <= 74.99f)
            {
                return ScoreRank.BB;
            }

            if (accuracy >= 60 && accuracy <= 69.99f)
            {
                return ScoreRank.B;
            }

            if (accuracy >= 50 && accuracy <= 59.99f)
            {
                return ScoreRank.C;
            }

            if (accuracy <= 49.99f)
            {
                return ScoreRank.D;
            }

            throw new ArgumentOutOfRangeException(nameof(accuracy));
        }
    }
}
