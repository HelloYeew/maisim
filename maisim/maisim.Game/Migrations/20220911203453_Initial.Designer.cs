﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using maisim.Game.Database;

namespace maisim.Game.Migrations
{
    [DbContext(typeof(BeatmapDatabaseContext))]
    [Migration("20220911203453_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("maisim.Game.Beatmaps.Beatmap", b =>
                {
                    b.Property<int>("DatabaseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BeatmapID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BeatmapSetDatabaseID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DifficultyLevel")
                        .HasColumnType("INTEGER");

                    b.Property<float>("DifficultyRating")
                        .HasColumnType("REAL");

                    b.Property<string>("NoteDesigner")
                        .HasColumnType("TEXT");

                    b.Property<int?>("TrackMetadataID")
                        .HasColumnType("INTEGER");

                    b.HasKey("DatabaseID");

                    b.HasIndex("BeatmapSetDatabaseID");

                    b.HasIndex("TrackMetadataID");

                    b.ToTable("Beatmaps");
                });

            modelBuilder.Entity("maisim.Game.Beatmaps.BeatmapSet", b =>
                {
                    b.Property<int>("DatabaseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AudioFileName")
                        .HasColumnType("TEXT");

                    b.Property<int>("BeatmapSetID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Creator")
                        .HasColumnType("TEXT");

                    b.Property<int>("PreviewTime")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("UseLocalFile")
                        .HasColumnType("INTEGER");

                    b.HasKey("DatabaseID");

                    b.ToTable("BeatmapSets");
                });

            modelBuilder.Entity("maisim.Game.Beatmaps.TrackMetadata", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Artist")
                        .HasColumnType("TEXT");

                    b.Property<string>("ArtistUnicode")
                        .HasColumnType("TEXT");

                    b.Property<int?>("BeatmapSet")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Bpm")
                        .HasColumnType("REAL");

                    b.Property<string>("CoverPath")
                        .HasColumnType("TEXT");

                    b.Property<string>("Source")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<string>("TitleUnicode")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("BeatmapSet")
                        .IsUnique();

                    b.ToTable("TrackMetadatas");
                });

            modelBuilder.Entity("maisim.Game.Beatmaps.Beatmap", b =>
                {
                    b.HasOne("maisim.Game.Beatmaps.BeatmapSet", "BeatmapSet")
                        .WithMany("Beatmaps")
                        .HasForeignKey("BeatmapSetDatabaseID");

                    b.HasOne("maisim.Game.Beatmaps.TrackMetadata", "TrackMetadata")
                        .WithMany()
                        .HasForeignKey("TrackMetadataID");

                    b.Navigation("BeatmapSet");

                    b.Navigation("TrackMetadata");
                });

            modelBuilder.Entity("maisim.Game.Beatmaps.TrackMetadata", b =>
                {
                    b.HasOne("maisim.Game.Beatmaps.BeatmapSet", "ConnectBeatmapSet")
                        .WithOne("TrackMetadata")
                        .HasForeignKey("maisim.Game.Beatmaps.TrackMetadata", "BeatmapSet");

                    b.Navigation("ConnectBeatmapSet");
                });

            modelBuilder.Entity("maisim.Game.Beatmaps.BeatmapSet", b =>
                {
                    b.Navigation("Beatmaps");

                    b.Navigation("TrackMetadata");
                });
#pragma warning restore 612, 618
        }
    }
}