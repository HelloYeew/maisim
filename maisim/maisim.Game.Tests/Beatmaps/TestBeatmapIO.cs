﻿using System.Collections.Generic;
using maisim.Game.Beatmaps;
using maisim.Game.Component.Gameplay.Notes;
using maisim.Game.Database;
using NUnit.Framework;

namespace maisim.Game.Tests.Beatmaps
{
    public class TestBeatmapIO
    {
        private BeatmapSet mockBeatmapSet;

        private TrackMetadata mockTrackMetadata;

        private Beatmap mockBeatmapOne;

        private Beatmap mockBeatmapTwo;

        private List<DrawableNote> mockNoteList;

        public TestBeatmapIO()
        {
            var database = new BeatmapDatabaseContext();

            mockBeatmapSet = new BeatmapSet()
            {
                Creator = "Yeew",
                BeatmapSetID = 1,
                AudioFileName = "test.mp3",
                PreviewTime = 555
            };

            mockTrackMetadata = new TrackMetadata()
            {
                Title = "Lemon",
                TitleUnicode = "Lemon",
                Artist = "Kenshi Yonezu",
                ArtistUnicode = "米津玄師",
                Source = "sauce",
                Bpm = 80,
                CoverPath = "lemon.jpg",
                ConnectBeatmapSet = mockBeatmapSet
            };

            mockBeatmapSet.TrackMetadata = mockTrackMetadata;

            mockBeatmapOne = new Beatmap
            {
                TrackMetadata = mockTrackMetadata,
                DifficultyLevel = DifficultyLevel.Basic,
                DifficultyRating = 10,
                NoteDesigner = "Yeew",
                BeatmapID = 1
            };

            mockBeatmapTwo = new Beatmap
            {
                TrackMetadata = mockTrackMetadata,
                DifficultyLevel = DifficultyLevel.Advanced,
                DifficultyRating = 10,
                NoteDesigner = "Yeew",
                BeatmapID = 2
            };

            mockBeatmapSet.Beatmaps = new List<Beatmap>
            {
                mockBeatmapOne,
                mockBeatmapTwo
            };

            database.BeatmapSets.Add(mockBeatmapSet);

            database.TrackMetadatas.Add(mockTrackMetadata);

            database.Beatmaps.Add(mockBeatmapOne);
            database.Beatmaps.Add(mockBeatmapTwo);

            mockNoteList = new List<DrawableNote>()
            {
                new DrawableTapNote()
                {
                    Lane = NoteLane.Lane1,
                    TargetTime = 5232
                },
                new DrawableTapNote()
                {
                    Lane = NoteLane.Lane2,
                    TargetTime = 23230
                },
                new DrawableTapNote()
                {
                    Lane = NoteLane.Lane4,
                    TargetTime = 44440
                },
                new DrawableTapNote()
                {
                    Lane = NoteLane.Lane3,
                    TargetTime = 55445
                },
            };
        }

        [Test]
        public void TestEncodeBeatmap()
        {
            BeatmapEncoder encoder = new BeatmapEncoder(mockBeatmapSet, mockTrackMetadata);
            encoder.AddBeatmap(mockBeatmapOne, mockNoteList);
            encoder.AddBeatmap(mockBeatmapTwo, mockNoteList);
            encoder.Encode();
        }
    }
}