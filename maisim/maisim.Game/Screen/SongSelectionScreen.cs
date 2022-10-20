using maisim.Game.Beatmaps;
using maisim.Game.Graphics.UserInterface;
using maisim.Game.Graphics.UserInterfaceV2;
using maisim.Game.Utils;
using osu.Framework.Allocation;
using osu.Framework.Audio.Track;
using osu.Framework.Bindables;
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
        public override float BackgroundParallaxAmount => 0.2f;

        // TODO: These two bindables need to pass via DI instead of assign a random one.
        private Bindable<DifficultyLevel> bindableDifficultyLevel = new Bindable<DifficultyLevel>();

        private Bindable<BeatmapSet> bindableBeatmapSet = new Bindable<BeatmapSet>(new BeatmapSetTestFixture().BeatmapSet);

        [BackgroundDependencyLoader]
        private void load(ITrackStore tracks)
        {
            InternalChildren = new Drawable[]
            {
                new BeatmapSetSelection(bindableBeatmapSet),
                new BeatmapSetInfoBox(bindableDifficultyLevel,bindableBeatmapSet)
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
                },
                new Container
                {
                    Anchor = Anchor.BottomRight,
                    Origin = Anchor.BottomRight,
                    Size = new Vector2(300, 80),
                    Position = new Vector2(-20,-20),
                    Child = new PlayButton()
                    {
                        Size = new Vector2(300, 80),
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                    }
                },
            };
        }
    }
}
