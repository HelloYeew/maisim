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
                        Colour = Color4Extensions.FromHex("#8FD7FF"),
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
                                    CornerRadius = 30,
                                    Child = new Sprite()
                                    {
                                        Anchor = Anchor.Centre,
                                        Origin = Anchor.Centre,
                                        Size = new Vector2(98, 98),
                                        FillMode = FillMode.Fill,
                                        Texture = textureStore.Get("Test/sukino-skill.jpg")
                                    }
                                },
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
                                                Text = "Title",
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
                                                Text = "Artists",
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
                                    Child = new Box()
                                    {
                                        Anchor = Anchor.Centre,
                                        Origin = Anchor.Centre,
                                        Colour = Colour4.Pink,
                                        Size = new Vector2(130, 127),
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
