using System;
using maisim.Game.Beatmaps;
using osu.Framework.Extensions.Color4Extensions;
using osuTK.Graphics;

namespace maisim.Game.Graphics
{
    /// <summary>
    /// The class that contain all the colors values used in the game elements.
    /// </summary>
    public class MaisimColour
    {
        public static Color4 Gray(float amt) => new Color4(amt, amt, amt, 1f);
        public static Color4 Gray(byte amt) => new Color4(amt, amt, amt, 255);

        /// <summary>
        /// Get the colour for <see cref="DifficultyLevel"/> colour.
        /// </summary>
        /// <param name="difficultyLevel"><see cref="DifficultyLevel"/> value</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">Throw if the value is not in the scope.</exception>
        public static Color4 GetDifficultyColor(DifficultyLevel difficultyLevel)
        {
            switch (difficultyLevel)
            {
                case DifficultyLevel.Basic:
                    return Color4Extensions.FromHex("6ed43e");

                case DifficultyLevel.Advanced:
                    return Color4Extensions.FromHex("f7b807");

                case DifficultyLevel.Expert:
                    return Color4Extensions.FromHex("ff828d");

                case DifficultyLevel.Master:
                    return Color4Extensions.FromHex("a051dc");

                default:
                    throw new ArgumentOutOfRangeException(nameof(difficultyLevel));
            }
        }

        public static Color4 BackButtonColor => Color4Extensions.FromHex("205ac8");

        public static Color4 SongSelectionContainerColor => Color4Extensions.FromHex("d9d9d9");

        public static Color4 SongSelectionContainerBorderColor => Color4Extensions.FromHex("eaea00");

        public static Color4 NowPlayingArtistColor => Color4Extensions.FromHex("b8b8b8");

        public static Color4 NowPlayingProgressBarFillColor => Color4Extensions.FromHex("878787");
        public static Color4 NowPlayingProgressBarBackgroundColor => Color4Extensions.FromHex("d9d9d9");
    }
}
