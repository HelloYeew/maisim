using System;
using maisim.Game.Beatmaps;
using maisim.Game.Component;
using osu.Framework.Extensions.Color4Extensions;
using osuTK.Graphics;

namespace maisim.Game.Graphics
{
    public class MaisimColour
    {
        /// <summary>
        /// Get the colour for <see cref="TrackCard"/> and <see cref="TrackCardFocused"/> background colour.
        /// </summary>
        /// <param name="difficultyRating"><see cref="DifficultyRating"/> value</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">Throw if the value is not right.</exception>

        public static Color4 GetDifficultyColor(DifficultyRating difficultyRating)
        {
            switch (difficultyRating)
            {
                case DifficultyRating.Basic:
                    return Color4Extensions.FromHex("6ed43e");

                case DifficultyRating.Advanced:
                    return Color4Extensions.FromHex("f7b807");

                case DifficultyRating.Expert:
                    return Color4Extensions.FromHex("ff828d");

                case DifficultyRating.Master:
                    return Color4Extensions.FromHex("a051dc");

                case DifficultyRating.Remaster:
                    return Color4.White;

                default:
                    throw new ArgumentOutOfRangeException(nameof(difficultyRating));
            }
        }
    }
}
