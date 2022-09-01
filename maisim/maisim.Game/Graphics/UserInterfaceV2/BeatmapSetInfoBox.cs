using maisim.Game.Beatmaps;
using maisim.Game.Graphics.Sprites;
using maisim.Game.Graphics.UserInterface;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.UserInterface;
using osuTK;
using osuTK.Graphics;

namespace maisim.Game.Graphics.UserInterfaceV2
{
    /// <summary>
    /// A container that used to show the current beatmap's info.
    /// </summary>
    public class BeatmapSetInfoBox : CompositeDrawable
    {
        // TODO: Consider to move to DI's working beatmap bindable when implemented.
        private Bindable<DifficultyLevel> bindableDifficultyLevel;

        private Bindable<BeatmapSet> bindableBeatmapSet;

        public BeatmapSetInfoBox(Bindable<DifficultyLevel> bindableDifficultyLevel, Bindable<BeatmapSet> bindableBeatmapSet)
        {
            this.bindableDifficultyLevel = bindableDifficultyLevel;
            this.bindableBeatmapSet = bindableBeatmapSet;
        }

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
                new BeatmapCard(bindableDifficultyLevel, bindableBeatmapSet)
                {
                    Anchor = Anchor.TopRight,
                    Origin = Anchor.TopRight,
                },
                new GridContainer()
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
                                Action = () => bindableDifficultyLevel.Value = DifficultyLevel.Basic
                            },
                            new DifficultySelectionButton(DifficultyLevel.Advanced)
                            {
                                Action = () => bindableDifficultyLevel.Value = DifficultyLevel.Advanced
                            },
                            new DifficultySelectionButton(DifficultyLevel.Expert)
                            {
                                Action = () => bindableDifficultyLevel.Value = DifficultyLevel.Expert
                            },
                            new DifficultySelectionButton(DifficultyLevel.Master)
                            {
                                Action = () => bindableDifficultyLevel.Value = DifficultyLevel.Master
                            },
                        }
                    }
                },
            };
        }
    }
}
