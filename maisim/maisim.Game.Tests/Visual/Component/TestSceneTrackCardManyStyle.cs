using maisim.Game.Beatmaps;
using maisim.Game.Component;
using maisim.Game.Scores;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Testing;
using osuTK;

namespace maisim.Game.Tests.Visual.Component;

public class TestSceneTrackCardManyStyle : GridTestScene
{
    private readonly TrackMetadata mockTrackMetadata;
    private readonly Beatmap mockBeatmap;
    private readonly Score mockScore;

    public TestSceneTrackCardManyStyle() : base(2, 3)
    {
        mockTrackMetadata = new TrackMetadata("Sukino Skill", "Wake Up, Girls!", "Test/sukino-skill.jpg", 120);
        mockBeatmap = new Beatmap(mockTrackMetadata, DifficultyLevel.Basic, 8.2323f, false, 6969, "GIGACHAD");
        mockScore = new Score(mockBeatmap, 10, 10, 10, 10, 99.65f, 210, 5566);

        Cell(0, 0).Children = new Drawable[]
        {
            new SpriteText
            {
                Anchor = Anchor.TopLeft,
                Origin = Anchor.TopLeft,
                Text = nameof(DifficultyLevel.Basic)
            },
            new TrackCard(mockBeatmap,mockScore)
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Scale = new Vector2(0.7f)
            }
        };

        mockTrackMetadata = new TrackMetadata("Lemon", "Kenshi Yonezu", "Test/lemon.jpg", 80);
        mockBeatmap = new Beatmap(mockTrackMetadata, DifficultyLevel.Advanced, 5.21f, true, 865, "Pogpega");
        mockScore = new Score(mockBeatmap, 10, 10, 10, 10, 94.00f, 650, 350);

        Cell(0, 1).Children = new Drawable[]
        {
            new SpriteText
            {
                Anchor = Anchor.TopLeft,
                Origin = Anchor.TopLeft,
                Text = nameof(DifficultyLevel.Advanced)
            },
            new TrackCard(mockBeatmap, mockScore)
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Scale = new Vector2(0.7f)
            }
        };

        mockTrackMetadata = new TrackMetadata("only my railgun", "fripSide", "Test/only-my-railgun.jpg", 190);
        mockBeatmap = new Beatmap(mockTrackMetadata, DifficultyLevel.Expert, 6.3475f, false, 3456, "EduardoLingure");
        mockScore = new Score(mockBeatmap, 10, 10, 10, 10, 81.00f, 453, 2556);

        Cell(0, 2).Children = new Drawable[]
        {
            new SpriteText
            {
                Anchor = Anchor.TopLeft,
                Origin = Anchor.TopLeft,
                Text = nameof(DifficultyLevel.Expert)
            },
            new TrackCard(mockBeatmap, mockScore)
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Scale = new Vector2(0.7f)
            }
        };

        mockTrackMetadata = new TrackMetadata("RAISE MY SWORD", "GALNERYUS", "Test/raise-my-sword.jpg", 220);
        mockBeatmap = new Beatmap(mockTrackMetadata, DifficultyLevel.Master, 11.3475f, false, 8888, "Tutel");
        mockScore = new Score(mockBeatmap, 10, 10, 10, 10, 73.25f, 1453, 4646);

        Cell(1, 0).Children = new Drawable[]
        {
            new SpriteText
            {
                Anchor = Anchor.TopLeft,
                Origin = Anchor.TopLeft,
                Text = nameof(DifficultyLevel.Master)
            },
            new TrackCard(mockBeatmap, mockScore)
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Scale = new Vector2(0.7f)
            }
        };

        mockTrackMetadata = new TrackMetadata("Tenkai e no Kippu", "Dragon Guardian", "Test/tenkai-e-no-kippu.jpg", 190);
        mockBeatmap = new Beatmap(mockTrackMetadata, DifficultyLevel.Remaster, 14.55f, true, 9999, "Mamizu");
        mockScore = new Score(mockBeatmap, 10, 10, 10, 10, 30.25f, 45, 22);

        Cell(1, 1).Children = new Drawable[]
        {
            new SpriteText
            {
                Anchor = Anchor.TopLeft,
                Origin = Anchor.TopLeft,
                Text = nameof(DifficultyLevel.Remaster)
            },
            new TrackCard(mockBeatmap, mockScore)
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Scale = new Vector2(0.7f)
            }
        };
    }
}
