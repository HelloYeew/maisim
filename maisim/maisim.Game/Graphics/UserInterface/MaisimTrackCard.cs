using maisim.Game.Beatmaps;
using maisim.Game.Scores;
using osu.Framework.Graphics.Containers;

namespace maisim.Game.Graphics.UserInterface
{
    /// <summary>
    /// A base abstract class for track cards types that show track information.
    /// </summary>
    public abstract partial class MaisimTrackCard : CompositeDrawable
    {
        protected readonly Beatmap beatmap;
        protected readonly Score score;

        protected MaisimTrackCard(Beatmap beatmap, Score score)
        {
            this.beatmap = beatmap;
            this.score = score;
        }
    }
}
