﻿using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osuTK;

namespace maisim.Game.Component.Gameplay.Notes
{
    /// <summary>
    /// Class represent the TOUCH HOLD note.
    /// </summary>
    public class TouchHold : DrawableNote
    {
        public override Drawable[] AddNoteParts(TextureStore textureStore)
        {
            return new Drawable[]
            {
                new Sprite
                {
                    RelativeSizeAxes = Axes.Both,
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    FillMode = FillMode.Fill,
                    Texture = textureStore.Get("Notes/TouchHold.png")
                }
            };
        }
    }
}
