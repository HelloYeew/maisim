﻿using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osuTK;

namespace maisim.Game.Component.Gameplay.Notes
{
    public abstract class Notes : CompositeDrawable
    {
        private string TextureName;

        protected Notes(string textureName)
        {
            TextureName = textureName;
        }

        [BackgroundDependencyLoader]
        private void load(TextureStore textureStore)
        {
            InternalChild = new Container
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Size = new Vector2(50),
                Child = new Sprite
                {
                    RelativeSizeAxes = Axes.Both,
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    FillMode = FillMode.Fill,
                    Texture = textureStore.Get(TextureName)
                }
            };
        }
    }
}