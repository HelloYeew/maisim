using System;
using maisim.Game.Screen.Gameplay;
using osuTK;

namespace maisim.Game.Component.Gameplay.Notes
{
    /// <summary>
    /// Represent a lane value for note type that spawn on the specified lane.
    /// </summary>
    public enum NoteLane
    {
        Lane1,
        Lane2,
        Lane3,
        Lane4,
        Lane5,
        Lane6,
        Lane7,
        Lane8
    }

    /// <summary>
    /// Extension and some tool for convert <see cref="NoteLane"/> to usable values.
    /// </summary>
    public static class NoteLaneExtension
    {
        /// <summary>
        /// Return the lane angle for the specified lane.
        /// </summary>
        /// <param name="lane">A specified <see cref="NoteLane"/></param>
        /// <returns>The lane angle</returns>
        public static float GetAngle(NoteLane lane)
        {
            switch (lane)
            {
                case NoteLane.Lane1:
                    return 22.5f;
                case NoteLane.Lane2:
                    return 67.5f;
                case NoteLane.Lane3:
                    return 112.5f;
                case NoteLane.Lane4:
                    return 157.5f;
                case NoteLane.Lane5:
                    return 202.5f;
                case NoteLane.Lane6:
                    return 247.5f;
                case NoteLane.Lane7:
                    return 292.5f;
                case NoteLane.Lane8:
                    return 337.5f;
                default:
                    throw new ArgumentOutOfRangeException(nameof(lane));
            }
        }

        /// <summary>
        /// Return the lane's spawner position for the specified lane.
        /// </summary>
        /// <param name="lane">A specified <see cref="NoteLane"/></param>
        /// <returns>Spawner position in <see cref="Vector2"/> format.</returns>
        public static Vector2 GetSpawnerPosition(NoteLane lane)
        {
            return new Vector2(
                -(Playfield.SPAWNER_MULTIPLIER * (float)Math.Cos((GetAngle(lane) + 90f) * (float)(Math.PI / 180))),
                -(Playfield.SPAWNER_MULTIPLIER * (float)Math.Sin((GetAngle(lane) + 90f) * (float)(Math.PI / 180)))
            );
        }

        /// <summary>
        /// Return the lane's sensor position for the specified lane.
        /// </summary>
        /// <param name="lane">A specified <see cref="NoteLane"/></param>
        /// <returns>Sensor position in <see cref="Vector2"/> format.</returns>
        public static Vector2 GetSensorPosition(NoteLane lane)
        {
            return new Vector2(
                -(MaisimRing.LANE_MULTIPLIER * (float)Math.Cos((GetAngle(lane) + 90f) * (float)(Math.PI / 180))),
                -(MaisimRing.LANE_MULTIPLIER * (float)Math.Sin((GetAngle(lane) + 90f) * (float)(Math.PI / 180)))
            );
        }
    }
}
