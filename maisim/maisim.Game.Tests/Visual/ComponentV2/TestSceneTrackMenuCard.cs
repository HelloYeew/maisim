using maisim.Game.Component;
using maisim.Game.Graphics.UserInterfaceV2;
using maisim.Game.Utils;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osuTK;
using osuTK.Graphics;

namespace maisim.Game.Tests.Visual.ComponentV2
{
    public class TestSceneTrackMenuCard : maisimTestScene
    {
        public TestSceneTrackMenuCard()
        {
            BeatmapSetTestFixture mockObject = new BeatmapSetTestFixture();

            Child = new TrackMenuCard(mockObject.BeatmapSet)
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
            };
        }
    }
}
