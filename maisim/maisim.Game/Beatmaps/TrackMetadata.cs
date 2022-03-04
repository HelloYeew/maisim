namespace maisim.Game.Beatmaps
{
    public class TrackMetadata
    {
        private readonly string title;
        private readonly string artist;
        private readonly string coverPath;
        private readonly float bpm;

        public TrackMetadata(string title, string artist, string coverPath, float bpm)
        {
            this.title = title;
            this.artist = artist;
            this.coverPath = coverPath;
            this.bpm = bpm;
        }

        public string Title => title;

        public string Artist => artist;

        public string CoverPath => coverPath;

        public float Bpm => bpm;
    }
}
