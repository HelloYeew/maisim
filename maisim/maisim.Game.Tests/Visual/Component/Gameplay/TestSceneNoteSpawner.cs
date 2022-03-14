using maisim.Game.Component.Gameplay;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osuTK;

namespace maisim.Game.Tests.Visual.Component.Gameplay;

public class TestSceneNoteSpawner : maisimTestScene
{
    private readonly NoteSpawnerRing noteSpawnerRing;

    public TestSceneNoteSpawner()
    {
        Child = new Container
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            Size = new Vector2(1),
            Children = new Drawable[]
            {
                new MaisimRing
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Size = new Vector2(1),
                },noteSpawnerRing = new NoteSpawnerRing
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Size = new Vector2(1),
                    ShowSpawners = true
                }
            }
        };
    }
}
