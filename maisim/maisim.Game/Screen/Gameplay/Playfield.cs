using System;
using maisim.Game.Component.Gameplay;
using maisim.Game.Component.Gameplay.Notes;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osuTK;

namespace maisim.Game.Screen.Gameplay
{
    public class Playfield : osu.Framework.Screens.Screen
    {
        public static readonly float SPAWNER_MULTIPLIER = 75f;

        public static readonly float NOTE_SPEED = 0.5f;

        [BackgroundDependencyLoader]
        private void load()
        {

        }

        public void SpawnNote(DrawableNote note)
        {
            AddInternal(note);
        }

        public void SpawnTapNote(NoteLane lane)
        {
            AddInternal(new DrawableTapNote
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Position = new Vector2(
                    -(SPAWNER_MULTIPLIER * (float)Math.Cos((NoteLaneExtension.GetAngle(lane) + 90f) * (float)(Math.PI / 180))),
                    -(SPAWNER_MULTIPLIER * (float)Math.Sin((NoteLaneExtension.GetAngle(lane) + 90f) * (float)(Math.PI / 180)))
                    ),
                Scale = new Vector2(1.2f),
                Lane = lane
            });
        }

        protected override void Update()
        {
            foreach (Drawable note in InternalChildren)
            {
                if (note is DrawableTapNote tapNote)
                {
                    note.Position += new Vector2(
                        -(NOTE_SPEED * (float)Math.Cos((NoteLaneExtension.GetAngle(tapNote.Lane) + 90f) *
                                                               (float)(Math.PI / 180))),
                        -(NOTE_SPEED * (float)Math.Sin((NoteLaneExtension.GetAngle(tapNote.Lane) + 90f) *
                                                               (float)(Math.PI / 180)))
                    );
                }
            }

            base.Update();
        }
    }
}
