using System;
using System.IO;
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
            // Get the database path in %APPDATA%\
            DatabasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "maisim", "beatmaps.db");

            // Find that is the database exists, if not, create it.
            if (!File.Exists(DatabasePath))
            {
                Logger.Log($"Beatmap database not found, creating new one at {DatabasePath}", LoggingTarget.Database);
                Database.EnsureCreated();
            } else
            {
                Logger.Log($"Beatmap database found at {DatabasePath}", LoggingTarget.Database);
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DatabasePath}");
        }
    }
}
