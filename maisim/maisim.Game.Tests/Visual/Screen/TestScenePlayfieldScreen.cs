using System;
using maisim.Game.Component.Gameplay.Notes;
using maisim.Game.Screen.Gameplay;
using maisim.Game.Utils;
using NUnit.Framework;
using osu.Framework.Graphics;
using osuTK;

namespace maisim.Game.Tests.Visual.Screen
{
    public class TestScenePlayfieldScreen : maisimTestScene
    {
        private PlayfieldScreen playfieldScreen;

        private Random random = new Random();

        [SetUp]
        public void SetUp()
        {
            Add(playfieldScreen = new PlayfieldScreen {RelativeSizeAxes = Axes.Both});

            AddStep("random spawn note", () => playfieldScreen.Playfield.SpawnNote(new DrawableTouchNote
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Position = new Vector2(random.NextFloatInRange(-300.0f, 300.0f),
                    random.NextFloatInRange(-300.0f, 300.0f)),
                Scale = new Vector2(1.5f)
            }));
            AddStep("spawn tap note on lane 1", () => playfieldScreen.Playfield.SpawnTapNote(NoteLane.Lane1));
            AddStep("spawn tap note on lane 2", () => playfieldScreen.Playfield.SpawnTapNote(NoteLane.Lane2));
            AddStep("spawn tap note on lane 3", () => playfieldScreen.Playfield.SpawnTapNote(NoteLane.Lane3));
            AddStep("spawn tap note on lane 4", () => playfieldScreen.Playfield.SpawnTapNote(NoteLane.Lane4));
            AddStep("spawn tap note on lane 5", () => playfieldScreen.Playfield.SpawnTapNote(NoteLane.Lane5));
            AddStep("spawn tap note on lane 6", () => playfieldScreen.Playfield.SpawnTapNote(NoteLane.Lane6));
            AddStep("spawn tap note on lane 7", () => playfieldScreen.Playfield.SpawnTapNote(NoteLane.Lane7));
            AddStep("spawn tap note on lane 8", () => playfieldScreen.Playfield.SpawnTapNote(NoteLane.Lane8));

            AddRepeatStep("spawn tap note on random lane",
                () => playfieldScreen.Playfield.SpawnTapNote((NoteLane)random.NextInRange(0, (int)NoteLane.Lane8 + 1)),
                32);
        }
    }
}
