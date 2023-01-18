using maisim.Game.Graphics.UserInterface.Overlays;
using maisim.Game.Screen;
using maisim.Game.Utils;
using NUnit.Framework;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Screens;

namespace maisim.Game.Tests.Visual.Screen
{
    public partial class TestSceneMainMenuScreen : maisimTestScene
    {
        [Cached]
        private WorkingBeatmapManager workingBeatmapManager = new WorkingBeatmapManager();

        [Cached]
        private CurrentWorkingBeatmap currentWorkingBeatmap = new CurrentWorkingBeatmap();

        private BeatmapSetTestFixture beatmapSetTestFixture = new BeatmapSetTestFixture();

        private MainMenuScreen mainMenuScreen;
        private ScreenStack screenStack;

        [BackgroundDependencyLoader]
        private void load()
        {
            Dependencies.CacheAs(workingBeatmapManager);
            Dependencies.CacheAs(currentWorkingBeatmap);
            currentWorkingBeatmap.SetCurrentBeatmapSet(beatmapSetTestFixture.BeatmapSet);
        }

        [SetUp]
        public void SetUp()
        {
            Add(screenStack = new ScreenStack(mainMenuScreen = new MainMenuScreen())
            {
                RelativeSizeAxes = Axes.Both
            });
            AddStep("Change track", () =>
            {
                beatmapSetTestFixture = new BeatmapSetTestFixture();
                currentWorkingBeatmap.SetCurrentBeatmapSet(beatmapSetTestFixture.BeatmapSet);
            });
        }
    }
}
