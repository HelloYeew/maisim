using System.IO;
using osu.Framework.Logging;

namespace maisim.Game.Database
{
    /// <summary>
    /// Abstract class that's expand <see cref="BeatmapDatabaseContext"/>
    /// </summary>
    public class BeatmapDatabaseContextFactory : BeatmapDatabaseContext
    {
        public BeatmapDatabaseContextFactory(string databasePath) : base(databasePath)
        {
            InitializeDatabase();
        }

        public void InitializeDatabase()
        {
            DatabasePath = Path.Combine(DatabasePath, "beatmaps.db");

            // Find that is the database exists, if not, create it.
            if (Database.EnsureCreated())
            {
                Logger.Log($"Beatmap database not found, creating new one at {DatabasePath}", LoggingTarget.Database);
            } else
            {
                Logger.Log($"Beatmap database found at {DatabasePath}", LoggingTarget.Database);
                // TODO: Auto migrate database when new version is released.
            }
        }
    }
}
