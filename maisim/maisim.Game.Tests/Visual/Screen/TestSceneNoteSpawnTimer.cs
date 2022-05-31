using System.Collections.Generic;
using System.Linq;
using maisim.Game.Component.Gameplay.Notes;
using maisim.Game.Screen.Gameplay;
using NUnit.Framework;
using osu.Framework.Allocation;
using osu.Framework.Graphics;

namespace maisim.Game.Tests.Visual.Screen;

public class TestSceneNoteSpawnTimer : maisimTestScene
{
    private PlayfieldScreen playfieldScreen;


    [BackgroundDependencyLoader]
    private void load()
    {
        Add(playfieldScreen = new PlayfieldScreen { RelativeSizeAxes = Axes.Both });
        AddStep("spawn notes", spawnNotes);
    }

    private void spawnNotes()
    {
        playfieldScreen.Playfield.Children = Enumerable.Range(0, (int)NoteLane.Lane8).Select<int, Drawable>(i =>
            new DrawableTapNote
            {
                Lane = (NoteLane)i,
                TargetTime = Clock.CurrentTime + i * 1000
            }
        ).ToList().AsReadOnly();
    }
}
