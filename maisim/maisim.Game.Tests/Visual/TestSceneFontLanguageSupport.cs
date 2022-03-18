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

            TestFixture thaiMockFixture = new TestFixture();
            thaiMockFixture.Beatmap = TestUtil.GetRandomBeatmap(thaiMockTrackMetadata);
            thaiMockFixture.Beatmap.DifficultyLevel = DifficultyLevel.Expert;
            thaiMockFixture.Score = TestUtil.GetRandomScore(thaiMockFixture.Beatmap);

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

            TestFixture japaneseMockFixture = new TestFixture("光線チューニング");
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

            TestFixture koreanMockFixture = new TestFixture("시간을 달려서 (ROUGH)");
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

            TestFixture chineseMockFixture = new TestFixture();
            chineseMockFixture.Beatmap = TestUtil.GetRandomBeatmap(chineseMockTrackMetadata);
            chineseMockFixture.Beatmap.DifficultyLevel = DifficultyLevel.Expert;
            chineseMockFixture.Score = TestUtil.GetRandomScore(chineseMockFixture.Beatmap);

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

            TestFixture englishMockFixture = new TestFixture();
            englishMockFixture.Beatmap = TestUtil.GetRandomBeatmap(englishMockTrackMetadata);
            englishMockFixture.Beatmap.DifficultyLevel = DifficultyLevel.Basic;
            englishMockFixture.Score = TestUtil.GetRandomScore(englishMockFixture.Beatmap);

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
