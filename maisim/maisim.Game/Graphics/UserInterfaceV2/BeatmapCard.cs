using maisim.Game.Beatmaps;
using maisim.Game.Graphics.Sprites;
using maisim.Game.Utils;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osuTK;

namespace maisim.Game.Graphics.UserInterfaceV2
{
    /// <summary>
    /// A box that's show the info of current binding <see cref="Beatmap"/> inside <see cref="BeatmapSetInfoBox"/>.
    /// </summary>
    public class BeatmapCard : CompositeDrawable
    {
        public static readonly float FADE_COLOR_DURATION = 500;

        private Bindable<DifficultyLevel> bindableDifficultyLevel;

        private Bindable<BeatmapSet> bindableBeatmapSet;

        private DifficultyLevel difficultyLevel;

        private BeatmapSet beatmapSet;

        private void difficultyLevelChanged(ValueChangedEvent<DifficultyLevel> difficultyLevelEvent) =>
            updateDifficultyLevel(difficultyLevelEvent.NewValue);

        private void beatmapSetChanged(ValueChangedEvent<BeatmapSet> beatmapSet) =>
            updateBeatmapSet(beatmapSet.NewValue);

        [Resolved]
        private TextureStore textures { get; set; }

        private Box backgroundBox;
        private Sprite albumCover;
        private MaisimSpriteText titleText;
        private MaisimSpriteText artistText;
        private MaisimSpriteText creatorText;

        public BeatmapCard(Bindable<DifficultyLevel> bindableDifficultyLevel, Bindable<BeatmapSet> bindableBeatmapSet)
        {
            this.bindableDifficultyLevel = bindableDifficultyLevel;
            this.bindableBeatmapSet = bindableBeatmapSet;
        }

        [BackgroundDependencyLoader]
        private void load(TextureStore textureStore)
        {
            RelativeSizeAxes = Axes.X;
            Size = new Vector2(1, 170);
            InternalChildren = new Drawable[]
            {
                new Container()
                {
                    Anchor = Anchor.TopRight,
                    Origin = Anchor.TopRight,
                    RelativeSizeAxes = Axes.Both,
                    Padding = new MarginPadding(10),
                    Child = new Container()
                    {
                        RelativeSizeAxes = Axes.Both,
                        CornerRadius = 10,
                        Masking = true,
                        Children = new Drawable[]
                        {
                            backgroundBox = new Box()
                            {
                                Anchor = Anchor.TopRight,
                                Origin = Anchor.TopRight,
                                RelativeSizeAxes = Axes.Both,
                                Colour = MaisimColour.GetDifficultyColor(bindableDifficultyLevel.Value)
                            },
                            new GridContainer()
                            {
                                Anchor = Anchor.Centre,
                                Origin = Anchor.Centre,
                                RelativeSizeAxes = Axes.Both,
                                ColumnDimensions = new []
                                {
                                    new Dimension(GridSizeMode.Relative, 0.2f),
                                    new Dimension(GridSizeMode.Relative, 0.8f)
                                },
                                Content = new[]
                                {
                                    new Drawable[]
                                    {
                                        new Container()
                                        {
                                            Anchor = Anchor.TopLeft,
                                            Origin = Anchor.TopLeft,
                                            RelativeSizeAxes = Axes.Both,
                                            Padding = new MarginPadding(10),
                                            Child = new Container()
                                            {
                                                Anchor = Anchor.Centre,
                                                Origin = Anchor.Centre,
                                                RelativeSizeAxes = Axes.Both,
                                                CornerRadius = 10,
                                                Masking = true,
                                                Child = albumCover = new Sprite()
                                                {
                                                    Anchor = Anchor.Centre,
                                                    Origin = Anchor.Centre,
                                                    RelativeSizeAxes = Axes.Both,
                                                    FillMode = FillMode.Fill,
                                                }
                                            }
                                        },
                                        new Container()
                                        {
                                            Anchor = Anchor.TopLeft,
                                            Origin = Anchor.TopLeft,
                                            RelativeSizeAxes = Axes.Both,
                                            Child = new Container()
                                            {
                                                Anchor = Anchor.CentreLeft,
                                                Origin = Anchor.CentreLeft,
                                                RelativeSizeAxes = Axes.Both,
                                                Padding = new MarginPadding(10),
                                                Children = new Drawable[]
                                                {
                                                    titleText = new MaisimSpriteText()
                                                    {
                                                        Anchor = Anchor.TopLeft,
                                                        Origin = Anchor.TopLeft,
                                                        Text = "Sukino Skill",
                                                        Font = MaisimFont.GetFont(size:40, weight:MaisimFont.FontWeight.Black),
                                                        Position = new Vector2(0, 5)
                                                    },
                                                    artistText = new MaisimSpriteText()
                                                    {
                                                        Anchor = Anchor.CentreLeft,
                                                        Origin = Anchor.CentreLeft,
                                                        Text = "Wake Up, Girls!",
                                                        Font = MaisimFont.GetFont(size:30, weight:MaisimFont.FontWeight.Medium)
                                                    },
                                                    creatorText = new MaisimSpriteText()
                                                    {
                                                        Anchor = Anchor.BottomLeft,
                                                        Origin = Anchor.BottomLeft,
                                                        Text = $"beatmap by {BeatmapUtils.GetNoteDesignerFromBeatmapSet(bindableBeatmapSet.Value, bindableDifficultyLevel.Value)}",
                                                        Font = MaisimFont.GetFont(size:20, weight:MaisimFont.FontWeight.Medium),
                                                        Position = new Vector2(0, -15)
                                                    },
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            bindableDifficultyLevel.BindValueChanged(difficultyLevelChanged, true);
            bindableBeatmapSet.BindValueChanged(beatmapSetChanged, true);
        }

        /// <summary>
        /// Update the related element that use <see cref="difficultyLevel"/>. This method will be called when <see cref="difficultyLevel"/> changed.
        /// </summary>
        /// <param name="newDifficultyLevel">New <see cref="DifficultyLevel"/> value</param>
        private void updateDifficultyLevel(DifficultyLevel newDifficultyLevel)
        {
            backgroundBox.FadeColour(MaisimColour.GetDifficultyColor(newDifficultyLevel), FADE_COLOR_DURATION, Easing.OutQuint);
        }

        /// <summary>
        /// Update the related element that use <see cref="beatmapSet"/>. This method will be called when <see cref="beatmapSet"/> changed.
        /// </summary>
        /// <param name="newBeatmapSet">New <see cref="BeatmapSet"/> value</param>
        private void updateBeatmapSet(BeatmapSet newBeatmapSet)
        {
            albumCover.Texture = textures.Get(newBeatmapSet.TrackMetadata.CoverPath);
            titleText.Text = newBeatmapSet.TrackMetadata.Title;
            artistText.Text = newBeatmapSet.TrackMetadata.Artist;
            creatorText.Text = $"beatmap by {BeatmapUtils.GetNoteDesignerFromBeatmapSet(newBeatmapSet, bindableDifficultyLevel.Value)}";
        }
    }
}
