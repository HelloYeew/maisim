using System;
using System.IO;

namespace maisim.Game.Store
{
    public class MaisimFilePath
    {
        public static string BeatmapFilePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "maisim", "beatmaps");
    }
}
