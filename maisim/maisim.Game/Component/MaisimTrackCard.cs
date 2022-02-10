using osu.Framework.Graphics.Containers;

namespace maisim.Game.Component
{
    /// <summary>
    /// A base abstract class for track cards types that show track information.
    /// </summary>
    public abstract class MaisimTrackCard : CompositeDrawable
    {
        protected readonly string albumTextureName;
        protected readonly string trackName;
        protected readonly string artistName;
        protected readonly float percentage;
        protected readonly string rank;
        protected readonly int dxscore;
        protected readonly int dxscoreFull;
        protected readonly bool allPerfect;
        protected readonly bool fdxPlus;
        protected readonly string noteDesigner;
        protected readonly int bpm;

        protected MaisimTrackCard(string albumTextureName, string trackName, string artistName, float percentage, string rank, int dxscore, int dxscoreFull,
            bool allPerfect, bool fdxPlus, string noteDesigner, int bpm)
        {
            this.albumTextureName = albumTextureName;
            this.trackName = trackName;
            this.artistName = artistName;
            this.percentage = percentage;
            this.rank = rank;
            this.dxscore = dxscore;
            this.dxscoreFull = dxscoreFull;
            this.allPerfect = allPerfect;
            this.fdxPlus = fdxPlus;
            this.noteDesigner = noteDesigner;
            this.bpm = bpm;
        }
    }
}
