using maisim.Game.Graphics.UserInterface;
using maisim.Game.Graphics.UserInterface.Overlays;
using maisim.Game.Graphics.UserInterfaceV2;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Screens;
using osuTK;

namespace maisim.Game.Screen
{
    /// <summary>
    /// The song selection screen that shows a list of all the songs to the user who can select a track to play from there.
    /// </summary>
    public partial class SongSelectionScreen : MaisimScreen
    {
        [Resolved]
        private CurrentWorkingBeatmap currentWorkingBeatmap { get; set; }

        public override float BackgroundParallaxAmount => 0.2f;

        private BackButton backButton;
        private BeatmapSetSelection beatmapSetSelection;
        private BeatmapSetInfoBox beatmapSetInfoBox;

        [BackgroundDependencyLoader]
        private void load()
        {
            InternalChildren = new Drawable[]
            {
                beatmapSetSelection = new BeatmapSetSelection()
                {
                    Position = new Vector2(120, 1000)
                },
                beatmapSetInfoBox = new BeatmapSetInfoBox()
                {
                    Anchor = Anchor.TopRight,
                    Origin = Anchor.TopRight,
                    Position = new Vector2(2000, 20),
                    RelativeSizeAxes = Axes.Y
                },
                backButton = new BackButton
                {
                    Anchor = Anchor.BottomLeft,
                    Origin = Anchor.BottomLeft,
                    Scale = new Vector2(0),
                    Action = () => this.Exit()
                }
            };
        }

        public override void OnEntering(ScreenTransitionEvent e)
        {
            beatmapSetSelection.MoveToY(0, 500, Easing.OutQuint);
            beatmapSetInfoBox.MoveToX(-20, 750, Easing.OutQuint);
            backButton.ScaleTo(1, 1000, Easing.OutQuint);
        }

        public override void OnSuspending(ScreenTransitionEvent e)
        {
            this.ScaleTo(0f, 750, Easing.OutQuint);
            this.MoveToX(-DrawWidth, 750, Easing.OutExpo);
        }

        public override void OnResuming(ScreenTransitionEvent e)
        {
            this.ScaleTo(1, 750, Easing.OutQuint);
            this.MoveToX(0, 750, Easing.OutExpo);
        }
    }
}
