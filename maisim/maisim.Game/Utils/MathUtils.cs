using System;
using osuTK;

namespace maisim.Game.Utils
{
    public class MathUtils
    {
        /// <summary>
        /// Return distance between two <see cref="Vector2"/> points.
        /// </summary>
        /// <param name="point1">First position in <see cref="Vector2"/></param>
        /// <param name="point2">Second position in <see cref="Vector2"/></param>
        /// <returns>Distance between these two position</returns>
        public static float CalculateDistance(Vector2 point1, Vector2 point2)
        {
            return (float)Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2));
        }
    }
}
