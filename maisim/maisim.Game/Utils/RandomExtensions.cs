using System;

namespace maisim.Game.Utils
{
    /// <summary>
    /// Extensions methods for random number generators.
    /// </summary>
    public static class RandomExtensions
    {
        public static double NextDoubleInRange(this Random random, double min, double max) => (random.NextDouble() * (max - min)) + min;

        public static float NextFloatInRange(this Random random, float min, float max) => ((float)random.NextDouble() * (max - min)) + min;

        public static int NextInRange(this Random random, int min, int max) => random.Next() % (max - min) + min;
    }

}
