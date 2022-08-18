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

        public BeatmapDatabaseContext(string databasePath)
        {
            DatabasePath = databasePath;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DatabasePath}");
        }
    }
}
