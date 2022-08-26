using maisim.Game.Beatmaps;
using maisim.Game.Graphics.Sprites;
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
    public class TrackMenuCard : CompositeDrawable
    {
        private readonly BeatmapSet beatmapSet;

        public TrackMenuCard(BeatmapSet beatmapSet)
        {
            this.beatmapSet = beatmapSet;
        }

        [BackgroundDependencyLoader]
        private void load(TextureStore textureStore)
        {
            Size = new Vector2(645, 127);
            // Add internal child as a grid container
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
                                            Anchor = Anchor.Centre,
                                            Origin = Anchor.Centre,
                                            Colour = Colour4.Pink,
                                            Size = new Vector2(130, 127),
                                        },
                                        new Container()
                                        {
                                            Anchor = Anchor.TopCentre,
                                            Origin = Anchor.TopCentre,
                                            Size = new Vector2(130, 63.5f),
                                            Children = new Drawable[]
                                            {
                                                // new Box()
                                                // {
                                                //     Anchor = Anchor.Centre,
                                                //     Origin = Anchor.Centre,
                                                //     Colour = Color4.White,
                                                //     Size = new Vector2(130, 63.5f),
                                                // },
                                                new SpriteIcon()
                                                {
                                                    Anchor = Anchor.TopLeft,
                                                    Origin = Anchor.TopLeft,
                                                    Size = new Vector2(26),
                                                    Position = new Vector2(10, 10),
                                                    Icon = FontAwesome.Solid.Star,
                                                    Colour = Color4.Black
                                                },
                                                new Container()
                                                {
                                                    Anchor = Anchor.TopRight,
                                                    Origin = Anchor.TopRight,
                                                    Position = new Vector2(-10, 10),
                                                    Size = new Vector2(78, 30),
                                                    Child = new MaisimSpriteText()
                                                    {
                                                        Anchor = Anchor.Centre,
                                                        Origin = Anchor.Centre,
                                                        Text = "3-31233",
                                                        Colour = Color4.Black,
                                                    }
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
