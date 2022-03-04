using System;

namespace maisim.Game.Scores
{
    public enum ScoreRank
    {
        SSSPlus,
        SSS,
        SSPlus,
        SS,
        SPlus,
        S,
        AAA,
        AA,
        A,
        BBB,
        BB,
        B,
        C,
        D
    }

    public static class ScoreRankExtensions
    {
        public static string ToString(this ScoreRank rank)
        {
            switch (rank)
            {
                case ScoreRank.SSSPlus:
                    return "SSS+";
                case ScoreRank.SSS:
                    return "SSS";
                case ScoreRank.SSPlus:
                    return "SS+";
                case ScoreRank.SS:
                    return "SS";
                case ScoreRank.SPlus:
                    return "S+";
                case ScoreRank.S:
                    return "S";
                case ScoreRank.AAA:
                    return "AAA";
                case ScoreRank.AA:
                    return "AA";
                case ScoreRank.A:
                    return "A";
                case ScoreRank.BBB:
                    return "BBB";
                case ScoreRank.BB:
                    return "BB";
                case ScoreRank.B:
                    return "B";
                case ScoreRank.C:
                    return "C";
                case ScoreRank.D:
                    return "D";
                default:
                    throw new ArgumentOutOfRangeException(nameof(rank));
            }
        }
    }
}
