using maisim.Game.Beatmaps;
using osu.Framework.Bindables;

namespace maisim.Game.Component
{
    public class GlobalBeatmap : osu.Framework.Graphics.Component
    {
        private TrackMetadata blankTrackMetadata;

        public Bindable<TrackMetadata> currentGlobalBeatmap;

        public GlobalBeatmap()
        {
            blankTrackMetadata = new TrackMetadata
            {
                Title = "No working beatmap!",
                Artist = "Please select a beatmap!",
                CoverPath = "blankbeatmap.png",
                Bpm = 0
            };
            currentGlobalBeatmap = new Bindable<TrackMetadata>(blankTrackMetadata);
        }

        public void SetGlobalBeatmap(TrackMetadata trackMetadata)
        {
            currentGlobalBeatmap.Value = trackMetadata;
        }

        public TrackMetadata GetGlobalBeatmap()
        {
            return currentGlobalBeatmap.Value;
        }
    }
}
