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
        mockTrackMetadata = new TrackMetadata
        {
            Title = "Sukino Skill",
            Artist = "Wake Up, Girls!",
            Bpm = 120,
            CoverPath = "Test/sukino-skill.jpg"
        };
        mockBeatmap = new Beatmap
        {
            TrackMetadata = mockTrackMetadata,
            DifficultyLevel = DifficultyLevel.Expert,
            DifficultyRating = 8.2323f,
            IsRemaster = false,
            MaxSeasonalScore = 6969,
            NoteDesigner = "GIGACHAD"
        };
        mockScore = new Score
        {
            Beatmap = mockBeatmap,
            Tap = 10,
            Hold = 10,
            Slide = 10,
            Touch = 10,
            Accuracy = 99.65f,
            Rank = ScoreProcessor.CalculateRank(99.65f),
            Combo = 210,
            SeasonalScore = 5566
        };

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

        mockTrackMetadata = new TrackMetadata
        {
            Title = "Lemon",
            Artist = "Kenshi Yonezu",
            Bpm = 80,
            CoverPath = "Test/lemon.jpg"
        };
        mockBeatmap = new Beatmap
        {
            TrackMetadata = mockTrackMetadata,
            DifficultyLevel = DifficultyLevel.Advanced,
            DifficultyRating = 5.21f,
            IsRemaster = true,
            MaxSeasonalScore = 865,
            NoteDesigner = "Pogpega"
        };
        mockScore = new Score
        {
            Beatmap = mockBeatmap,
            Tap = 10,
            Hold = 10,
            Slide = 10,
            Touch = 10,
            Accuracy = 94.00f,
            Rank = ScoreProcessor.CalculateRank(94.00f),
            Combo = 650,
            SeasonalScore = 350
        };

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

        mockTrackMetadata = new TrackMetadata
        {
            Title = "only my railgun",
            Artist = "fripSide",
            Bpm = 190,
            CoverPath = "Test/only-my-railgun.jpg"
        };
        mockBeatmap = new Beatmap
        {
            TrackMetadata = mockTrackMetadata,
            DifficultyLevel = DifficultyLevel.Expert,
            DifficultyRating = 6.3475f,
            IsRemaster = false,
            MaxSeasonalScore = 3456,
            NoteDesigner = "EduardoLinguino"
        };
        mockScore = new Score
        {
            Beatmap = mockBeatmap,
            Tap = 10,
            Hold = 10,
            Slide = 10,
            Touch = 10,
            Accuracy = 81.00f,
            Rank = ScoreProcessor.CalculateRank(81.00f),
            Combo = 453,
            SeasonalScore = 2556
        };

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

        mockTrackMetadata = new TrackMetadata
        {
            Title = "RAISE MY SWORD",
            Artist = "GALNERYUS",
            Bpm = 220,
            CoverPath = "Test/raise-my-sword.jpg"
        };
        mockBeatmap = new Beatmap
        {
            TrackMetadata = mockTrackMetadata,
            DifficultyLevel = DifficultyLevel.Master,
            DifficultyRating = 11.3475f,
            IsRemaster = false,
            MaxSeasonalScore = 8888,
            NoteDesigner = "Tutel"
        };
        mockScore = new Score
        {
            Beatmap = mockBeatmap,
            Tap = 10,
            Hold = 10,
            Slide = 10,
            Touch = 10,
            Accuracy = 73.25f,
            Rank = ScoreProcessor.CalculateRank(73.25f),
            Combo = 1453,
            SeasonalScore = 4646
        };

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

        mockTrackMetadata = new TrackMetadata
        {
            Title = "Tenkai e no Kippu",
            Artist = "Dragon Guardian",
            Bpm = 190,
            CoverPath = "Test/tenkai-e-no-kippu.jpg"
        };
        mockBeatmap = new Beatmap
        {
            TrackMetadata = mockTrackMetadata,
            DifficultyLevel = DifficultyLevel.Remaster,
            DifficultyRating = 14.55f,
            IsRemaster = true,
            MaxSeasonalScore = 9999,
            NoteDesigner = "SUSSY"
        };
        mockScore = new Score
        {
            Beatmap = mockBeatmap,
            Tap = 10,
            Hold = 10,
            Slide = 10,
            Touch = 10,
            Accuracy = 30.25f,
            Rank = ScoreProcessor.CalculateRank(30.25f),
            Combo = 45,
            SeasonalScore = 22
        };

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
