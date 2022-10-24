using maisim.Game.Beatmaps;
using maisim.Game.Graphics.UserInterface.Overlays;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osuTK;

namespace maisim.Game.Graphics.UserInterfaceV2
{
    /// <summary>
    /// A container that used to show the current beatmap's info.
    /// </summary>
    public class BeatmapSetInfoBox : CompositeDrawable
    {
        [Resolved]
        private CurrentWorkingBeatmap currentWorkingBeatmap { get; set; }

        public BeatmapCard BeatmapCard;

        [BackgroundDependencyLoader]
        private void load()
        {
            RelativeSizeAxes = Axes.Y;
            Size = new Vector2(750, 0.825f);
            Position = new Vector2(-20, 20);
            Masking = true;
            CornerRadius = 10;
            InternalChildren = new Drawable[]
            {
                new Box
                {
                    Anchor = Anchor.TopRight,
                    Origin = Anchor.TopRight,
                    Colour = MaisimColour.SongSelectionContainerColor,
                    Alpha = 0.5f,
                    RelativeSizeAxes = Axes.Both
                },
                BeatmapCard = new BeatmapCard
                {
                    Anchor = Anchor.TopRight,
                    Origin = Anchor.TopRight,
                },
                new GridContainer
                {
                    Anchor = Anchor.TopRight,
                    Origin = Anchor.TopRight,
                    Position = new Vector2(0, 160),
                    RelativeSizeAxes = Axes.X,
                    Size = new Vector2(1, 70),
                    Content = new[]
                    {
                        new Drawable[]
                        {
                            new DifficultySelectionButton(DifficultyLevel.Basic)
                            {
                                Action = () => currentWorkingBeatmap.SetCurrentDifficultyLevel(DifficultyLevel.Basic)
                            },
                            new DifficultySelectionButton(DifficultyLevel.Advanced)
                            {
                                Action = () => currentWorkingBeatmap.SetCurrentDifficultyLevel(DifficultyLevel.Advanced)
                            },
                            new DifficultySelectionButton(DifficultyLevel.Expert)
                            {
                                Action = () => currentWorkingBeatmap.SetCurrentDifficultyLevel(DifficultyLevel.Expert)
                            },
                            new DifficultySelectionButton(DifficultyLevel.Master)
                            {
                                Action = () => currentWorkingBeatmap.SetCurrentDifficultyLevel(DifficultyLevel.Master)
                            },
                        }
                    }
                },
            };
        }
    }
}
