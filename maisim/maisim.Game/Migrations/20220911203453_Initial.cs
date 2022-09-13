using Microsoft.EntityFrameworkCore.Migrations;

namespace maisim.Game.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BeatmapSets",
                columns: table => new
                {
                    DatabaseID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Creator = table.Column<string>(type: "TEXT", nullable: true),
                    BeatmapSetID = table.Column<int>(type: "INTEGER", nullable: false),
                    AudioFileName = table.Column<string>(type: "TEXT", nullable: true),
                    PreviewTime = table.Column<int>(type: "INTEGER", nullable: false),
                    UseLocalFile = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeatmapSets", x => x.DatabaseID);
                });

            migrationBuilder.CreateTable(
                name: "TrackMetadatas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BeatmapSet = table.Column<int>(type: "INTEGER", nullable: true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    TitleUnicode = table.Column<string>(type: "TEXT", nullable: true),
                    Artist = table.Column<string>(type: "TEXT", nullable: true),
                    ArtistUnicode = table.Column<string>(type: "TEXT", nullable: true),
                    Source = table.Column<string>(type: "TEXT", nullable: true),
                    CoverPath = table.Column<string>(type: "TEXT", nullable: true),
                    Bpm = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackMetadatas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TrackMetadatas_BeatmapSets_BeatmapSet",
                        column: x => x.BeatmapSet,
                        principalTable: "BeatmapSets",
                        principalColumn: "DatabaseID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Beatmaps",
                columns: table => new
                {
                    DatabaseID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BeatmapID = table.Column<int>(type: "INTEGER", nullable: false),
                    BeatmapSetDatabaseID = table.Column<int>(type: "INTEGER", nullable: true),
                    DifficultyRating = table.Column<float>(type: "REAL", nullable: false),
                    DifficultyLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    TrackMetadataID = table.Column<int>(type: "INTEGER", nullable: true),
                    NoteDesigner = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beatmaps", x => x.DatabaseID);
                    table.ForeignKey(
                        name: "FK_Beatmaps_BeatmapSets_BeatmapSetDatabaseID",
                        column: x => x.BeatmapSetDatabaseID,
                        principalTable: "BeatmapSets",
                        principalColumn: "DatabaseID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Beatmaps_TrackMetadatas_TrackMetadataID",
                        column: x => x.TrackMetadataID,
                        principalTable: "TrackMetadatas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beatmaps_BeatmapSetDatabaseID",
                table: "Beatmaps",
                column: "BeatmapSetDatabaseID");

            migrationBuilder.CreateIndex(
                name: "IX_Beatmaps_TrackMetadataID",
                table: "Beatmaps",
                column: "TrackMetadataID");

            migrationBuilder.CreateIndex(
                name: "IX_TrackMetadatas_BeatmapSet",
                table: "TrackMetadatas",
                column: "BeatmapSet",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beatmaps");

            migrationBuilder.DropTable(
                name: "TrackMetadatas");

            migrationBuilder.DropTable(
                name: "BeatmapSets");
        }
    }
}
