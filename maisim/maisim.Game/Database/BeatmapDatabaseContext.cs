using System;
using System.IO;
using maisim.Game.Beatmaps;
using Microsoft.EntityFrameworkCore;

namespace maisim.Game.Database
{
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
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DatabasePath}");
        }
    }
}
