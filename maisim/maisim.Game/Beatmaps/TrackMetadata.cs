namespace maisim.Game.Beatmaps
{
    public class TrackMetadata
    {
        private readonly string title;
        private readonly string artist;
        private readonly string coverName;
        private readonly float bpm;

        public TrackMetadata(string title, string artist, string coverName, float bpm)
        {
            this.title = title;
            this.artist = artist;
            this.coverName = coverName;
            this.bpm = bpm;
        }
    }
}
