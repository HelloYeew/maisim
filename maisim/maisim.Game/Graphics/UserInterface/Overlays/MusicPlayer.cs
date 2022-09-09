using osu.Framework.Allocation;
using osu.Framework.Audio;
using osu.Framework.Audio.Track;
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
        public readonly bool startOnLoaded;

        [Resolved]
        private WorkingBeatmap workingBeatmap { get; set; }

        public MusicPlayer(bool startOnLoaded = false)
        {
            this.startOnLoaded = startOnLoaded;
        }

        [BackgroundDependencyLoader]
        private void load(AudioManager audioManager, ITrackStore localTrackStore)
        {
            trackStore = audioManager.Tracks;
            Logger.Log(workingBeatmap.CurrentBeatmapSet.Value.AudioFileName);
            Logger.Log(workingBeatmap.CurrentBeatmapSet.Value.UseLocalFile.ToString());
            track = workingBeatmap.CurrentBeatmapSet.Value.UseLocalFile ? localTrackStore.Get(workingBeatmap.CurrentBeatmapSet.Value.AudioFileName) : trackStore.Get(workingBeatmap.CurrentBeatmapSet.Value.AudioFileName);
            track.Looping = true;
            if (startOnLoaded)
                track.Start();
        }

        public void TogglePause()
        {
            if (track.IsRunning)
                track.Stop();
            else
                track.Start();
        }

        public Track GetTrack()
        {
            return track;
        }
    }
}
