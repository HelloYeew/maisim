using System.Collections.Generic;
using maisim.Game.Beatmaps;
using maisim.Game.Utils;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Input.Events;
using osu.Framework.Logging;
using osuTK;

namespace maisim.Game.Graphics.UserInterfaceV2
{
    public class BeatmapScrollSelection : Container
    {
        private Bindable<BeatmapSet> bindableBeatmapSet;
        private List<Drawable> beatmapSetDrawables;
        private Container dummyBox;

        public BeatmapScrollSelection(Bindable<BeatmapSet> bindableBeatmapSet)
        {
            this.bindableBeatmapSet = bindableBeatmapSet;
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            beatmapSetDrawables = new List<Drawable>();

            // Add BeatmapSetCard to the container
            foreach (TestUtil.AvailableTrackMetadata availableTrackMetadata in TestUtil.AVAILABLE_BEATMAP_SET_TRACK)
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

            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            RelativeSizeAxes = Axes.Both;
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
                            new Box()
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
                            new Box()
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
            };
        }

        protected override void Update()
        {
            // If beatmapSetCard's position is in the middle of the screen, set the bindableBeatmapSet to the beatmapSetCard's beatmapSet
            foreach (Drawable drawable in beatmapSetDrawables)
            {
                // Check that what beatmapSetCard is inside the dummyBox by using ScreenSpaceDrawQuad
                if (drawable.ScreenSpaceDrawQuad.TopLeft.Y >= dummyBox.ScreenSpaceDrawQuad.TopLeft.Y && drawable.ScreenSpaceDrawQuad.BottomRight.Y <= dummyBox.ScreenSpaceDrawQuad.BottomRight.Y)
                {
                    bindableBeatmapSet.Value = ((BeatmapSetCard) drawable).BeatmapSet;
                }
            }
        }
    }
}
