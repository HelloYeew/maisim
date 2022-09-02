using System;

namespace maisim.Game.Utils
{
    /// <summary>
    /// Extensions methods for random number generators.
    /// </summary>
    public static class RandomExtensions
    {
        /// <summary>
        /// Return a random <see cref="double"/> between target min and max <see cref="double"/>.
        /// </summary>
        /// <param name="random">A <see cref="Random"/> instance.</param>
        /// <param name="min">The minimum <see cref="double"/>.</param>
        /// <param name="max">The maximum <see cref="double"/>.</param>
        /// <returns>A random <see cref="double"/> between target min and max <see cref="double"/>.</returns>
        public static double NextDoubleInRange(this Random random, double min, double max) => (random.NextDouble() * (max - min)) + min;

        /// <summary>
        /// Return a random <see cref="float"/> between target min and max <see cref="float"/>.
        /// </summary>
        /// <param name="random">A <see cref="Random"/> instance.</param>
        /// <param name="min">The minimum <see cref="float"/>.</param>
        /// <param name="max">The maximum <see cref="float"/>.</param>
        /// <returns>A random <see cref="float"/> between target min and max <see cref="float"/>.</returns>
        public static float NextFloatInRange(this Random random, float min, float max) => ((float)random.NextDouble() * (max - min)) + min;

        /// <summary>
        /// Return a random <see cref="int"/> between target min and max <see cref="int"/>.
        /// </summary>
        /// <param name="random">A <see cref="Random"/> instance.</param>
        /// <param name="min">The minimum <see cref="int"/>.</param>
        /// <param name="max">The maximum <see cref="int"/>.</param>
        /// <returns>A random <see cref="int"/> between target min and max <see cref="int"/>.</returns>
        public static int NextInRange(this Random random, int min, int max) => random.Next() % (max - min) + min;
    }

}
