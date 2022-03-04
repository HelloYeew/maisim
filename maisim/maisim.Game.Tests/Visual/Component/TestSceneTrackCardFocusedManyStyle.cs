using maisim.Game.Beatmaps;
using maisim.Game.Component;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Testing;
using osuTK;

namespace maisim.Game.Tests.Visual.Component;

public class TestSceneTrackCardFocusedManyStyle : GridTestScene
{
    public TestSceneTrackCardFocusedManyStyle() : base(2, 3)
    {
        Cell(0, 0).Children = new Drawable[]
        {
            new SpriteText
            {
                Anchor = Anchor.TopLeft,
                Origin = Anchor.TopLeft,
                Text = nameof(DifficultyLevel.Basic)
            },
            new TrackCardFocused("Test/sukino-skill.jpg", "Sukino Skill", "Wake Up, Girls!",
                100.6969f, "SSS", 1278, 2424, true, true, "HelloYeew", 120, DifficultyLevel.Basic)
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Scale = new Vector2(0.7f)
            }
        };
        Cell(0, 1).Children = new Drawable[]
        {
            new SpriteText
            {
                Anchor = Anchor.TopLeft,
                Origin = Anchor.TopLeft,
                Text = nameof(DifficultyLevel.Advanced)
            },
            new TrackCardFocused("Test/lemon.jpg", "Lemon", "Kenshi Yonezu",
                100.2900f, "SS", 58, 4542, false, true, "PepePoggers", 80, DifficultyLevel.Advanced)
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Scale = new Vector2(0.7f)
            }
        };
        Cell(0, 2).Children = new Drawable[]
        {
            new SpriteText
            {
                Anchor = Anchor.TopLeft,
                Origin = Anchor.TopLeft,
                Text = nameof(DifficultyLevel.Expert)
            },
            new TrackCardFocused("Test/only-my-railgun.jpg", "only my railgun", "fripSide",
                100.00f, "SS", 797, 4215, true, false, "Kasumi", 190, DifficultyLevel.Expert)
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Scale = new Vector2(0.7f)
            }
        };
        Cell(1, 0).Children = new Drawable[]
        {
            new SpriteText
            {
                Anchor = Anchor.TopLeft,
                Origin = Anchor.TopLeft,
                Text = nameof(DifficultyLevel.Master)
            },
            new TrackCardFocused("Test/raise-my-sword.jpg", "RAISE MY SWORD", "GALNERYUS",
                0, "", 0, 4279, false, false, "AmPen", 220, DifficultyLevel.Master)
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Scale = new Vector2(0.7f)
            }
        };
        Cell(1, 1).Children = new Drawable[]
        {
            new SpriteText
            {
                Anchor = Anchor.TopLeft,
                Origin = Anchor.TopLeft,
                Text = nameof(DifficultyLevel.Remaster)
            },
            new TrackCardFocused("Test/tenkai-e-no-kippu.jpg", "Tenkai e no Kippu", "Dragon Guardian",
                0, "", 0, 4279, false, false, "Kroytz", 190, DifficultyLevel.Remaster)
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Scale = new Vector2(0.7f)
            }
        };
    }
}
