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
        public Track Track { get; private set; }
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
            Logger.Log("Initialized MusicPlayer with " + workingBeatmap.CurrentBeatmapSet.Value.AudioFileName);
            Logger.Log("Using local track store: " + workingBeatmap.CurrentBeatmapSet.Value.UseLocalFile);
            Track = workingBeatmap.CurrentBeatmapSet.Value.UseLocalFile ? localTrackStore.Get(workingBeatmap.CurrentBeatmapSet.Value.AudioFileName) : trackStore.Get(workingBeatmap.CurrentBeatmapSet.Value.AudioFileName);
            workingBeatmap.CurrentBeatmapSet.BindValueChanged(workingBeatmapChanged);
            if (startOnLoaded)
                Track.Start();
        }

        /// <summary>
        /// Toggle the track to pause. This method use in pause button so if the track has already paused, it will play the track instead.
        /// </summary>
        public void TogglePause()
        {
            if (Track.IsRunning)
            {
                Track.Stop();
                Logger.Log("Track has been paused");
            }
            else
            {
                Track.Start();
                Logger.Log("Track has been played");
            }
        }

        public void ToggleNext()
        {
            workingBeatmap.GoToNextBeatmapSet();
        }

        public void TogglePrevious()
        {
            if (Track.CurrentTime < RESTART_TIME)
                Track.Restart();
            else
                workingBeatmap.GoToPreviousBeatmapSet();
        }

        public void ToggleLoop()
        {
            Track.Looping = !Track.Looping;
        }

        protected override void Update()
        {
            base.Update();
            if (Track.HasCompleted && !Track.Looping)
                workingBeatmap.GoToNextBeatmapSet();
        }

        /// <summary>
        /// Change the track to the new <see cref="BeatmapSet"/> track.
        /// </summary>
        /// <param name="beatmapSet">The new <see cref="BeatmapSet"/> track</param>
        private void changeTrack(BeatmapSet beatmapSet)
        {
            Track = beatmapSet.UseLocalFile ? localTrackStore.Get(beatmapSet.AudioFileName) : trackStore.Get(beatmapSet.AudioFileName);
            Logger.Log("Changed track to " + beatmapSet.AudioFileName);
            Track.Start();
        }

        /// <summary>
        /// Seek the track to the specified time.
        /// </summary>
        /// <param name="position">The specified time</param>
        public void SeekTo(double position)
        {
            Track.Seek(position);
        }
    }
}
