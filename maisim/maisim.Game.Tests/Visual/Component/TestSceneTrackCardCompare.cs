using maisim.Game.Component;
using maisim.Game.Utils;
using osu.Framework.Testing;
using osu.Framework.Graphics;
using osuTK;

namespace maisim.Game.Tests.Visual.Component
{
    public class TestSceneTrackCardCompare : GridTestScene
    {
        public TestSceneTrackCardCompare() : base(1,2)
        {
            TrackTestFixture mockObject = new TrackTestFixture();

            Cell(0, 0).Child = new TrackCard(mockObject.Beatmap, mockObject.Score)
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Scale = new Vector2(1)
            };
            Cell(0, 1).Child = new TrackCardFocused(mockObject.Beatmap, mockObject.Score)
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Scale = new Vector2(1)
            };
        }
    }
}
