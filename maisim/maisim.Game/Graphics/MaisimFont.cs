using System;
using osu.Framework.Graphics.Sprites;

namespace maisim.Game.Graphics
{
    public class MaisimFont
    {
        public const float DEFAULT_SIZE = 25;

        public static FontUsage Default => GetFont();

        public static FontUsage Comfortaa => GetFont(Typeface.Comfortaa, weight : FontWeight.Regular);

        public static FontUsage GetFont(Typeface typeface = Typeface.Comfortaa, float size = DEFAULT_SIZE,
            FontWeight weight = FontWeight.Regular, bool italics = false, bool fixedWidth = false)
            => new FontUsage(GetFamilyString(typeface), size, GetWeightString(typeface, weight), getItalics(typeface, italics),
                fixedWidth);

        public enum Typeface
        {
            Comfortaa
        }

        private static bool getItalics(Typeface typeface, bool italics)
        {
            // This can add some exception when some of our font are not support italics
            switch (typeface)
            {
                case Typeface.Comfortaa:
                    return italics;
                default:
                    throw new ArgumentOutOfRangeException(nameof(typeface), typeface, null);
            }
        }

        public static string GetFamilyString(Typeface typeface)
        {
            switch (typeface)
            {
                case Typeface.Comfortaa:
                    return "Comfortaa";
                default:
                    throw new ArgumentOutOfRangeException(nameof(typeface), typeface, null);
            }
        }

        public static string GetWeightString(Typeface typeface, FontWeight weight)
        {
            return GetWeightString(GetFamilyString(typeface), weight);
        }

        public static string GetWeightString(string family, FontWeight weight) => weight.ToString();

        public enum FontWeight
        {
            /// <summary>
            /// Equivalent to weight 300.
            /// </summary>
            Light = 300,

            /// <summary>
            /// Equivalent to weight 400.
            /// </summary>
            Regular = 400,

            /// <summary>
            /// Equivalent to weight 500.
            /// </summary>
            Medium = 500,

            /// <summary>
            /// Equivalent to weight 600.
            /// </summary>
            SemiBold = 600,

            /// <summary>
            /// Equivalent to weight 700.
            /// </summary>
            Bold = 700,

            /// <summary>
            /// Equivalent to weight 900.
            /// </summary>
            Black = 900
        }
    }
}
