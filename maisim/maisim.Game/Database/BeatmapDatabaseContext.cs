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

        public const string DATABASE_NAME = "beatmaps.db";
        public DbSet<Beatmap> Beatmaps { get; set; }
        public DbSet<BeatmapSet> BeatmapSets { get; set; }

        public string DatabasePath =>
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "maisim", DATABASE_NAME);

        public BeatmapDatabaseContext()
        {

        }

        public void InitializeDatabase()
        {
            Database.Migrate();
            Logger.Log($"Initialized database at {DatabasePath}", LoggingTarget.Database);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DatabasePath}");
        }
    }
}
