using maisim.Game.Graphics.UserInterface.Overlays;
using maisim.Game.Screen;
using maisim.Game.Utils;
using NUnit.Framework;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Screens;
using osuTK;

namespace maisim.Game.Tests.Visual.Screen
{
    public class TestSceneSongSelectionScreen : maisimTestScene
    {
        [Cached]
        private WorkingBeatmapManager workingBeatmapManager = new WorkingBeatmapManager();

        private BeatmapSetTestFixture beatmapSetTestFixture = new BeatmapSetTestFixture();

        private ScreenStack mainScreenStack;
        private SongSelectionScreen songSelectionScreen;

        [BackgroundDependencyLoader]
        private void load()
        {
            Dependencies.CacheAs(workingBeatmapManager);
            workingBeatmapManager.CurrentBeatmapSet.Value = beatmapSetTestFixture.BeatmapSet;
        }

        [SetUp]
        public void SetUp()
        {
            Add(mainScreenStack = new MaisimScreenStack()
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                RelativeSizeAxes = Axes.Both
            });
            mainScreenStack.Push(new BackgroundScreen());
            mainScreenStack.Push(songSelectionScreen = new SongSelectionScreen()
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
            });
            AddSliderStep("Main screen scale", 0.1f, 1, 1, v => mainScreenStack.Scale = new Vector2(v,v));
            AddSliderStep("Main screen width", 0.1f, 1, 1, v => mainScreenStack.Width = v);
            AddSliderStep("Main screen height", 0.1f, 1, 1, v => mainScreenStack.Height = v);
            AddSliderStep("Song selection screen scale", 0.1f, 1, 1, v => songSelectionScreen.Scale = new Vector2(v,v));
            AddSliderStep("Song selection screen width", 0.1f, 1, 1, v => songSelectionScreen.Width = v);
            AddSliderStep("Song selection screen height", 0.1f, 1, 1, v => songSelectionScreen.Height = v);
        }
    }
}
