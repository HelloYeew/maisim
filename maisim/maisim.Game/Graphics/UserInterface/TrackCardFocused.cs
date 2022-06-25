using maisim.Game.Beatmaps;
using maisim.Game.Graphics;
using maisim.Game.Graphics.Sprites;
using maisim.Game.Scores;
using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Extensions.LocalisationExtensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osuTK;
using osuTK.Graphics;

namespace maisim.Game.Component
{
    /// <summary>
    /// A track card that displays information about a track that is focused / selected.
    /// </summary>
    public class TrackCardFocused : MaisimTrackCard
    {
        public TrackCardFocused(Beatmap beatmap, Score score) : base(beatmap, score)
        {
        }

        [BackgroundDependencyLoader]
        private void load(TextureStore textureStore)
        {
            InternalChild = new Container
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Size = new Vector2(300, 384),
                Children = new Drawable[]
                {
                    new Box
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        RelativeSizeAxes = Axes.Both,
                        Colour = MaisimColour.GetDifficultyColor(beatmap.DifficultyLevel),
                        Size = new Vector2(1)
                    },
                    new GridContainer
                    {
                        RelativeSizeAxes = Axes.Both,
                        RowDimensions = new[]
                        {
                            new Dimension(GridSizeMode.Absolute, 205),
                            new Dimension(GridSizeMode.Absolute, 75),
                            new Dimension(GridSizeMode.Absolute, 65),
                            new Dimension(GridSizeMode.Absolute, 40)
                        },
                        Content = new[]
                        {
                            new Drawable[]
                            {
                                new Sprite
                                {
                                    RelativeSizeAxes = Axes.Both,
                                    Anchor = Anchor.Centre,
                                    Origin = Anchor.Centre,
                                    FillMode = FillMode.Fill,
                                    Texture = textureStore.Get(beatmap.TrackMetadata.CoverPath),
                                    Scale = new Vector2(0.6f)
                                }
                            },
                            new Drawable[]
                            {
                                new Container
                                {
                                    RelativeSizeAxes = Axes.Both,
                                    Children = new Drawable[]
                                    {
                                        new Box
                                        {
                                            Anchor = Anchor.TopCentre,
                                            Origin = Anchor.TopCentre,
                                            RelativeSizeAxes = Axes.Both,
                                            Colour = Color4Extensions.FromHex("#003d7d"),
                                            Size = new Vector2(0.9f, 0.5f)
                                        },
                                        new Box
                                        {
                                            Anchor = Anchor.BottomCentre,
                                            Origin = Anchor.BottomCentre,
                                            RelativeSizeAxes = Axes.Both,
                                            Colour = Color4Extensions.FromHex("#0c2e5e"),
                                            Size = new Vector2(0.9f, 0.5f)
                                        },
                                        new Container
                                        {
                                            Anchor = Anchor.TopCentre,
                                            Origin = Anchor.TopCentre,
                                            RelativeSizeAxes = Axes.Both,
                                            Size = new Vector2(0.9f, 0.5f),
                                            Child = new MaisimSpriteText
                                            {
                                                Anchor = Anchor.Centre,
                                                Origin = Anchor.Centre,
                                                Text = beatmap.TrackMetadata.Title,
                                                Colour = Color4.White
                                            }
                                        },
                                        new Container
                                        {
                                            Anchor = Anchor.BottomCentre,
                                            Origin = Anchor.BottomCentre,
                                            RelativeSizeAxes = Axes.Both,
                                            Size = new Vector2(0.9f, 0.5f),
                                            Child = new MaisimSpriteText
                                            {
                                                Anchor = Anchor.Centre,
                                                Origin = Anchor.Centre,
                                                Text = beatmap.TrackMetadata.Artist,
                                                Colour = Color4Extensions.FromHex("#b8b8b8")
                                            }
                                        }
                                    }
                                }
                            },
                            new Drawable[]
                            {
                                new Container
                                {
                                    RelativeSizeAxes = Axes.Both,
                                    Children = new Drawable[]
                                    {
                                        new GridContainer
                                        {
                                            RelativeSizeAxes = Axes.Both,
                                            ColumnDimensions = new[]
                                            {
                                                new Dimension(GridSizeMode.Absolute, 172),
                                                new Dimension(GridSizeMode.Absolute, 129)
                                            },
                                            Content = new[]
                                            {
                                                new Drawable[]
                                                {
                                                    new Container
                                                    {
                                                        Anchor = Anchor.Centre,
                                                        Origin = Anchor.Centre,
                                                        RelativeSizeAxes = Axes.Both,
                                                        Size = new Vector2(0.82f, 0.8f),
                                                        Child = new GridContainer
                                                        {
                                                            RelativeSizeAxes = Axes.Both,
                                                            ColumnDimensions = new[]
                                                            {
                                                                new Dimension(GridSizeMode.Absolute, 105),
                                                                new Dimension(GridSizeMode.Absolute, 24)
                                                            },
                                                            Content = new[]
                                                            {
                                                                new Drawable[]
                                                                {
                                                                    new Container
                                                                    {
                                                                        Anchor = Anchor.TopLeft,
                                                                        Origin = Anchor.TopLeft,
                                                                        RelativeSizeAxes = Axes.Both,
                                                                        Scale = new Vector2(0.9f),
                                                                        Children = new Drawable[]
                                                                        {
                                                                            new Box
                                                                            {
                                                                                Anchor = Anchor.TopLeft,
                                                                                Origin = Anchor.TopLeft,
                                                                                RelativeSizeAxes = Axes.Both,
                                                                                Colour = Color4Extensions.FromHex(
                                                                                    "#1a497f")
                                                                            },
                                                                            new MaisimSpriteText
                                                                            {
                                                                                Anchor = Anchor.Centre,
                                                                                Origin = Anchor.Centre,
                                                                                Text = score.Accuracy
                                                                                    .ToLocalisableString("0.0000\\%"),
                                                                                Font = MaisimFont.GetFont(size: 20),
                                                                                Colour = Color4.White
                                                                            }
                                                                        }
                                                                    },
                                                                    new Container
                                                                    {
                                                                        Anchor = Anchor.TopRight,
                                                                        Origin = Anchor.TopRight,
                                                                        RelativeSizeAxes = Axes.Both,
                                                                        Scale = new Vector2(0.9f),
                                                                        Children = new Drawable[]
                                                                        {
                                                                            new Box
                                                                            {
                                                                                Anchor = Anchor.TopRight,
                                                                                Origin = Anchor.TopRight,
                                                                                RelativeSizeAxes = Axes.Both,
                                                                                Colour = Color4Extensions.FromHex(
                                                                                    "#1a497f")
                                                                            },
                                                                            new MaisimSpriteText
                                                                            {
                                                                                Anchor = Anchor.Centre,
                                                                                Origin = Anchor.Centre,
                                                                                Text = ScoreRankExtensions.ToString(
                                                                                    score.Rank),
                                                                                Font = MaisimFont.GetFont(size: 20),
                                                                                Colour = Color4.White
                                                                            }
                                                                        }
                                                                    }
                                                                },
                                                                new Drawable[]
                                                                {
                                                                    new Container
                                                                    {
                                                                        Anchor = Anchor.TopLeft,
                                                                        Origin = Anchor.TopLeft,
                                                                        RelativeSizeAxes = Axes.Both,
                                                                        Scale = new Vector2(1.35f, 1),
                                                                        Children = new Drawable[]
                                                                        {
                                                                            new Box
                                                                            {
                                                                                Anchor = Anchor.TopLeft,
                                                                                Origin = Anchor.TopLeft,
                                                                                RelativeSizeAxes = Axes.Both,
                                                                                Colour = Color4Extensions.FromHex(
                                                                                    "#1a497f")
                                                                            },
                                                                            new MaisimSpriteText
                                                                            {
                                                                                Anchor = Anchor.CentreLeft,
                                                                                Origin = Anchor.CentreLeft,
                                                                                Text = "DXSCORE",
                                                                                Font = MaisimFont.GetFont(size: 13),
                                                                                Colour = Color4Extensions.FromHex(
                                                                                    "#9cdb96")
                                                                            },
                                                                            new MaisimSpriteText
                                                                            {
                                                                                Anchor = Anchor.CentreRight,
                                                                                Origin = Anchor.CentreRight,
                                                                                Text =
                                                                                    $"{score.SeasonalScore.ToString()}/{beatmap.MaxSeasonalScore.ToString()}",
                                                                                Font = MaisimFont.GetFont(size: 13),
                                                                                Colour = Color4.White
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    },
                                                    new Container
                                                    {
                                                        // TODO: Implement the parameter to this container
                                                        Anchor = Anchor.Centre,
                                                        Origin = Anchor.Centre,
                                                        RelativeSizeAxes = Axes.Both,
                                                        Size = new Vector2(0.82f, 0.8f),
                                                        Child = new GridContainer
                                                        {
                                                            RelativeSizeAxes = Axes.Both,
                                                            Content = new[]
                                                            {
                                                                new Drawable[]
                                                                {
                                                                    new Container
                                                                    {
                                                                        Anchor = Anchor.Centre,
                                                                        Origin = Anchor.Centre,
                                                                        RelativeSizeAxes = Axes.Both,
                                                                        Children = new Drawable[]
                                                                        {
                                                                            new Circle
                                                                            {
                                                                                Anchor = Anchor.Centre,
                                                                                Origin = Anchor.Centre,
                                                                                RelativeSizeAxes = Axes.Both,
                                                                                Colour = Color4Extensions.FromHex(
                                                                                    "#f0d285")
                                                                            },
                                                                            new MaisimSpriteText
                                                                            {
                                                                                Anchor = Anchor.Centre,
                                                                                Origin = Anchor.Centre,
                                                                                Text = "AP",
                                                                                Font = MaisimFont.GetFont(size: 20),
                                                                                Colour = Color4Extensions.FromHex(
                                                                                    "#76301a")
                                                                            }
                                                                        }
                                                                    },
                                                                    new Container
                                                                    {
                                                                        Anchor = Anchor.Centre,
                                                                        Origin = Anchor.Centre,
                                                                        RelativeSizeAxes = Axes.Both,
                                                                        Children = new Drawable[]
                                                                        {
                                                                            new Circle
                                                                            {
                                                                                Anchor = Anchor.Centre,
                                                                                Origin = Anchor.Centre,
                                                                                RelativeSizeAxes = Axes.Both,
                                                                                Colour = Color4Extensions.FromHex(
                                                                                    "#f0d285")
                                                                            },
                                                                            new MaisimSpriteText
                                                                            {
                                                                                Anchor = Anchor.Centre,
                                                                                Origin = Anchor.Centre,
                                                                                Text = "FDX+",
                                                                                Font = MaisimFont.GetFont(size: 20),
                                                                                Colour = Color4Extensions.FromHex(
                                                                                    "#76301a")
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            },
                            new Drawable[]
                            {
                                new Container
                                {
                                    RelativeSizeAxes = Axes.Both,
                                    Children = new Drawable[]
                                    {
                                        new MaisimSpriteText
                                        {
                                            Anchor = Anchor.TopLeft,
                                            Origin = Anchor.TopLeft,
                                            Text = "NOTES DESIGNER",
                                            Font = MaisimFont.GetFont(size: 12),
                                            Colour = Color4.Black
                                        },
                                        new MaisimSpriteText
                                        {
                                            Anchor = Anchor.BottomLeft,
                                            Origin = Anchor.BottomLeft,
                                            Text = beatmap.NoteDesigner,
                                            Colour = Color4.Black
                                        },
                                        new MaisimSpriteText
                                        {
                                            Anchor = Anchor.BottomRight,
                                            Origin = Anchor.BottomRight,
                                            Text = $"BPM {beatmap.TrackMetadata.Bpm.ToString()}",
                                            Colour = Color4.Black
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}
