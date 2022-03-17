using maisim.Game.Beatmaps;
using maisim.Game.Component;
using maisim.Game.Utils;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Testing;
using osuTK;

namespace maisim.Game.Tests.Visual.Component
{

    public class TestSceneTrackCardFocusedManyStyle : GridTestScene
    {
        public TestSceneTrackCardFocusedManyStyle() : base(2, 3)
        {
            TestFixture basicMockFixture = new TestFixture("Sukino Skill");
            basicMockFixture.Beatmap.DifficultyLevel = DifficultyLevel.Basic;

            Cell(0, 0).Children = new Drawable[]
            {
                new SpriteText
                {
                    Anchor = Anchor.TopLeft,
                    Origin = Anchor.TopLeft,
                    Text = nameof(DifficultyLevel.Basic)
                },
                new TrackCardFocused(basicMockFixture.Beatmap, basicMockFixture.Score)
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Scale = new Vector2(0.7f)
                }
            };

            TestFixture advanceMockFixture = new TestFixture("Lemon");
            advanceMockFixture.Beatmap.DifficultyLevel = DifficultyLevel.Advanced;

            Cell(0, 1).Children = new Drawable[]
            {
                new SpriteText
                {
                    Anchor = Anchor.TopLeft,
                    Origin = Anchor.TopLeft,
                    Text = nameof(DifficultyLevel.Advanced)
                },
                new TrackCardFocused(advanceMockFixture.Beatmap, advanceMockFixture.Score)
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Scale = new Vector2(0.7f)
                }
            };

            TestFixture expertMockFixture = new TestFixture("only my railgun");
            expertMockFixture.Beatmap.DifficultyLevel = DifficultyLevel.Expert;

            Cell(0, 2).Children = new Drawable[]
            {
                new SpriteText
                {
                    Anchor = Anchor.TopLeft,
                    Origin = Anchor.TopLeft,
                    Text = nameof(DifficultyLevel.Expert)
                },
                new TrackCardFocused(expertMockFixture.Beatmap, expertMockFixture.Score)
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Scale = new Vector2(0.7f)
                }
            };

            TestFixture masterMockFixture = new TestFixture("RAISE MY SWORD");
            masterMockFixture.Beatmap.DifficultyLevel = DifficultyLevel.Master;

            Cell(1, 0).Children = new Drawable[]
            {
                new SpriteText
                {
                    Anchor = Anchor.TopLeft,
                    Origin = Anchor.TopLeft,
                    Text = nameof(DifficultyLevel.Master)
                },
                new TrackCardFocused(masterMockFixture.Beatmap, masterMockFixture.Score)
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Scale = new Vector2(0.7f)
                }
            };

            TestFixture remasterMockFixture = new TestFixture("Tenkai e no Kippu");
            remasterMockFixture.Beatmap.DifficultyLevel = DifficultyLevel.Remaster;

            Cell(1, 1).Children = new Drawable[]
            {
                new SpriteText
                {
                    Anchor = Anchor.TopLeft,
                    Origin = Anchor.TopLeft,
                    Text = nameof(DifficultyLevel.Remaster)
                },
                new TrackCardFocused(remasterMockFixture.Beatmap, remasterMockFixture.Score)
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Scale = new Vector2(0.7f)
                }
            };
        }
    }
}
