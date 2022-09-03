using System;
using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using maisim.Game.Graphics.Gameplay;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osuTK;

namespace maisim.Game.Graphics.UserInterface
{
    /// <summary>
    /// The game's logo
    /// </summary>
    public class MaisimLogo : CompositeDrawable
    {
        private static float buttonMultilplier = 119f;

        [BackgroundDependencyLoader]
        private void load(TextureStore textureStore)
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            Size = new Vector2(300);
            InternalChild = new Container()
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
                        Colour = Color4Extensions.FromHex("DEE4F1"),
                    },
                    new Circle
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        RelativeSizeAxes = Axes.Both,
                        Size = new Vector2(0.8f),
                        Colour = Color4Extensions.FromHex("8DBDE2"),
                    },
                    new Sprite
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Texture = textureStore.Get("logo-text"),
                        Size = new Vector2(194,42)
                    }
                }
            };

            foreach (float angle in MaisimRing.LANE_ANGLES)
            {
                AddInternal(new Circle
                {
                    Position = new Vector2(
                        -(buttonMultilplier * (float)Math.Cos((angle + 90f) * (float)(Math.PI / 180))),
                        -(buttonMultilplier * (float)Math.Sin((angle + 90f) * (float)(Math.PI / 180)))
                    ),
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Colour = Color4Extensions.FromHex("D9D9D9"),
                    Size = new Vector2(10)
                });
            }
        }
    }
}
