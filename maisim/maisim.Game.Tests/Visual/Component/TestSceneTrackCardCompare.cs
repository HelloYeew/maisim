using maisim.Game.Beatmaps;
using maisim.Game.Component;
using maisim.Game.Scores;
using osu.Framework.Testing;
using osu.Framework.Graphics;
using osuTK;

namespace maisim.Game.Tests.Visual.Component
{
    public class TestSceneTrackCardCompare : GridTestScene
    {
        private readonly TrackMetadata mockTrackMetadata;

        private readonly Beatmap mockBeatmap;

        private readonly Score mockScore;

        public TestSceneTrackCardCompare() : base(1,2)
        {
            mockTrackMetadata = new TrackMetadata("Sukino Skill", "Wake Up, Girls!", "Test/sukino-skill.jpg", 120);
            mockBeatmap = new Beatmap(mockTrackMetadata, DifficultyLevel.Expert, 8.2323f, false, 6969, "GIGACHAD");
            mockScore = new Score(mockBeatmap, 10, 10, 10, 10, 99.65f, 210, 5566);

            Cell(0, 0).Child = new TrackCard(mockBeatmap, mockScore)
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Scale = new Vector2(1)
            };
            Cell(0, 1).Child = new TrackCardFocused(mockBeatmap, mockScore)
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Scale = new Vector2(1)
            };
        }
    }
}
