using osu.Framework.Allocation;
using osu.Framework.Audio;
using osu.Framework.Audio.Track;
using osu.Framework.Graphics.Containers;

namespace maisim.Game.Graphics.UserInterface.Overlays
{
    public class MusicPlayer : CompositeDrawable
    {
        private Track track;
        private ITrackStore trackStore;

        [BackgroundDependencyLoader]
        private void load(AudioManager audioManager, ITrackStore tracks)
        {
            trackStore = audioManager.Tracks;
            track = trackStore.Get(@"dj-okawari.m4a");
            track.Looping = true;
            track.Start();
        }

        public Track getCurrentTrack()
        {
            return track;
        }
    }
}
