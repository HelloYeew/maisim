using maisim.Game.Beatmaps;
using maisim.Game.Component;
using maisim.Game.Scores;
using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Screens;
using osuTK;

namespace maisim.Game.Screen
{
    /// <summary>
    /// The song selection screen that shows a list of all the songs to the user who can select a track to play from there.
    /// </summary>
    public class SongSelectionScreen : osu.Framework.Screens.Screen
    {
        private TrackMetadata mockTrackMetadata;
        private Beatmap mockBeatmap;
        private Score mockScore;

        [BackgroundDependencyLoader]
        private void load()
        {
            mockTrackMetadata = new TrackMetadata("Sukino Skill", "Wake Up, Girls!", "Test/sukino-skill.jpg", 120);
            mockBeatmap = new Beatmap(mockTrackMetadata, DifficultyLevel.Expert, 8.2323f, false, 6969, "GIGACHAD");
            mockScore = new Score(mockBeatmap, 10, 10, 10, 10, 99.65f, 210, 5566);

            InternalChildren = new Drawable[]
            {
                new Container
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Size = new Vector2(320,320),
                    RelativePositionAxes = Axes.X,
                    Children = new Drawable[]
                    {
                        new SongSelectionBackground(Color4Extensions.FromHex("fb5f99"))
                        {
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            RelativePositionAxes = Axes.Both,
                            RelativeSizeAxes = Axes.Both,
                        },new Container
                        {
                            Anchor = Anchor.TopCentre,
                            Origin = Anchor.TopCentre,
                            RelativePositionAxes = Axes.Both,
                            RelativeSizeAxes = Axes.Both,
                            Children = new Drawable[]
                            {
                                new TrackCardFocused(mockBeatmap, mockScore)
                                {
                                    Anchor = Anchor.TopCentre,
                                    Origin = Anchor.TopCentre,
                                    RelativePositionAxes = Axes.Both,
                                    Size = new Vector2(300,384)
                                }
                            }
                        }
                    }
                },new BackButton
                {
                    Anchor = Anchor.BottomLeft,
                    Origin = Anchor.BottomLeft,
                    Size = new Vector2(400),
                    Action = () => this.Exit()
                }
            };
        }
    }
}
