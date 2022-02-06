using maisim.Game.Component;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Testing;
using osuTK;
using osuTK.Graphics;

namespace maisim.Game.Tests.Visual.Component
{
    public class TestSceneTrackCardManyStyle : GridTestScene
    {
        public TestSceneTrackCardManyStyle() : base(2,2)
        {
            Cell(0, 0).Child = new TrackCard()
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Scale = new Vector2(0.7f)
            };
            Cell(0, 1).Child = new TrackCard()
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Scale = new Vector2(0.7f)
            };
            Cell(1,0).Child = new TrackCard()
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Scale = new Vector2(0.7f)
            };
            Cell(1,1).Child = new TrackCard()
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Scale = new Vector2(0.7f)
            };
        }
    }
}
