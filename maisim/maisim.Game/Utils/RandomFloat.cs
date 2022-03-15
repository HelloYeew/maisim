using System;

namespace maisim.Game.Utils
{
    /// <summary>
    /// A class represent as a random number generator with limit max and min value.
    /// </summary>
    public class RandomFloat
    {
        private double min;

        private double max;

        private double range;

        private Random random = new Random();

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomFloat"/> class.
        /// </summary>
        /// <param name="min">A min number in random range</param>
        /// <param name="max">A max number in random range</param>
        public RandomFloat(double min, double max)
        {
            this.min = min;
            this.max = max;
            range = max - min;
        }

        /// <summary>
        /// Return a random float in range min and max.
        /// </summary>
        /// <returns></returns>
        public float GetRandom()
        {
            double sample = random.NextDouble();
            double scaled = (sample * range) + min;
            return (float)scaled;
        }
    }
}
