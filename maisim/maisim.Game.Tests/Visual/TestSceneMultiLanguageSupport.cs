using maisim.Game.Beatmaps;
using maisim.Game.Component;
using maisim.Game.Scores;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Testing;
using osuTK;

namespace maisim.Game.Tests.Visual
{
    public class TestSceneMultiLanguageSupport : GridTestScene
    {
        public TestSceneMultiLanguageSupport() : base(2, 3)
        {
            var thaiMockBeatmap = new Beatmap
            {
                TrackMetadata = new TrackMetadata
                {
                    Title = "คืนความสุขให้ประเทศไทยพองๆ",
                    Artist = "ไม่รู้คับ ทดสอบๆ",
                    Bpm = 200,
                    CoverPath = "Test/test.jpg"
                },
                DifficultyLevel = DifficultyLevel.Expert,
                DifficultyRating = 6.3475f,
                IsRemaster = false,
                MaxSeasonalScore = 3456,
                NoteDesigner = "ลากหัวคมๆ"
            };

            var thaiMockScore = new Score
            {
                Beatmap = thaiMockBeatmap,
                Tap = 10,
                Hold = 10,
                Slide = 10,
                Touch = 10,
                Accuracy = 81.00f,
                Rank = ScoreProcessor.CalculateRank(81.00f),
                Combo = 453,
                SeasonalScore = 2556
            };

            Cell(0, 0).Children = new Drawable[]
            {
                new SpriteText
                {
                    Anchor = Anchor.TopLeft,
                    Origin = Anchor.TopLeft,
                    Text = "Thai"
                },
                new TrackCardFocused(thaiMockBeatmap, thaiMockScore)
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Scale = new Vector2(0.7f)
                }
            };

            var japaneseMockBeatmap = new Beatmap
            {
                TrackMetadata = new TrackMetadata
                {
                    Title = "エンドレス・てゐマパーク",
                    Artist = "とろ美",
                    Bpm = 120,
                    CoverPath = "Test/tewi.jpg"
                },
                DifficultyLevel = DifficultyLevel.Advanced,
                DifficultyRating = 5.21f,
                IsRemaster = true,
                MaxSeasonalScore = 865,
                NoteDesigner = "オモイヨシノ"
            };

            var japaneseMockScore = new Score
            {
                Beatmap = japaneseMockBeatmap,
                Tap = 10,
                Hold = 10,
                Slide = 10,
                Touch = 10,
                Accuracy = 94.00f,
                Rank = ScoreProcessor.CalculateRank(94.00f),
                Combo = 650,
                SeasonalScore = 350
            };

            Cell(0, 1).Children = new Drawable[]
            {
                new SpriteText
                {
                    Anchor = Anchor.TopLeft,
                    Origin = Anchor.TopLeft,
                    Text = "Japanese"
                },
                new TrackCardFocused(japaneseMockBeatmap, japaneseMockScore)
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Scale = new Vector2(0.7f)
                }
            };
        }
    }
}
