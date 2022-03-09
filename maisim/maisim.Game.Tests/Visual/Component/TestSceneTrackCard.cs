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
    public class TestSceneTrackCard : maisimTestScene
    {
        public TestSceneTrackCard()
        {
            var mockBeatmap = new Beatmap
            {
                TrackMetadata = new TrackMetadata
                {
                    Title = "Sukino Skill",
                    Artist = "Wake Up, Girls!",
                    Bpm = 120,
                    CoverPath = "Test/sukino-skill.jpg"
                },
                DifficultyLevel = DifficultyLevel.Expert,
                DifficultyRating = 8.2323f,
                IsRemaster = false,
                MaxSeasonalScore = 6969,
                NoteDesigner = "GIGACHAD"
            };
            var mockScore = new Score
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
                    new TrackCard(mockBeatmap, mockScore)
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                    }
                }
            };
        }
    }
}
