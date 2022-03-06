using maisim.Game.Beatmaps;
using maisim.Game.Component;
using maisim.Game.Scores;
using osu.Framework.Testing;
using osu.Framework.Graphics;
using osuTK;

namespace maisim.Game.Tests.Visual.Component
{
    public class TestSceneTrackCardCompare : GridTestScene
    {
        private readonly TrackMetadata mockTrackMetadata;

        private readonly Beatmap mockBeatmap;

        private readonly Score mockScore;

        public TestSceneTrackCardCompare() : base(1,2)
        {
            mockTrackMetadata = new TrackMetadata
            {
                Title = "Sukino Skill",
                Artist = "Wake Up, Girls!",
                Bpm = 120,
                CoverPath = "Test/sukino-skill.jpg"
            };
            mockBeatmap = new Beatmap
            {
                TrackMetadata = mockTrackMetadata,
                DifficultyLevel = DifficultyLevel.Expert,
                DifficultyRating = 8.2323f,
                IsRemaster = false,
                MaxSeasonalScore = 6969,
                NoteDesigner = "GIGACHAD"
            };
            mockScore = new Score
            {
                Beatmap = mockBeatmap,
                Tap = 10,
                Hold = 10,
                Slide = 10,
                Touch = 10,
                Accuracy = 99.65f,
                Rank = ScoreProcessor.CalculateRank(99.65f),
                Combo = 210,
                SeasonalScore = 5566
            };

            Cell(0, 0).Child = new TrackCard(mockBeatmap, mockScore)
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Scale = new Vector2(1)
            };
            Cell(0, 1).Child = new TrackCardFocused(mockBeatmap, mockScore)
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Scale = new Vector2(1)
            };
        }
    }
}
