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
        public NoteLane Lane { get; set; }

        [BackgroundDependencyLoader]
        private void load()
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            Scale = new Vector2(1.2f);
            Margin = new MarginPadding(10);
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

        public override void UpdatePosition(Playfield playfield)
        {
            if (TargetTime != 0f)
            {
                // Update the position
                double speed = MathUtils.EuclideanDistance(
                    NoteLaneExtension.GetSpawnerPosition(Lane),
                    NoteLaneExtension.GetSensorPosition(Lane)) / Playfield.TIME_NOTE_APPEARS;
                Position = new Vector2(
                    (float) (Position.X + ((float)(speed * (-(float)Math.Cos((NoteLaneExtension.GetAngle(Lane) + 90f) * (float)(Math.PI / 180)))) * playfield.Clock.ElapsedFrameTime)),
                    (float) (Position.Y + ((float)(speed * (-(float)Math.Sin((NoteLaneExtension.GetAngle(Lane) + 90f) * (float)(Math.PI / 180)))) * playfield.Clock.ElapsedFrameTime))
                    );
            }
            else
            {
                // This is for the note that spawn using SpawnTapNote method and no TargetTime specified in the test scene.
                // Will remove it when the note spawn system is complete.
                Position += new Vector2(
                    -(Playfield.NOTE_SPEED * (float)Math.Cos((NoteLaneExtension.GetAngle(Lane) + 90f) *
                                                   (float)(Math.PI / 180))),
                    -(Playfield.NOTE_SPEED * (float)Math.Sin((NoteLaneExtension.GetAngle(Lane) + 90f) *
                                                   (float)(Math.PI / 180)))
                );
            }
        }

        public override bool CanDespawn()
        {
            if (MathUtils.EuclideanDistance(NoteLaneExtension.GetSpawnerPosition(Lane), NoteLaneExtension.GetSensorPosition(Lane)) + Playfield.DISTANCE_ON_DESPAWN <
                MathUtils.EuclideanDistance(Position, NoteLaneExtension.GetSpawnerPosition(Lane)))
            {
                // Enter despawning state
                this.FadeOut(50, Easing.InBounce);
                return true;
            }
            return false;
        }
    }
}
