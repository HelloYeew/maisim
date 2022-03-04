using maisim.Game.Beatmaps;
using maisim.Game.Component;
using osu.Framework.Testing;
using osu.Framework.Graphics;
using osuTK;

namespace maisim.Game.Tests.Visual.Component
{
    public class TestSceneTrackCardCompare : GridTestScene
    {
        public TestSceneTrackCardCompare() : base(1,2)
        {
            Cell(0, 0).Child = new TrackCard("Test/sukino-skill.jpg", "Sukino Skill", "Wake Up, Girls!",
                100.6969f, "SSS", 1278, 2424, true, true, "HelloYeew", 120, DifficultyLevel.Advanced)
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Scale = new Vector2(1)
            };
            Cell(0, 1).Child = new TrackCardFocused("Test/sukino-skill.jpg", "Sukino Skill", "Wake Up, Girls!",
                100.6969f, "SSS", 1278, 2424, true, true, "HelloYeew", 120, DifficultyLevel.Advanced)
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Scale = new Vector2(1)
            };
        }
    }
}
