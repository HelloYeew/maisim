using System.IO;
using System.Linq;
using maisim.Game.Beatmaps;
using Microsoft.EntityFrameworkCore;
using osu.Framework.Logging;

namespace maisim.Game.Database
{
    /// <summary>
    /// EF Core database context for the local beamap database.
    /// </summary>
    public class BeatmapDatabaseContext : DbContext
    {
        public DbSet<TrackMetadata> TrackMetadatas { get; set; }
        public DbSet<Beatmap> Beatmaps { get; set; }
        public DbSet<BeatmapSet> BeatmapSets { get; set; }
        public string DatabasePath { get; set; }

        public BeatmapDatabaseContext()
        {

        }

        public void InitializeDatabase(string databasePath)
        {
            DatabasePath = Path.Combine(databasePath, "beatmaps.db");

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DatabasePath}");
        }
    }
}
