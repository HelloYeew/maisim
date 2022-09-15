using maisim.Game.Graphics.UserInterface.Overlays;
using maisim.Game.Screen;
using maisim.Game.Utils;
using NUnit.Framework;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Screens;

namespace maisim.Game.Tests.Visual.Screen
{
    public class TestSceneMainMenuScreen : maisimTestScene
    {
        [Cached]
        private WorkingBeatmap workingBeatmap = new WorkingBeatmap();

        private BeatmapSetTestFixture beatmapSetTestFixture = new BeatmapSetTestFixture();

        [BackgroundDependencyLoader]
        private void load()
        {
            Dependencies.CacheAs(workingBeatmap);
            workingBeatmap.CurrentBeatmapSet.Value = beatmapSetTestFixture.BeatmapSet;
        }

        [SetUp]
        public void SetUp()
        {
            Add(new ScreenStack(new MainMenuScreen())
            {
                RelativeSizeAxes = Axes.Both
            });
        }
    }
}
