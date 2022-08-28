using maisim.Game.Beatmaps;
using maisim.Game.Component;
using maisim.Game.Graphics;
using maisim.Game.Graphics.UserInterface.Toolbar;
using maisim.Game.Graphics.UserInterfaceV2;
using maisim.Game.Scores;
using maisim.Game.Utils;
using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Screens;
using osuTK;
using osuTK.Graphics;

namespace maisim.Game.Screen
{
    /// <summary>
    /// The song selection screen that shows a list of all the songs to the user who can select a track to play from there.
    /// </summary>
    public class SongSelectionScreen : MaisimScreen
    {
        public override float BackgroundParallaxAmount => 0.2f;

        [BackgroundDependencyLoader]
        private void load()
        {
            BeatmapSetTestFixture mockFixture = new BeatmapSetTestFixture();

            InternalChildren = new Drawable[]
            {
                new BeatmapSetSelection(),
                new Container()
                {
                    Anchor = Anchor.TopRight,
                    Origin = Anchor.TopRight,
                    RelativeSizeAxes = Axes.Y,
                    Size = new Vector2(750, 0.825f),
                    Position = new Vector2(-20, 20),
                    Masking = true,
                    CornerRadius = 30,
                    Children = new Drawable[]
                    {
                        new Box
                        {
                            Anchor = Anchor.TopRight,
                            Origin = Anchor.TopRight,
                            Colour = MaisimColour.SongSelectionContainerColor,
                            Alpha = 0.5f,
                            RelativeSizeAxes = Axes.Both
                        }
                    }
                },
                new BackButton
                {
                    Anchor = Anchor.BottomLeft,
                    Origin = Anchor.BottomLeft,
                    Action = () => this.Exit()
                }
            };
        }
    }
}
