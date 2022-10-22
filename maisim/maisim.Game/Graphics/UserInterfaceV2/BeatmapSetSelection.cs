using System.Collections.Generic;
using maisim.Game.Beatmaps;
using maisim.Game.Graphics.UserInterface.Overlays;
using maisim.Game.Utils;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osuTK;

namespace maisim.Game.Graphics.UserInterfaceV2
{
    public class BeatmapSetSelection : CompositeDrawable
    {
        [Resolved]
        private CurrentWorkingBeatmap currentWorkingBeatmap { get; set; }

        [Resolved]
        private MusicPlayer musicPlayer { get; set; }

        private List<Drawable> beatmapSetDrawables;
        private Box topBox;
        private Box bottomBox;
        private Container dummyBox;
        private Box backgroundBox;

        private void workingBeatmapChange(ValueChangedEvent<BeatmapSet> beatmapSetEvent) =>
            musicPlayer.SeekTo(beatmapSetEvent.NewValue.PreviewTime);

        [BackgroundDependencyLoader]
        private void load()
        {
            beatmapSetDrawables = new List<Drawable>();

            // Add BeatmapSetCard to the container
            foreach (TestUtil.AvailableTrackMetadata availableTrackMetadata in TestUtil.AvailableBeatmapSetTrack)
            {
                if (availableTrackMetadata != TestUtil.AvailableTrackMetadata.None)
                {
                    BeatmapSet beatmapSet = new BeatmapSetTestFixture(availableTrackMetadata).BeatmapSet;
                    beatmapSetDrawables.Add(new BeatmapSetCard(beatmapSet)
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Scale = new Vector2(0.6f, 0.6f),
                        // Add a margin between each BeatmapSetCard
                        Margin = new MarginPadding()
                        {
                            Top = 10
                        }
                    });
                }
            }

            // This container need to be wide equal to the screen width to prevent the scroll bar from being cut off.
            Anchor = Anchor.TopLeft;
            Origin = Anchor.TopLeft;
            RelativeSizeAxes = Axes.Y;
            Position = new Vector2(120, 0);
            Size = new Vector2(400, 1);
            InternalChildren = new Drawable[]
            {
                backgroundBox = new Box
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    RelativeSizeAxes = Axes.Both,
                    Colour = MaisimColour.SongSelectionContainerColor,
                    Alpha = 0.5f
                },
                new Container
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    RelativeSizeAxes = Axes.Both,
                    Children = new Drawable[]
                    {
                        dummyBox = new Container()
                        {
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            RelativeSizeAxes = Axes.X,
                            Size = new Vector2(1, 90),
                            CornerRadius = 10,
                            Masking = true,
                            BorderColour = MaisimColour.SongSelectionContainerBorderColor,
                            BorderThickness = 3,
                            Child = new Box()
                            {
                                RelativeSizeAxes = Axes.Both,
                                Colour = MaisimColour.SongSelectionContainerBorderColor,
                                Alpha = 0.5f,
                            }
                        },
                        new BasicScrollContainer()
                        {
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            RelativeSizeAxes = Axes.Both,
                            ScrollbarVisible = true,
                            Child = new FillFlowContainer<Drawable>()
                            {
                                Anchor = Anchor.Centre,
                                Origin = Anchor.Centre,
                                RelativeSizeAxes = Axes.X,
                                AutoSizeAxes = Axes.Y,
                                Direction = FillDirection.Vertical,
                                Children = new Drawable[]
                                {
                                    topBox = new Box()
                                    {
                                        Anchor = Anchor.Centre,
                                        Origin = Anchor.Centre,
                                        RelativeSizeAxes = Axes.X,
                                        Size = new Vector2(1, 310),
                                        Alpha = 0,
                                        AlwaysPresent = true
                                    },
                                    new FillFlowContainer<Drawable>()
                                    {
                                        Anchor = Anchor.Centre,
                                        Origin = Anchor.Centre,
                                        RelativeSizeAxes = Axes.X,
                                        AutoSizeAxes = Axes.Y,
                                        Direction = FillDirection.Vertical,
                                        Children = beatmapSetDrawables.ToArray()
                                    },
                                    bottomBox = new Box()
                                    {
                                        Anchor = Anchor.Centre,
                                        Origin = Anchor.Centre,
                                        RelativeSizeAxes = Axes.X,
                                        Size = new Vector2(1, 320),
                                        Alpha = 0,
                                        AlwaysPresent = true
                                    }
                                }
                            }
                        }
                    }
                }
            };

            currentWorkingBeatmap.BindBeatmapSetChanged(workingBeatmapChange);
        }

        protected override void LoadComplete()
        {
            topBox.Size = new Vector2(1,backgroundBox.ScreenSpaceDrawQuad.Size.Y / 2 - dummyBox.ScreenSpaceDrawQuad.Size.Y / 2 - 20);
            bottomBox.Size = new Vector2(1,backgroundBox.ScreenSpaceDrawQuad.Size.Y / 2 - dummyBox.ScreenSpaceDrawQuad.Size.Y / 2 - 10);

            base.LoadComplete();
        }

        protected override void Update()
        {
            // If beatmapSetCard's position is in the middle of the screen, set the bindableBeatmapSet to the beatmapSetCard's beatmapSet
            foreach (Drawable drawable in beatmapSetDrawables)
            {
                // Check that what beatmapSetCard is inside the dummyBox by using ScreenSpaceDrawQuad
                if (drawable.ScreenSpaceDrawQuad.TopLeft.Y >= dummyBox.ScreenSpaceDrawQuad.TopLeft.Y && drawable.ScreenSpaceDrawQuad.BottomRight.Y <= dummyBox.ScreenSpaceDrawQuad.BottomRight.Y)
                {
                    currentWorkingBeatmap.SetCurrentBeatmapSet(((BeatmapSetCard) drawable).BeatmapSet);
                }
            }
        }
    }
}
