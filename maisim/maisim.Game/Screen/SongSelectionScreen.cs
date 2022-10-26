using maisim.Game.Graphics.UserInterface;
using maisim.Game.Graphics.UserInterface.Overlays;
using maisim.Game.Graphics.UserInterfaceV2;
using maisim.Game.Users;
using maisim.Game.Users.Activity;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Screens;

namespace maisim.Game.Screen
{
    /// <summary>
    /// The song selection screen that shows a list of all the songs to the user who can select a track to play from there.
    /// </summary>
    public class SongSelectionScreen : MaisimScreen
    {
        [Resolved]
        private CurrentWorkingBeatmap currentWorkingBeatmap { get; set; }

        [Resolved]
        private User user { get; set; }

        public override float BackgroundParallaxAmount => 0.2f;

        public override IUserActivity InitialUserActivity => new ChoosingBeatmap();

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
                },
                new BackButton
                {
                    Anchor = Anchor.BottomLeft,
                    Origin = Anchor.BottomLeft,
                    Action = () => this.Exit()
                }
            };
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();
        }
    }
}
