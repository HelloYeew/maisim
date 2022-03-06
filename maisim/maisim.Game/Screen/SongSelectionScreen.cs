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
