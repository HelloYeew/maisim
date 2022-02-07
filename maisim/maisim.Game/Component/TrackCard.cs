using System.Globalization;
using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osuTK;
using osuTK.Graphics;

namespace maisim.Game.Component
{
    public class TrackCard : MaisimTrackCard
    {
        public TrackCard(string albumTextureName, string trackName, string artistName, float percentage, string rank, int dxscore, int dxscoreFull,
            bool allPerfect, bool fdxPlus, string noteDesigner, int bpm) : base(albumTextureName, trackName, artistName, percentage, rank, dxscore, dxscoreFull, allPerfect, fdxPlus, noteDesigner, bpm)
        {

        }

        [BackgroundDependencyLoader]
        private void load(TextureStore textureStore)
        {
            InternalChild = new Container
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Size = new Vector2(241, 312),
                Children = new Drawable[]
                {
                    new Box
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        RelativeSizeAxes = Axes.Both,
                        Colour = Color4Extensions.FromHex("#ff828d"),
                        Size = new Vector2(1)
                    },new GridContainer
                    {
                        RelativeSizeAxes = Axes.Both,
                        RowDimensions = new[]
                        {
                            new Dimension(GridSizeMode.Absolute, 230),
                            new Dimension(GridSizeMode.Absolute, 42),
                            new Dimension(GridSizeMode.Absolute, 40),
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
                                    Texture = textureStore.Get(albumTextureName),
                                    Scale = new Vector2(0.8f)
                                }
                            },new Drawable[]
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
                                            Colour = Color4Extensions.FromHex("#0d3d7d"),
                                            Size = new Vector2(0.9f, 0.9f)
                                        },new Container
                                        {
                                            Anchor = Anchor.TopCentre,
                                            Origin = Anchor.TopCentre,
                                            RelativeSizeAxes = Axes.Both,
                                            Size = new Vector2(0.9f, 0.9f),
                                            Child = new SpriteText
                                            {
                                                Anchor = Anchor.Centre,
                                                Origin = Anchor.Centre,
                                                Text = trackName,
                                                Font = new FontUsage(size : 25),
                                                Colour = Color4.White
                                            }
                                        }
                                    }
                                }
                            },new Drawable[]
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
                                                new Dimension(GridSizeMode.Absolute, 110),
                                                new Dimension(GridSizeMode.Absolute, 59),
                                                new Dimension(GridSizeMode.Absolute, 36),
                                                new Dimension(GridSizeMode.Absolute, 36)
                                            },
                                            Content = new[]
                                            {
                                                new Drawable[]
                                                {
                                                    new Container
                                                    {
                                                        Anchor = Anchor.TopCentre,
                                                        Origin = Anchor.TopCentre,
                                                        RelativeSizeAxes = Axes.Both,
                                                        Size = new Vector2(0.82f, 0.8f),
                                                        Children = new Drawable[]
                                                        {
                                                            new Box
                                                            {
                                                                Anchor = Anchor.TopCentre,
                                                                Origin = Anchor.TopCentre,
                                                                RelativeSizeAxes = Axes.Both,
                                                                Colour = Color4Extensions.FromHex("#1a497f"),
                                                            },new SpriteText
                                                            {
                                                                Anchor = Anchor.Centre,
                                                                Origin = Anchor.Centre,
                                                                Text = $"{percentage.ToString(CultureInfo.InvariantCulture)}%",
                                                                Font = new FontUsage(size: 20),
                                                                Colour = Color4.White
                                                            }
                                                        }
                                                    },new Container
                                                    {
                                                        Anchor = Anchor.TopCentre,
                                                        Origin = Anchor.TopCentre,
                                                        RelativeSizeAxes = Axes.Both,
                                                        Size = new Vector2(0.82f, 0.8f),
                                                        Children = new Drawable[]
                                                        {
                                                            new Box
                                                            {
                                                                Anchor = Anchor.TopCentre,
                                                                Origin = Anchor.TopCentre,
                                                                RelativeSizeAxes = Axes.Both,
                                                                Colour = Color4Extensions.FromHex("#1a497f"),
                                                            },new SpriteText
                                                            {
                                                                Anchor = Anchor.Centre,
                                                                Origin = Anchor.Centre,
                                                                Text = rank,
                                                                Font = new FontUsage(size: 20),
                                                                Colour = Color4.White
                                                            }
                                                        }
                                                    },new Container
                                                    {
                                                        Anchor = Anchor.TopLeft,
                                                        Origin = Anchor.TopLeft,
                                                        RelativeSizeAxes = Axes.Both,
                                                        Size = new Vector2(0.82f, 0.8f),
                                                        Children = new Drawable[]
                                                        {
                                                            new Circle
                                                            {
                                                                Anchor = Anchor.TopCentre,
                                                                Origin = Anchor.TopCentre,
                                                                RelativeSizeAxes = Axes.Both,
                                                                Colour = Color4Extensions.FromHex("#f0d285"),
                                                            },new SpriteText
                                                            {
                                                                Anchor = Anchor.Centre,
                                                                Origin = Anchor.Centre,
                                                                Text = "AP",
                                                                Font = new FontUsage(size: 14),
                                                                Colour = Color4Extensions.FromHex("#76301a")
                                                            }
                                                        }
                                                    },new Container
                                                    {
                                                        Anchor = Anchor.TopLeft,
                                                        Origin = Anchor.TopLeft,
                                                        RelativeSizeAxes = Axes.Both,
                                                        Size = new Vector2(0.82f, 0.8f),
                                                        Children = new Drawable[]
                                                        {
                                                            new Circle
                                                            {
                                                                Anchor = Anchor.TopCentre,
                                                                Origin = Anchor.TopCentre,
                                                                RelativeSizeAxes = Axes.Both,
                                                                Colour = Color4Extensions.FromHex("#f0d285"),
                                                            },new SpriteText
                                                            {
                                                                Anchor = Anchor.Centre,
                                                                Origin = Anchor.Centre,
                                                                Text = "FDX+",
                                                                Font = new FontUsage(size: 14),
                                                                Colour = Color4Extensions.FromHex("#76301a")
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
            };
        }

    }
}
