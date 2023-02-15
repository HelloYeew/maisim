using System;
using maisim.Game.Beatmaps;
using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using maisim.Game.Graphics.Gameplay;
using maisim.Game.Graphics.UserInterface.Overlays;
using osu.Framework.Bindables;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osuTK;

namespace maisim.Game.Graphics.UserInterface
{
    /// <summary>
    /// The game's logo
    /// </summary>
    public partial class MaisimLogo : CompositeDrawable
    {
        private const float button_multiplier = 119f;

        private Container amplitudeContainer;
        private Container logoBeatContainer;
        public LogoVisualization Visualizer;

        [Resolved]
        private CurrentWorkingBeatmap currentWorkingBeatmap { get; set; }

        [Resolved]
        private MusicPlayer musicPlayer { get; set; }

        private void workingBeatmapChanged(ValueChangedEvent<BeatmapSet> beatmapSetEvent)
        {
            Visualizer.ClearAmplitudeSources();
            Scheduler.Add(() => Visualizer.AddAmplitudeSource(musicPlayer.Track.Value));
        }

        [BackgroundDependencyLoader]
        private void load(TextureStore textureStore)
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            Size = new Vector2(300);
            InternalChildren = new Drawable[]
            {
                amplitudeContainer = new Container
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    RelativeSizeAxes = Axes.Both,
                    Children = new Drawable[]
                    {
                        logoBeatContainer = new Container()
                        {
                            RelativeSizeAxes = Axes.Both,
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            Children = new Drawable[]
                            {
                                Visualizer = new LogoVisualization()
                                {
                                    Anchor = Anchor.Centre,
                                    Origin = Anchor.Centre,
                                    RelativeSizeAxes = Axes.Both,
                                    Alpha = 0.5f,
                                    Size = new Vector2(1)
                                }
                            }
                        }
                    }
                },
                new Container()
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    RelativeSizeAxes = Axes.Both,
                    Children = new Drawable[]
                    {
                        new Circle
                        {
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            RelativeSizeAxes = Axes.Both,
                            Colour = Color4Extensions.FromHex("DEE4F1"),
                        },
                        new Circle
                        {
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            RelativeSizeAxes = Axes.Both,
                            Size = new Vector2(0.8f),
                            Colour = Color4Extensions.FromHex("8DBDE2"),
                        },
                        new Sprite
                        {
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            Texture = textureStore.Get("logo-text"),
                            Size = new Vector2(194, 42)
                        }
                    }
                }
            };

            foreach (float angle in MaisimRing.LANE_ANGLES)
            {
                AddInternal(new Circle
                {
                    Position = new Vector2(
                        -(button_multiplier * (float)Math.Cos((angle + 90f) * (float)(Math.PI / 180))),
                        -(button_multiplier * (float)Math.Sin((angle + 90f) * (float)(Math.PI / 180)))
                    ),
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Colour = Color4Extensions.FromHex("D9D9D9"),
                    Size = new Vector2(10)
                });
            }
            currentWorkingBeatmap.BindBeatmapSetChanged(workingBeatmapChanged);
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();
            Visualizer.AddAmplitudeSource(musicPlayer.Track.Value);
        }
    }
}
