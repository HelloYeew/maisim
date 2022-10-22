using maisim.Game.Beatmaps;
using maisim.Game.Configuration;
using maisim.Game.Graphics.Sprites;
using maisim.Game.Graphics.UserInterface.Overlays;
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

        [Resolved]
        private CurrentWorkingBeatmap currentWorkingBeatmap { get; set; }

        [Resolved]
        private MaisimConfigManager gameConfig { get; set; }

        private bool useUnicodeInfo => gameConfig.Get<bool>(MaisimSetting.UseUnicodeInfo);

        private void difficultyLevelChanged(ValueChangedEvent<DifficultyLevel> difficultyLevelEvent) =>
            updateDifficultyLevel(difficultyLevelEvent.NewValue);

        private void beatmapSetChanged(ValueChangedEvent<BeatmapSet> beatmapSet) =>
            updateBeatmapSet(beatmapSet.NewValue);

        private void useUnicodeInfoSettingChanged(ValueChangedEvent<bool> useUnicodeInfo) =>
            updateBeatmapSet(currentWorkingBeatmap.BeatmapSet);

        [Resolved]
        private TextureStore textures { get; set; }

        private Box backgroundBox;
        private Sprite albumCover;
        private MaisimSpriteText titleText;
        private MaisimSpriteText artistText;
        private MaisimSpriteText sourceText;
        private MaisimSpriteText creatorText;

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
                                Colour = MaisimColour.GetDifficultyColor(currentWorkingBeatmap.DifficultyLevel)
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
                                                        Text = useUnicodeInfo ? currentWorkingBeatmap.BeatmapSet.TrackMetadata.TitleUnicode : currentWorkingBeatmap.BeatmapSet.TrackMetadata.Title,
                                                        Font = MaisimFont.GetFont(size:40, weight:MaisimFont.FontWeight.Black),
                                                        Position = new Vector2(0, 5)
                                                    },
                                                    artistText = new MaisimSpriteText()
                                                    {
                                                        Anchor = Anchor.TopLeft,
                                                        Origin = Anchor.TopLeft,
                                                        Text = useUnicodeInfo ? currentWorkingBeatmap.BeatmapSet.TrackMetadata.ArtistUnicode : currentWorkingBeatmap.BeatmapSet.TrackMetadata.Artist,
                                                        Font = MaisimFont.GetFont(size:30, weight:MaisimFont.FontWeight.Medium),
                                                        Position = new Vector2(0, 46)
                                                    },
                                                    sourceText = new MaisimSpriteText()
                                                    {
                                                        Anchor = Anchor.BottomLeft,
                                                        Origin = Anchor.BottomLeft,
                                                        Text = $"From {currentWorkingBeatmap.BeatmapSet.TrackMetadata.Source}",
                                                        Font = MaisimFont.GetFont(size:20, weight:MaisimFont.FontWeight.Medium),
                                                        Position = new Vector2(0, -30)
                                                    },
                                                    creatorText = new MaisimSpriteText()
                                                    {
                                                        Anchor = Anchor.BottomLeft,
                                                        Origin = Anchor.BottomLeft,
                                                        Text = $"beatmap by {BeatmapUtils.GetNoteDesignerFromBeatmapSet(currentWorkingBeatmap.BeatmapSet, currentWorkingBeatmap.DifficultyLevel)}",
                                                        Font = MaisimFont.GetFont(size:20, weight:MaisimFont.FontWeight.Medium),
                                                        Position = new Vector2(0, -5)
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

            currentWorkingBeatmap.BindDifficultyLevelChanged(difficultyLevelChanged, true);
            currentWorkingBeatmap.BindBeatmapSetChanged(beatmapSetChanged, true);
            gameConfig.GetBindable<bool>(MaisimSetting.UseUnicodeInfo).BindValueChanged(useUnicodeInfoSettingChanged, true);
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
            titleText.Text = useUnicodeInfo ? newBeatmapSet.TrackMetadata.TitleUnicode : newBeatmapSet.TrackMetadata.Title;
            artistText.Text = useUnicodeInfo ? newBeatmapSet.TrackMetadata.ArtistUnicode : newBeatmapSet.TrackMetadata.Artist;
            sourceText.Text = $"From {newBeatmapSet.TrackMetadata.Source}";
            creatorText.Text = $"beatmap by {BeatmapUtils.GetNoteDesignerFromBeatmapSet(newBeatmapSet, currentWorkingBeatmap.DifficultyLevel)}";
        }
    }
}
