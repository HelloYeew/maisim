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

        public static string DATABASE_NAME = "beatmaps.db";

        public string DatabasePath { get; set; }

        public BeatmapDatabaseContext(string databasePath)
        {
            DatabasePath = Path.Join(databasePath, DATABASE_NAME);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DatabasePath}");
        }
    }
}
