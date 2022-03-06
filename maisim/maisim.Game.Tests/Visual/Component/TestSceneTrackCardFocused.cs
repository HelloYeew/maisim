using maisim.Game.Beatmaps;
using maisim.Game.Component;
using maisim.Game.Scores;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osuTK;
using osuTK.Graphics;

namespace maisim.Game.Tests.Visual.Component
{
    public class TestSceneTrackCardFocused : maisimTestScene
    {
        private readonly TrackMetadata mockTrackMetadata;

        private readonly Beatmap mockBeatmap;

        private readonly Score mockScore;

        public TestSceneTrackCardFocused()
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

            Child = new Container
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Size = new Vector2(500,500),
                Masking = true,
                Children = new Drawable[]
                {
                    new Box
                    {
                        RelativeSizeAxes = Axes.Both,
                        Colour = Color4.Black
                    },
                    new TrackCardFocused(mockBeatmap, mockScore)
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                    }
                }
            };
        }
    }
}
