using maisim.Game.Graphics.UserInterface.Overlays;
using maisim.Game.Screen;
using maisim.Game.Utils;
using NUnit.Framework;
using osu.Framework.Allocation;
using osu.Framework.Audio;
using osu.Framework.Audio.Track;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Screens;

namespace maisim.Game.Tests.Visual.Screen
{
    public class TestSceneMainMenuScreen : maisimTestScene
    {
        [Cached]
        private WorkingBeatmapManager workingBeatmapManager = new WorkingBeatmapManager();

        [Cached]
        private CurrentWorkingBeatmap currentWorkingBeatmap = new CurrentWorkingBeatmap();

        [Cached]
        private MusicPlayer musicPlayer = new MusicPlayer();

        [Resolved]
        private AudioManager audioManager { get; set; }

        private BeatmapSetTestFixture beatmapSetTestFixture = new BeatmapSetTestFixture();

        private MainMenuScreen mainMenuScreen;
        private ScreenStack screenStack;

        [BackgroundDependencyLoader]
        private void load()
        {
            Dependencies.CacheAs(workingBeatmapManager);
            Dependencies.CacheAs(currentWorkingBeatmap);
            currentWorkingBeatmap.SetCurrentBeatmapSet(beatmapSetTestFixture.BeatmapSet);
            Dependencies.CacheAs(musicPlayer);
            musicPlayer.Track = new Bindable<Track>(audioManager.Tracks.Get(currentWorkingBeatmap.BeatmapSet.AudioFileName));
        }

        [SetUp]
        public void SetUp()
        {
            Add(screenStack = new ScreenStack(mainMenuScreen = new MainMenuScreen())
            {
                RelativeSizeAxes = Axes.Both
            });
            AddStep("Toggle play button", () => musicPlayer.TogglePause());
            AddStep("Change track", () =>
            {
                beatmapSetTestFixture = new BeatmapSetTestFixture();
                currentWorkingBeatmap.SetCurrentBeatmapSet(beatmapSetTestFixture.BeatmapSet);
                musicPlayer.Track.Value.Dispose();
                musicPlayer.Track.Value = audioManager.Tracks.Get(currentWorkingBeatmap.BeatmapSet.AudioFileName);
                musicPlayer.Track.Value.Start();
            });
        }
    }
}
