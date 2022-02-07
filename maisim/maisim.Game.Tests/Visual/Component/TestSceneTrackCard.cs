using maisim.Game.Component;
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
                    new TrackCard("Test/sukino-skill.jpg", "Sukino Skill", "Wake Up, Girls!",
                        100.6969f, "SSS", 1278, 2424, true, true, "HelloYeew", 120)
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                    }
                }
            };
        }
    }
}
