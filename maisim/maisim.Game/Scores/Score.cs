using maisim.Game.Beatmaps;

namespace maisim.Game.Scores
{
    public class Score
    {
        private readonly Beatmap beatmap;
        private readonly int tap;
        private readonly int hold;
        private readonly int slide;
        private readonly int touch;
        private readonly int combo;
        private readonly int seasonalScore;

        public Score(int tap, int hold, int slide, int touch, int combo, int seasonalScore)
        {
            this.tap = tap;
            this.hold = hold;
            this.slide = slide;
            this.touch = touch;
            this.combo = combo;
            this.seasonalScore = seasonalScore;
        }
    }
}
