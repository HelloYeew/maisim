using maisim.Game.Graphics.UserInterface;
using maisim.Game.Graphics.UserInterface.Overlays;
using maisim.Game.Graphics.UserInterfaceV2;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Screens;
using osuTK;

namespace maisim.Game.Screen
{
    /// <summary>
    /// The song selection screen that shows a list of all the songs to the user who can select a track to play from there.
    /// </summary>
    public class SongSelectionScreen : MaisimScreen
    {
        [Resolved]
        private CurrentWorkingBeatmap currentWorkingBeatmap { get; set; }

        public override float BackgroundParallaxAmount => 0.2f;

        [BackgroundDependencyLoader]
        private void load()
        {
            InternalChildren = new Drawable[]
            {
                new BeatmapSetSelection(),
                new BeatmapSetInfoBox()
                {
                    Anchor = Anchor.TopRight,
                    Origin = Anchor.TopRight,
                    RelativeSizeAxes = Axes.Y,
                    Depth = -10
                },
                new BackButton
                {
                    Anchor = Anchor.BottomLeft,
                    Origin = Anchor.BottomLeft,
                    Action = () => this.Exit()
                },
                new Container
                {
                    Anchor = Anchor.BottomRight,
                    Origin = Anchor.Centre,
                    Size = new Vector2(100),
                    Position = new Vector2(-5,-5),
                    Depth = 10,
                    Child = new MaisimLogo
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Size = new Vector2(20),
                        Scale = new Vector2(0.8f),
                        Depth = 10,
                    }
                },
            };
        }
    }
}
