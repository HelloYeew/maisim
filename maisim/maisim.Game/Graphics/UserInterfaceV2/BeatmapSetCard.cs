using System.Globalization;
using maisim.Game.Beatmaps;
using maisim.Game.Graphics.Sprites;
using maisim.Game.Utils;
using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osuTK;
using osuTK.Graphics;

namespace maisim.Game.Graphics.UserInterfaceV2
{
    /// <summary>
    /// The beatmap set card that is displayed in the beatmap selection screen.
    /// </summary>
    public class BeatmapSetCard : CompositeDrawable
    {
        private readonly BeatmapSet beatmapSet;

        public BeatmapSetCard(BeatmapSet beatmapSet)
        {
            this.beatmapSet = beatmapSet;
        }

        [BackgroundDependencyLoader]
        private void load(TextureStore textureStore)
        {
            Size = new Vector2(645, 127);
            InternalChild = new Container
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Size = new Vector2(645, 127),
                Masking = true,
                CornerRadius = 10,
                Children = new Drawable[]
                {
                    new Box()
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Colour = Color4Extensions.FromHex("#8FD7FF"),
                        Size = new Vector2(645, 127)
                    },
                    new GridContainer()
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Size = new Vector2(645, 127),
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
                                    Size = new Vector2(127, 127),
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
                                            Texture = textureStore.Get(beatmapSet.TrackMetadata.CoverPath)
                                        }
                                    }
                                },
                                new Container
                                {
                                    RelativeSizeAxes = Axes.Both,
                                    CornerRadius = 20,
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
                                            Child = new MaisimSpriteText
                                            {
                                                Anchor = Anchor.Centre,
                                                Origin = Anchor.Centre,
                                                Text = beatmapSet.TrackMetadata.Title,
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
                                            Child = new MaisimSpriteText
                                            {
                                                Anchor = Anchor.Centre,
                                                Origin = Anchor.Centre,
                                                Text = beatmapSet.TrackMetadata.Artist,
                                                Colour = Color4Extensions.FromHex("#b8b8b8")
                                            }
                                        }
                                    }
                                },
                                new Container
                                {
                                    Anchor = Anchor.Centre,
                                    Origin = Anchor.Centre,
                                    Size = new Vector2(130, 127),
                                    Children = new Drawable[]
                                    {
                                        new Box()
                                        {
                                            Anchor = Anchor.TopCentre,
                                            Origin = Anchor.TopCentre,
                                            Colour = Colour4.Pink,
                                            Size = new Vector2(130, 63.5f),
                                        },
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
                                                        Text = BeatmapUtils.GetDifficultyRatingRange(beatmapSet).Item1.ToString(CultureInfo.CurrentCulture) + " - " + BeatmapUtils.GetDifficultyRatingRange(beatmapSet).Item2.ToString(CultureInfo.CurrentCulture),
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
    }
}
