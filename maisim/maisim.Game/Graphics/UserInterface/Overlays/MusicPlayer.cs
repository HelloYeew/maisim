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
        public Track Track { get; set; }
        private ITrackStore trackStore;
        public readonly bool startOnLoaded;

        /// <summary>
        /// The time of the track that if the go previous button is pressed, the track will just restart.
        /// </summary>
        public const double RESTART_TIME = 5000;

        /// <summary>
        /// The last time that the previous button has clicked
        /// </summary>
        private double lastPreviousClicked = 0;

        /// <summary>
        /// If the track's time is not reach this time, if the go previous button toggled the track will force reversed to previous track.
        /// </summary>
        private const double FORCE_PREVIOUS_TRACK_TIME = 5000;

        [Resolved]
        private WorkingBeatmap workingBeatmap { get; set; }

        private void workingBeatmapChanged(ValueChangedEvent<BeatmapSet> beatmapSetEvent) => changeTrack(beatmapSetEvent.NewValue);

        public MusicPlayer(bool startOnLoaded = false)
        {
            this.startOnLoaded = startOnLoaded;
        }

        [BackgroundDependencyLoader]
        private void load(AudioManager audioManager)
        {
            trackStore = audioManager.Tracks;
            Track = trackStore.Get(workingBeatmap.CurrentBeatmapSet.Value.AudioFileName);
            workingBeatmap.CurrentBeatmapSet.BindValueChanged(workingBeatmapChanged);
            Logger.Log("Initialized MusicPlayer with " + workingBeatmap.CurrentBeatmapSet.Value.AudioFileName);
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

        /// <summary>
        /// Go to next track.
        /// </summary>
        public void ToggleNext()
        {
            workingBeatmap.GoToNextBeatmapSet();
        }

        /// <summary>
        /// <para>Go to previous track.</para>
        ///
        /// <para>There are three factor to go previous track</para>
        /// <para>1. The track's time is not reach the FORCE_PREVIOUS_TRACK_TIME</para>
        /// <para>2. The track's time is reach the FORCE_PREVIOUS_TRACK_TIME and the current time - last button click time has not reach the RESTART_TIME</para>
        /// </summary>
        public void TogglePrevious()
        {
            if (Track.CurrentTime < FORCE_PREVIOUS_TRACK_TIME || (Track.CurrentTime >= FORCE_PREVIOUS_TRACK_TIME &&
                                                                  Clock.TimeInfo.Current - lastPreviousClicked <= RESTART_TIME))
            {
                workingBeatmap.GoToPreviousBeatmapSet();
            }
            else
            {
                Track.Restart();
            }

            lastPreviousClicked = Clock.TimeInfo.Current;
        }

        /// <summary>
        /// Toggle the <see cref="Track"/> looping.
        /// </summary>
        public void ToggleLoop()
        {
            Track.Looping = !Track.Looping;
        }

        protected override void Update()
        {
            base.Update();
            if (Track.HasCompleted && !Track.Looping)
            {
                // Dispose the track to ensure that the track's state has been reset.
                Track.Dispose();
                workingBeatmap.GoToNextBeatmapSet();
            }
        }

        /// <summary>
        /// Change the track to the new <see cref="BeatmapSet"/> track.
        /// </summary>
        /// <param name="beatmapSet">The new <see cref="BeatmapSet"/> track</param>
        private void changeTrack(BeatmapSet beatmapSet)
        {
            Track.Dispose();
            Track = trackStore.Get(workingBeatmap.CurrentBeatmapSet.Value.AudioFileName);
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
