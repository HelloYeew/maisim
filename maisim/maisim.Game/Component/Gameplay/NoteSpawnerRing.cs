﻿using System;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osuTK;

namespace maisim.Game.Component.Gameplay
{
    public class NoteSpawnerRing : CircularContainer
    {
        private static readonly float SPAWNER_MULTIPLIER = 75f;

        private readonly NoteSpawner[] spawners;

        public bool ShowSpawners { get; set; } = false;

        [BackgroundDependencyLoader]
        private void load()
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            Size = MaisimRing.PLAYFIELD_SIZE;

            foreach (var angle in MaisimRing.LANE_ANGLES)
            {
                AddInternal(new NoteSpawner
                {
                    Position = new Vector2(
                        -(SPAWNER_MULTIPLIER * (float)Math.Cos((angle + 90f) * (float)(Math.PI / 180))),
                        -(SPAWNER_MULTIPLIER * (float)Math.Sin((angle + 90f) * (float)(Math.PI / 180)))
                    ),
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Size = new Vector2(2),
                    ShowOutline = ShowSpawners
                });
            }
        }
    }
}
