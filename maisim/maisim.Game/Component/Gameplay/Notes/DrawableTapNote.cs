using System;
using maisim.Game.Screen.Gameplay;
using maisim.Game.Utils;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osuTK;

namespace maisim.Game.Component.Gameplay.Notes
{
    /// <summary>
    /// Class represent the normal TAP note.
    /// </summary>
    public class DrawableTapNote : DrawableNote
    {

        [BackgroundDependencyLoader]
        private void load()
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            Scale = new Vector2(1.2f);
            Margin = new MarginPadding(10);
            Position = new Vector2(
                -(Playfield.SPAWNER_MULTIPLIER *
                  (float)Math.Cos((NoteLaneExtension.GetAngle(Lane) + 90f) * (float)(Math.PI / 180))),
                -(Playfield.SPAWNER_MULTIPLIER *
                  (float)Math.Sin((NoteLaneExtension.GetAngle(Lane) + 90f) * (float)(Math.PI / 180)))
            );
        }

        protected override Drawable[] AddNoteParts(TextureStore textureStore)
        {
            return new Drawable[]
            {
                new Sprite
                {
                    RelativeSizeAxes = Axes.Both,
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    FillMode = FillMode.Fill,
                    Texture = textureStore.Get("Notes/TapNormal.png")
                }
            };
        }

        public override bool CanDespawn => MathUtils.EuclideanDistance(NoteLaneExtension.GetSpawnerPosition(Lane), NoteLaneExtension.GetSensorPosition(Lane)) + Playfield.DISTANCE_ON_DESPAWN < MathUtils.EuclideanDistance(Position, NoteLaneExtension.GetSpawnerPosition(Lane));
    }

}
