using System;

namespace maisim.Game.Scores
{
    /// <summary>
    /// Class that represent as the score calculator.
    /// </summary>
    public class ScoreProcessor
    {
        public static ScoreRank CalculateRank(float accuracy)
        {
            if (accuracy >= 100.5f)
            {
                return ScoreRank.SSSPlus;
            }

            if (accuracy >= 100)
            {
                return ScoreRank.SSS;
            }

            if (accuracy >= 99.5f)
            {
                return ScoreRank.SSPlus;
            }

            if (accuracy >= 99)
            {
                return ScoreRank.SS;
            }

            if (accuracy >= 98)
            {
                return ScoreRank.SPlus;
            }

            if (accuracy >= 97)
            {
                return ScoreRank.S;
            }

            if (accuracy >= 94)
            {
                return ScoreRank.AAA;
            }

            if (accuracy >= 90)
            {
                return ScoreRank.AA;
            }

            if (accuracy >= 80)
            {
                return ScoreRank.A;
            }

            if (accuracy >= 75)
            {
                return ScoreRank.BBB;
            }

            if (accuracy >= 70)
            {
                return ScoreRank.BB;
            }

            if (accuracy >= 60)
            {
                return ScoreRank.B;
            }

            if (accuracy >= 50)
            {
                return ScoreRank.C;
            }

            return ScoreRank.D;

        }
    }
}
