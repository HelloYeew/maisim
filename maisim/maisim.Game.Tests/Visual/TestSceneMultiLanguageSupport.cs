using maisim.Game.Beatmaps;
using maisim.Game.Component;
using maisim.Game.Graphics.Sprites;
using maisim.Game.Scores;
using osu.Framework.Graphics;
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
                new MaisimSpriteText
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
                    Title = "光線チューニング",
                    Artist = "ナユタン星人 feat. 000",
                    Bpm = 120,
                    CoverPath = "Test/nayutalien.jpg"
                },
                DifficultyLevel = DifficultyLevel.Basic,
                DifficultyRating = 5.21f,
                IsRemaster = true,
                MaxSeasonalScore = 865,
                NoteDesigner = "オモイヨシノ☆☆"
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
                new MaisimSpriteText
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

            var koreanMockBeatmap = new Beatmap
            {
                TrackMetadata = new TrackMetadata
                {
                    Title = "시간을 달려서 (ROUGH)",
                    Artist = "GFRIEND",
                    Bpm = 150,
                    CoverPath = "Test/snowflake.jpg"
                },
                DifficultyLevel = DifficultyLevel.Master,
                DifficultyRating = 8.88f,
                IsRemaster = true,
                MaxSeasonalScore = 999,
                NoteDesigner = "매우 긴"
            };

            var koreanMockScore = new Score
            {
                Beatmap = koreanMockBeatmap,
                Tap = 10,
                Hold = 10,
                Slide = 10,
                Touch = 10,
                Accuracy = 69.69f,
                Rank = ScoreProcessor.CalculateRank(69.69f),
                Combo = 794,
                SeasonalScore = 555
            };

            Cell(0, 2).Children = new Drawable[]
            {
                new MaisimSpriteText
                {
                    Anchor = Anchor.TopLeft,
                    Origin = Anchor.TopLeft,
                    Text = "Korean"
                },
                new TrackCardFocused(koreanMockBeatmap, koreanMockScore)
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Scale = new Vector2(0.7f)
                }
            };

            var chineseMockBeatmap = new Beatmap
            {
                TrackMetadata = new TrackMetadata
                {
                    Title = "陽光彩虹小白馬",
                    Artist = "大張偉",
                    Bpm = 150,
                    CoverPath = "Test/test.jpg"
                },
                DifficultyLevel = DifficultyLevel.Expert,
                DifficultyRating = 18.88f,
                IsRemaster = true,
                MaxSeasonalScore = 6969,
                NoteDesigner = "蔓"
            };

            var chineseMockScore = new Score
            {
                Beatmap = koreanMockBeatmap,
                Tap = 10,
                Hold = 10,
                Slide = 10,
                Touch = 10,
                Accuracy = 2f,
                Rank = ScoreProcessor.CalculateRank(2f),
                Combo = 794,
                SeasonalScore = 999
            };

            Cell(1, 0).Children = new Drawable[]
            {
                new MaisimSpriteText
                {
                    Anchor = Anchor.TopLeft,
                    Origin = Anchor.TopLeft,
                    Text = "Chinese"
                },
                new TrackCardFocused(chineseMockBeatmap, chineseMockScore)
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Scale = new Vector2(0.7f)
                }
            };
        }
    }
}
