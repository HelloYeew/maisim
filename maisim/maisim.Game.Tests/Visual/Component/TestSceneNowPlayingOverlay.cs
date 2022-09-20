using maisim.Game.Graphics.UserInterface.Overlays;
using maisim.Game.Screen;
using maisim.Game.Utils;
using NUnit.Framework;
using osu.Framework.Allocation;
using osu.Framework.Audio;
using osu.Framework.Audio.Track;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osuTK;

namespace maisim.Game.Tests.Visual.Component;

public class TestSceneNowPlayingOverlay : maisimTestScene
{
    [Cached]
    private MusicPlayer musicPlayer = new MusicPlayer();

    [Cached]
    private WorkingBeatmap workingBeatmap = new WorkingBeatmap();

    [Resolved]
    private AudioManager audioManager { get; set; }

    [Cached]
    private NowPlayingOverlay nowPlayingOverlay = new NowPlayingOverlay();

    private BeatmapSetTestFixture beatmapSetTestFixture = new BeatmapSetTestFixture();

    [BackgroundDependencyLoader]
    private void load(AudioManager audioManager)
    {
        Dependencies.CacheAs(workingBeatmap);
        workingBeatmap.CurrentBeatmapSet.Value = beatmapSetTestFixture.BeatmapSet;
        Dependencies.CacheAs(musicPlayer);
        musicPlayer.Track = new Bindable<Track>(audioManager.Tracks.Get(workingBeatmap.CurrentBeatmapSet.Value.AudioFileName));
        Dependencies.CacheAs(nowPlayingOverlay);
    }

    protected override void LoadAsyncComplete()
    {
        Add(new BackgroundScreenStack());
        Add(nowPlayingOverlay = new NowPlayingOverlay()
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            Size = new Vector2(420,200)
        });
    }

    [SetUp]
    public void SetUp()
    {
        AddStep("show overlay", () => nowPlayingOverlay.State.Value = Visibility.Visible);
        AddStep("hide overlay", () => nowPlayingOverlay.State.Value = Visibility.Hidden);
    }
}
