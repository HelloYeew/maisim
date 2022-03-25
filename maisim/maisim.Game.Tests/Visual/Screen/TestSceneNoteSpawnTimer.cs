using System;
using System.Collections.Generic;
using maisim.Game.Component.Gameplay.Notes;
using maisim.Game.Screen.Gameplay;
using maisim.Game.Utils;
using NUnit.Framework;
using osu.Framework.Graphics;
using osuTK;

namespace maisim.Game.Tests.Visual.Screen;

public class TestSceneNoteSpawnTimer : maisimTestScene
{
    private PlayfieldScreen playfieldScreen;

    private Random random = new Random();

    [SetUp]
    public void SetUp()
    {
        Add(playfieldScreen = new PlayfieldScreen {RelativeSizeAxes = Axes.Both});

        playfieldScreen.Playfield.NotesPool = new List<DrawableNote>
        {
            new DrawableTapNote()
            {
                Lane = NoteLane.Lane1,
                TargetTime = 5000f
            },
            new DrawableTapNote()
            {
                Lane = NoteLane.Lane2,
                TargetTime = 7000f
            },
            new DrawableTapNote()
            {
                Lane = NoteLane.Lane3,
                TargetTime = 9000f
            },
            new DrawableTapNote()
            {
                Lane = NoteLane.Lane4,
                TargetTime = 11000f
            },
            new DrawableTapNote()
            {
                Lane = NoteLane.Lane5,
                TargetTime = 13000f
            },
            new DrawableTapNote()
            {
                Lane = NoteLane.Lane6,
                TargetTime = 15000f
            },
        };
    }
}
