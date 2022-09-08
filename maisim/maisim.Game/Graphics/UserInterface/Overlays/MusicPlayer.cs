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

        [Resolved]
        private WorkingBeatmap workingBeatmap { get; set; }

        [BackgroundDependencyLoader]
        private void load(AudioManager audioManager, ITrackStore localTrackStore)
        {
            trackStore = audioManager.Tracks;
            Logger.Log(workingBeatmap.CurrentBeatmapSet.Value.AudioFileName);
            Logger.Log(workingBeatmap.CurrentBeatmapSet.Value.UseLocalFile.ToString());
            track = workingBeatmap.CurrentBeatmapSet.Value.UseLocalFile ? localTrackStore.Get(workingBeatmap.CurrentBeatmapSet.Value.AudioFileName) : trackStore.Get(workingBeatmap.CurrentBeatmapSet.Value.AudioFileName);
            track.Looping = true;
            track.Volume.Value = 3.0f;
            track.Start();
        }

        public void TogglePause()
        {
            if (track.IsRunning)
                track.Stop();
            else
                track.Start();
        }
    }
}
