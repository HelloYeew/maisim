using maisim.Game.Beatmaps;
using osu.Framework.Allocation;
using osu.Framework.Audio;
using osu.Framework.Audio.Track;
using osu.Framework.Bindables;
using osu.Framework.Graphics.Containers;
using osu.Framework.Logging;

namespace maisim.Game.Graphics.UserInterface.Overlays
{
    /// <summary>
    /// The global track player.
    /// </summary>
    public class MusicPlayer : CompositeDrawable
    {
        private Track track;
        private ITrackStore trackStore;
        private ITrackStore localTrackStore;
        public readonly bool startOnLoaded;

        /// <summary>
        /// The time of the track that if the go previous button is pressed, the track will just restart.
        /// </summary>
        public readonly double RESTART_TIME = 5000;

        [Resolved]
        private WorkingBeatmap workingBeatmap { get; set; }

        private void workingBeatmapChanged(ValueChangedEvent<BeatmapSet> beatmapSetEvent) => changeTrack(beatmapSetEvent.NewValue);

        public MusicPlayer(bool startOnLoaded = false)
        {
            this.startOnLoaded = startOnLoaded;
        }

        [BackgroundDependencyLoader]
        private void load(AudioManager audioManager, ITrackStore localTrackStore)
        {
            this.localTrackStore = localTrackStore;
            trackStore = audioManager.Tracks;
            Logger.Log(workingBeatmap.CurrentBeatmapSet.Value.AudioFileName);
            Logger.Log(workingBeatmap.CurrentBeatmapSet.Value.UseLocalFile.ToString());
            track = workingBeatmap.CurrentBeatmapSet.Value.UseLocalFile ? localTrackStore.Get(workingBeatmap.CurrentBeatmapSet.Value.AudioFileName) : trackStore.Get(workingBeatmap.CurrentBeatmapSet.Value.AudioFileName);
            workingBeatmap.CurrentBeatmapSet.BindValueChanged(workingBeatmapChanged);
            if (startOnLoaded)
                track.Start();
        }

        /// <summary>
        /// Toggle the track to pause. This method use in pause button so if the track has already paused, it will play the track instead.
        /// </summary>
        public void TogglePause()
        {
            if (track.IsRunning)
                track.Stop();
            else
                track.Start();
        }

        public void ToggleNext()
        {
            workingBeatmap.GoToNextBeatmapSet();
        }

        public void TogglePrevious()
        {
            if (track.CurrentTime < RESTART_TIME)
                track.Restart();
            else
                workingBeatmap.GoToPreviousBeatmapSet();
        }

        public void ToggleLoop()
        {
            track.Looping = !track.Looping;
        }

        private void changeTrack(BeatmapSet beatmapSet)
        {
            track.Stop();
            track = beatmapSet.UseLocalFile ? localTrackStore.Get(beatmapSet.AudioFileName) : trackStore.Get(beatmapSet.AudioFileName);
            track.Start();
        }

        public Track GetTrack()
        {
            return track;
        }
    }
}
