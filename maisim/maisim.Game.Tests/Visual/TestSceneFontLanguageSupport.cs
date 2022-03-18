using maisim.Game.Beatmaps;
using maisim.Game.Component;
using maisim.Game.Graphics.Sprites;
using maisim.Game.Utils;
using osu.Framework.Graphics;
using osu.Framework.Testing;
using osuTK;

namespace maisim.Game.Tests.Visual
{
    public class TestSceneFontLanguageSupport : GridTestScene
    {
        public TestSceneFontLanguageSupport() : base(2, 3)
        {
            TrackMetadata thaiMockTrackMetadata = new TrackMetadata
            {
                Title = "คืนความสุขให้ประเทศไทยพองๆ",
                Artist = "ไม่รู้คับ ทดสอบๆ",
                Bpm = 200,
                CoverPath = "Test/test.jpg"
            };

            TrackTestFixture thaiMockFixture = new TrackTestFixture();
            thaiMockFixture.Beatmap = TestUtil.CreateMockBeatmap(thaiMockTrackMetadata);
            thaiMockFixture.Beatmap.DifficultyLevel = DifficultyLevel.Expert;
            thaiMockFixture.Score = TestUtil.CreateMockScore(thaiMockFixture.Beatmap);

            Cell(0, 0).Children = new Drawable[]
            {
                new MaisimSpriteText
                {
                    Anchor = Anchor.TopLeft,
                    Origin = Anchor.TopLeft,
                    Text = "Thai"
                },
                new TrackCardFocused(thaiMockFixture.Beatmap, thaiMockFixture.Score)
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Scale = new Vector2(0.7f)
                }
            };

            TrackTestFixture japaneseMockFixture = new TrackTestFixture("光線チューニング");
            japaneseMockFixture.Beatmap.DifficultyLevel = DifficultyLevel.Basic;

            Cell(0, 1).Children = new Drawable[]
            {
                new MaisimSpriteText
                {
                    Anchor = Anchor.TopLeft,
                    Origin = Anchor.TopLeft,
                    Text = "Japanese"
                },
                new TrackCardFocused(japaneseMockFixture.Beatmap, japaneseMockFixture.Score)
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Scale = new Vector2(0.7f)
                }
            };

            TrackTestFixture koreanMockFixture = new TrackTestFixture("시간을 달려서 (ROUGH)");
            koreanMockFixture.Beatmap.DifficultyLevel = DifficultyLevel.Master;

            Cell(0, 2).Children = new Drawable[]
            {
                new MaisimSpriteText
                {
                    Anchor = Anchor.TopLeft,
                    Origin = Anchor.TopLeft,
                    Text = "Korean"
                },
                new TrackCardFocused(koreanMockFixture.Beatmap, koreanMockFixture.Score)
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Scale = new Vector2(0.7f)
                }
            };

            TrackMetadata chineseMockTrackMetadata = new TrackMetadata
            {
                Title = "陽光彩虹小白馬",
                Artist = "大張偉",
                Bpm = 150,
                CoverPath = "Test/test.jpg"
            };

            TrackTestFixture chineseMockFixture = new TrackTestFixture();
            chineseMockFixture.Beatmap = TestUtil.CreateMockBeatmap(chineseMockTrackMetadata);
            chineseMockFixture.Beatmap.DifficultyLevel = DifficultyLevel.Expert;
            chineseMockFixture.Score = TestUtil.CreateMockScore(chineseMockFixture.Beatmap);

            Cell(1, 0).Children = new Drawable[]
            {
                new MaisimSpriteText
                {
                    Anchor = Anchor.TopLeft,
                    Origin = Anchor.TopLeft,
                    Text = "Chinese"
                },
                new TrackCardFocused(chineseMockFixture.Beatmap, chineseMockFixture.Score)
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Scale = new Vector2(0.7f)
                }
            };

            // should cover all languages based on latin alphabet
            TrackMetadata englishMockTrackMetadata = new TrackMetadata
            {
                Title = "EXiT THIS EARTH'S ATOMOSPHERE",
                Artist = "Camellia",
                Bpm = 120,
                CoverPath = "Test/test.jpg"
            };

            TrackTestFixture englishMockFixture = new TrackTestFixture();
            englishMockFixture.Beatmap = TestUtil.CreateMockBeatmap(englishMockTrackMetadata);
            englishMockFixture.Beatmap.DifficultyLevel = DifficultyLevel.Basic;
            englishMockFixture.Score = TestUtil.CreateMockScore(englishMockFixture.Beatmap);

            Cell(1, 1).Children = new Drawable[]
            {
                new MaisimSpriteText
                {
                    Anchor = Anchor.TopLeft,
                    Origin = Anchor.TopLeft,
                    Text = "English (Latin)"
                },
                new TrackCardFocused(englishMockFixture.Beatmap, englishMockFixture.Score)
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Scale = new Vector2(0.7f)
                }
            };
        }
    }
}
