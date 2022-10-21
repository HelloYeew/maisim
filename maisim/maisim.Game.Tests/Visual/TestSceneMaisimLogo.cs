using osu.Framework.Graphics;
using maisim.Game.Graphics.UserInterface;
using maisim.Game.Graphics.UserInterface.Overlays;
using maisim.Game.Utils;
using osu.Framework.Allocation;
using osu.Framework.Audio;
using osu.Framework.Audio.Track;
using osu.Framework.Bindables;

namespace maisim.Game.Tests.Visual;

public class TestSceneMaisimLogo : maisimTestScene
{
    [Cached]
    private CurrentWorkingBeatmap currentWorkingBeatmap = new CurrentWorkingBeatmap();

    [Cached]
    private MusicPlayer musicPlayer = new MusicPlayer();

    private BeatmapSetTestFixture beatmapSetTestFixture = new BeatmapSetTestFixture();

    [BackgroundDependencyLoader]
    private void load(AudioManager audioManager)
    {
        Dependencies.CacheAs(currentWorkingBeatmap);
        Dependencies.CacheAs(musicPlayer);
        currentWorkingBeatmap.SetCurrentBeatmapSet(beatmapSetTestFixture.BeatmapSet);
        musicPlayer.Track = new Bindable<Track>(audioManager.Tracks.Get(currentWorkingBeatmap.BeatmapSet.AudioFileName));
    }

    public TestSceneMaisimLogo()
    {
        Child = new MaisimLogo
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
        };
    }
}
