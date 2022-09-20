using maisim.Game.Beatmaps;
using osu.Framework.Allocation;
using osu.Framework.Audio;
using osu.Framework.Audio.Track;
using osu.Framework.Bindables;
using osu.Framework.Extensions;
using osu.Framework.Graphics.Containers;
using osu.Framework.Logging;

namespace maisim.Game.Graphics.UserInterface.Overlays
{
    /// <summary>
    /// The global track player.
    /// </summary>
    public class MusicPlayer : CompositeDrawable
    {
        public Bindable<Track> Track;
        private ITrackStore trackStore;
        private readonly bool startOnLoaded;

        /// <summary>
        /// The time of the track that if the go previous button is pressed, the track will just restart.
        /// </summary>
        private const double restart_time = 5000;

        /// <summary>
        /// The last time that the previous button has clicked
        /// </summary>
        private double lastPreviousClicked = 0;

        /// <summary>
        /// If the track's time is not reach this time, if the go previous button toggled the track will force reversed to previous track.
        /// </summary>
        private const double force_previous_track_time = 5000;

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
            Track = new Bindable<Track>(trackStore.Get(workingBeatmap.CurrentBeatmapSet.Value.AudioFileName));
            workingBeatmap.CurrentBeatmapSet.BindValueChanged(workingBeatmapChanged);
            Logger.Log("Initialized MusicPlayer with " + workingBeatmap.CurrentBeatmapSet.Value.AudioFileName);
            if (startOnLoaded)
                Track.Value.Start();
        }

        /// <summary>
        /// Toggle the track to pause. This method use in pause button so if the track has already paused, it will play the track instead.
        /// </summary>
        public void TogglePause()
        {
            if (Track.Value.IsRunning)
            {
                Track.Value.Stop();
                Logger.Log("Track has been paused");
            }
            else
            {
                Track.Value.Start();
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
            Scheduler.Add(() =>
            {
                if (Track.Value.CurrentTime < force_previous_track_time || (Track.Value.CurrentTime >= force_previous_track_time &&
                                                                            Clock.TimeInfo.Current - lastPreviousClicked <=
                                                                            restart_time))
                {
                    workingBeatmap.GoToPreviousBeatmapSet();
                }
                else
                {
                    Track.Value.Restart();
                }
            });
            lastPreviousClicked = Clock.TimeInfo.Current;
        }

        /// <summary>
        /// Toggle the <see cref="Track"/> looping.
        /// </summary>
        public void ToggleLoop()
        {
            Track.Value.Looping = !Track.Value.Looping;
        }

        protected override void Update()
        {
            base.Update();

            if (Track.Value.HasCompleted && !Track.Value.Looping)
            {
                workingBeatmap.GoToNextBeatmapSet();
            }
        }

        /// <summary>
        /// Change the track to the new <see cref="BeatmapSet"/> track.
        /// </summary>
        /// <param name="beatmapSet">The new <see cref="BeatmapSet"/> track</param>
        internal void changeTrack(BeatmapSet beatmapSet)
        {
            Logger.Log("Changed");
            Track.Value.StopAsync().WaitSafely();
            Track.Value.Dispose();
            Scheduler.Add(() =>
            {
                Track.Value = trackStore.Get(workingBeatmap.CurrentBeatmapSet.Value.AudioFileName);
                Logger.Log("Changed track to " + beatmapSet.AudioFileName);
                Track.Value.StartAsync().WaitSafely();
            });
        }

        /// <summary>
        /// Seek the track to the specified time.
        /// </summary>
        /// <param name="position">The specified time</param>
        public void SeekTo(double position)
        {
            Scheduler.Add(() => Track.Value.Seek(position));
        }
    }
}
