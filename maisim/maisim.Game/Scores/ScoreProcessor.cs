using System;

namespace maisim.Game.Scores
{
    public class ScoreProcessor
    {
        public ScoreRank CalculateRank(float accuracy)
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
