using maisim.Game.Component;
using osu.Framework.Graphics;
using osu.Framework.Testing;
using osuTK;

namespace maisim.Game.Tests.Visual.Component
{
    public class TestSceneTrackCardManyStyle : GridTestScene
    {
        public TestSceneTrackCardManyStyle() : base(2,2)
        {
            Cell(0, 0).Child = new TrackCard("Test/sukino-skill.jpg", "Sukino Skill", "Wake Up, Girls!",
                100.6969f, "SSS", 1278, 2424, true, true, "HelloYeew", 120)
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
            };
            Cell(0, 1).Child = new TrackCard("Test/lemon.jpg", "Lemon", "Kenshi Yonezu",
                100.2900f, "SS", 58, 4542, false, true, "peppy", 80)
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
            };
            Cell(1,0).Child = new TrackCard("Test/only-my-railgun.jpg", "only my railgun", "fripSide",
                100.00f, "SS", 797, 4215, true, false, "Binky", 190)
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
            };
            Cell(1,1).Child = new TrackCard("Test/raise-my-sword.jpg", "RAISE MY SWORD", "GALNERYUS",
                0, "", 0, 4279, false, false, "BTMC", 220)
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
            };
        }
    }
}
