using maisim.Game.Beatmaps;
using maisim.Game.Component;
using maisim.Game.Scores;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osuTK;
using osuTK.Graphics;

namespace maisim.Game.Tests.Visual.Component
{
    public class TestSceneTrackCard : maisimTestScene
    {
        private readonly TrackMetadata mockTrackMetadata;

        private readonly Beatmap mockBeatmap;

        private readonly Score mockScore;

        public TestSceneTrackCard()
        {
            mockTrackMetadata = new TrackMetadata("Sukino Skill", "Wake Up, Girls!", "Test/sukino-skill.jpg", 120);
            mockBeatmap = new Beatmap(mockTrackMetadata, DifficultyLevel.Expert, 8.2323f, false, 6969, "GIGACHAD");
            mockScore = new Score(10, 10, 10, 10, 99.65f, 210, 5566);

            Child = new Container
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Size = new Vector2(500,500),
                Masking = true,
                Children = new Drawable[]
                {
                    new Box
                    {
                        RelativeSizeAxes = Axes.Both,
                        Colour = Color4.Black
                    },
                    new TrackCard(mockBeatmap, mockScore)
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                    }
                }
            };
        }
    }
}
