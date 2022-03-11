﻿using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osuTK;

namespace maisim.Game.Component.Gameplay.Notes
{
    public class Touch : Notes
    {
        [BackgroundDependencyLoader]
        private void load(TextureStore textureStore)
        {
            InternalChild = new Container
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Size = new Vector2(50),
                Children = new Drawable[]
                {
                    new Sprite
                    {
                        RelativeSizeAxes = Axes.Both,
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        FillMode = FillMode.Fill,
                        Texture = textureStore.Get("Notes/TouchDot.png")
                    },
                    new Sprite
                    {
                        Name = "UpArrow",
                        Position = new Vector2(0, -20),
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Rotation = 0,
                        Size = new Vector2(30, 15),
                        Texture = textureStore.Get("Notes/TouchArrow.png")
                    },
                    new Sprite
                    {
                        Name = "RightArrow",
                        Position = new Vector2(20, 0),
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Rotation = 90,
                        Size = new Vector2(30, 15),
                        Texture = textureStore.Get("Notes/TouchArrow.png")
                    },
                    new Sprite
                    {
                        Name = "DownArrow",
                        Position = new Vector2(0, 20),
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Rotation = 180,
                        Size = new Vector2(30, 15),
                        Texture = textureStore.Get("Notes/TouchArrow.png")
                    },
                    new Sprite
                    {
                        Name = "LeftArrow",
                        Position = new Vector2(-20, 0),
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Rotation = 270,
                        Size = new Vector2(30, 15),
                        Texture = textureStore.Get("Notes/TouchArrow.png")
                    }
                }
            };
        }
    }
}
