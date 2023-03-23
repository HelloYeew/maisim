using System.Globalization;
using maisim.Game.Beatmaps;
using maisim.Game.Configuration;
using maisim.Game.Graphics.Sprites;
using maisim.Game.Utils;
using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Localisation;
using osuTK;
using osuTK.Graphics;

namespace maisim.Game.Graphics.UserInterfaceV2
{
    /// <summary>
    /// The beatmap set card that is displayed in the beatmap selection screen.
    /// </summary>
    public partial class BeatmapSetCard : CompositeDrawable
    {
        [Resolved]
        private MaisimConfigManager gameConfig { get; set; }

        protected internal readonly BeatmapSet BeatmapSet;
        private MaisimSpriteText title;
        private MaisimSpriteText artist;

        public const float CARD_WIDTH = 645;
        public const float CARD_HEIGHT = 127;

        public BeatmapSetCard(BeatmapSet beatmapSet)
        {
            BeatmapSet = beatmapSet;
        }

        [BackgroundDependencyLoader]
        private void load(TextureStore textureStore)
        {
            Size = new Vector2(CARD_WIDTH, CARD_HEIGHT);
            InternalChild = new Container
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Size = new Vector2(CARD_WIDTH, CARD_HEIGHT),
                Masking = true,
                CornerRadius = 10,
                Children = new Drawable[]
                {
                    new Box()
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Colour = Color4Extensions.FromHex("#8FD7FF"),
                        Size = new Vector2(CARD_WIDTH, CARD_HEIGHT)
                    },
                    new GridContainer()
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Size = new Vector2(CARD_WIDTH, CARD_HEIGHT),
                        ColumnDimensions = new[]
                        {
                            new Dimension(GridSizeMode.Absolute, 127),
                            new Dimension(GridSizeMode.Absolute, 388),
                            new Dimension(GridSizeMode.Absolute, 130)
                        },
                        Content = new[]
                        {
                            new Drawable[]
                            {
                                new Container
                                {
                                    Anchor = Anchor.Centre,
                                    Origin = Anchor.Centre,
                                    Size = new Vector2(CARD_HEIGHT, CARD_HEIGHT),
                                    Masking = true,
                                    CornerRadius = 30,
                                    Children = new Drawable[]
                                    {
                                        new Sprite()
                                        {
                                            Anchor = Anchor.Centre,
                                            Origin = Anchor.Centre,
                                            Size = new Vector2(98, 98),
                                            FillMode = FillMode.Fill,
                                            Texture = textureStore.Get(BeatmapSet.TrackMetadata.CoverPath)
                                        }
                                    }
                                },
                                new Container
                                {
                                    RelativeSizeAxes = Axes.Both,
                                    Masking = true,
                                    CornerRadius = 30,
                                    Children = new Drawable[]
                                    {
                                        new Box
                                        {
                                            Anchor = Anchor.TopCentre,
                                            Origin = Anchor.TopCentre,
                                            RelativeSizeAxes = Axes.Both,
                                            Colour = Color4Extensions.FromHex("#003d7d"),
                                            Size = new Vector2(0.9f, 0.45f),
                                            Position = new Vector2(0, 10)
                                        },
                                        new Box
                                        {
                                            Anchor = Anchor.BottomCentre,
                                            Origin = Anchor.BottomCentre,
                                            RelativeSizeAxes = Axes.Both,
                                            Colour = Color4Extensions.FromHex("#0c2e5e"),
                                            Size = new Vector2(0.9f, 0.45f),
                                            Position = new Vector2(0, -10)
                                        },
                                        new Container
                                        {
                                            Anchor = Anchor.TopCentre,
                                            Origin = Anchor.TopCentre,
                                            RelativeSizeAxes = Axes.Both,
                                            Size = new Vector2(0.9f, 0.5f),
                                            Position = new Vector2(0, 5),
                                            Child = title = new MaisimSpriteText
                                            {
                                                Anchor = Anchor.Centre,
                                                Origin = Anchor.Centre,
                                                Text = gameConfig.Get<bool>(MaisimSetting.UseUnicodeInfo) ? BeatmapSet.TrackMetadata.TitleUnicode : BeatmapSet.TrackMetadata.Title,
                                                Colour = Color4.White
                                            }
                                        },
                                        new Container
                                        {
                                            Anchor = Anchor.BottomCentre,
                                            Origin = Anchor.BottomCentre,
                                            RelativeSizeAxes = Axes.Both,
                                            Size = new Vector2(0.9f, 0.5f),
                                            Position = new Vector2(0, -5),
                                            Child = artist = new MaisimSpriteText
                                            {
                                                Anchor = Anchor.Centre,
                                                Origin = Anchor.Centre,
                                                Text = gameConfig.Get<bool>(MaisimSetting.UseUnicodeInfo) ? BeatmapSet.TrackMetadata.ArtistUnicode : BeatmapSet.TrackMetadata.Artist,
                                                Colour = Color4Extensions.FromHex("#b8b8b8")
                                            }
                                        }
                                    }
                                },
                                new Container
                                {
                                    Anchor = Anchor.Centre,
                                    Origin = Anchor.Centre,
                                    Size = new Vector2(130, CARD_HEIGHT),
                                    Children = new Drawable[]
                                    {
                                        new Container()
                                        {
                                            Anchor = Anchor.TopCentre,
                                            Origin = Anchor.TopCentre,
                                            Size = new Vector2(130, 63.5f),
                                            Children = new Drawable[]
                                            {
                                                new SpriteIcon()
                                                {
                                                    Anchor = Anchor.TopLeft,
                                                    Origin = Anchor.TopLeft,
                                                    Size = new Vector2(26),
                                                    Position = new Vector2(15.875f, 15.875f),
                                                    Icon = FontAwesome.Solid.Star,
                                                    Colour = Color4.Black
                                                },
                                                new Container()
                                                {
                                                    Anchor = Anchor.TopRight,
                                                    Origin = Anchor.TopRight,
                                                    Position = new Vector2(-15.875f, 15.875f),
                                                    Size = new Vector2(78, 30),
                                                    Child = new MaisimSpriteText()
                                                    {
                                                        Anchor = Anchor.Centre,
                                                        Origin = Anchor.Centre,
                                                        Text = BeatmapUtils.GetDifficultyRatingRange(BeatmapSet).Item1.ToString(CultureInfo.CurrentCulture) + " - " + BeatmapUtils.GetDifficultyRatingRange(BeatmapSet).Item2.ToString(CultureInfo.CurrentCulture),
                                                        Colour = Color4.Black,
                                                    }
                                                }
                                            }
                                        },
                                        new GridContainer()
                                        {
                                            Anchor = Anchor.Centre,
                                            Origin = Anchor.Centre,
                                            Size = new Vector2(130, 63.5f),
                                            Position = new Vector2(0, 31.75f),
                                            Content = new[]
                                            {
                                                new Drawable[]
                                                {
                                                    new Container()
                                                    {
                                                        Anchor = Anchor.Centre,
                                                        Origin = Anchor.Centre,
                                                        Size = new Vector2(25),
                                                        Child = new Circle()
                                                        {
                                                            Anchor = Anchor.Centre,
                                                            Origin = Anchor.Centre,
                                                            Size = new Vector2(25),
                                                            Colour = MaisimColour.GetDifficultyColor(DifficultyLevel.Basic)
                                                        }
                                                    },
                                                    new Container()
                                                    {
                                                        Anchor = Anchor.Centre,
                                                        Origin = Anchor.Centre,
                                                        Size = new Vector2(25),
                                                        Child = new Circle()
                                                        {
                                                            Anchor = Anchor.Centre,
                                                            Origin = Anchor.Centre,
                                                            Size = new Vector2(25),
                                                            Colour = MaisimColour.GetDifficultyColor(DifficultyLevel.Advanced)
                                                        }
                                                    },
                                                    new Container()
                                                    {
                                                        Anchor = Anchor.Centre,
                                                        Origin = Anchor.Centre,
                                                        Size = new Vector2(25),
                                                        Child = new Circle()
                                                        {
                                                            Anchor = Anchor.Centre,
                                                            Origin = Anchor.Centre,
                                                            Size = new Vector2(25),
                                                            Colour = MaisimColour.GetDifficultyColor(DifficultyLevel.Expert)
                                                        }
                                                    },
                                                    new Container()
                                                    {
                                                        Anchor = Anchor.Centre,
                                                        Origin = Anchor.Centre,
                                                        Size = new Vector2(25),
                                                        Child = new Circle()
                                                        {
                                                            Anchor = Anchor.Centre,
                                                            Origin = Anchor.Centre,
                                                            Size = new Vector2(25),
                                                            Colour = MaisimColour.GetDifficultyColor(DifficultyLevel.Master)
                                                        }
                                                    },
                                                }
                                            }
                                        }
                                    }
                                },
                            }
                        }
                    },
                }
            };
        }

        protected override void Update()
        {
            base.Update();
            title.Text = gameConfig.Get<bool>(MaisimSetting.UseUnicodeInfo) ? BeatmapSet.TrackMetadata.TitleUnicode : BeatmapSet.TrackMetadata.Title;
            artist.Text = gameConfig.Get<bool>(MaisimSetting.UseUnicodeInfo) ? BeatmapSet.TrackMetadata.ArtistUnicode : BeatmapSet.TrackMetadata.Artist;
        }

        /// <summary>
        /// Return the current value of the text used in the title <see cref="MaisimSpriteText"/>.
        /// </summary>
        /// <returns>The title text used in <see cref="MaisimSpriteText"/>.</returns>
        public LocalisableString GetTitle()
        {
            return title.Text;
        }

        /// <summary>
        /// Return the current value of the text used in the artist <see cref="MaisimSpriteText"/>.
        /// </summary>
        /// <returns>The artist text used in <see cref="MaisimSpriteText"/>.</returns>
        public LocalisableString GetArtist()
        {
            return artist.Text;
        }
    }
}
