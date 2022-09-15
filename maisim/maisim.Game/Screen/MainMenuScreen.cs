using maisim.Game.Beatmaps;
using maisim.Game.Graphics;
using maisim.Game.Graphics.Sprites;
using maisim.Game.Graphics.UserInterface;
using maisim.Game.Graphics.UserInterface.Overlays;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Development;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Screens;
using osuTK;

namespace maisim.Game.Screen
{
    /// <summary>
    /// The main menu screen that includes all the main menu components.
    /// </summary>
    public class MainMenuScreen : MaisimScreen
    {
        private MaisimLogo maisimLogo;
        private MainMenuButton playButton;
        private MainMenuButton editButton;
        private MainMenuButton browseButton;
        private MainMenuButton exitButton;
        private MaisimSpriteText versionText;
        private MaisimSpriteText trackTitleText;
        private MaisimSpriteText trackArtistText;

        [Resolved]
        private WorkingBeatmap workingBeatmap { get; set; }

        private void workingBeatmapChanged(ValueChangedEvent<BeatmapSet> beatmapSetEvent) => updateNewBeatmap(beatmapSetEvent.NewValue);

        [BackgroundDependencyLoader]
        private void load()
        {
            InternalChildren = new Drawable[]
            {
                new Container
                {
                    Anchor = Anchor.BottomRight,
                    Origin = Anchor.BottomRight,
                    Size = new Vector2(400, 400),
                    Position = new Vector2(-70, 0),
                    Children = new Drawable[]
                    {
                        new FillFlowContainer
                        {
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            RelativeSizeAxes = Axes.Y,
                            RelativePositionAxes = Axes.Y,
                            Spacing = new Vector2(0, 10),
                            Children = new Drawable[]
                            {
                                playButton = new MainMenuButton("Play",FontAwesome.Solid.Play,Color4Extensions.FromHex("73E99B"))
                                {
                                    Anchor = Anchor.Centre,
                                    Origin = Anchor.Centre,
                                    Size = new Vector2(400, 60),
                                    Scale = new Vector2(0),
                                    Action = () => this.Push(new SongSelectionScreen())
                                },
                                editButton = new MainMenuButton("Edit",FontAwesome.Solid.Edit,Color4Extensions.FromHex("E9C173"))
                                {
                                    Anchor = Anchor.Centre,
                                    Origin = Anchor.Centre,
                                    Size = new Vector2(400, 60),
                                    Scale = new Vector2(0)
                                },
                                browseButton = new MainMenuButton("Browse",FontAwesome.Solid.ListUl,Color4Extensions.FromHex("E773E9"))
                                {
                                    Anchor = Anchor.Centre,
                                    Origin = Anchor.Centre,
                                    Size = new Vector2(400, 60),
                                    Scale = new Vector2(0)
                                },
                                exitButton = new MainMenuButton("Exit",FontAwesome.Solid.DoorOpen,Color4Extensions.FromHex("E97373"))
                                {
                                    Anchor = Anchor.Centre,
                                    Origin = Anchor.Centre,
                                    Size = new Vector2(400, 60),
                                    Scale = new Vector2(0)
                                }
                            }
                        }
                    }
                },
                new Container
                {
                    Anchor = Anchor.TopLeft,
                    Origin = Anchor.TopLeft,
                    Size = new Vector2(300),
                    Position = new Vector2(30, 30),
                    Child = maisimLogo = new MaisimLogo
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Size = new Vector2(300),
                        Scale = new Vector2(0)
                    }
                },
                versionText = new MaisimSpriteText
                {
                    Anchor = Anchor.BottomLeft,
                    Origin = Anchor.BottomLeft,
                    Text = DebugUtils.IsDebugBuild ? "maisim development build" : $"maisim v{System.Reflection.Assembly.GetExecutingAssembly().GetName().Version}",
                    Scale = new Vector2(0)
                },
                new Container
                {
                    Anchor = Anchor.TopRight,
                    Origin = Anchor.TopRight,
                    Size = new Vector2(400, 100),
                    Position = new Vector2(-30, 30),
                    Children = new Drawable[]
                    {
                        trackTitleText = new MaisimSpriteText
                        {
                            Anchor = Anchor.TopRight,
                            Origin = Anchor.TopRight,
                            Font = MaisimFont.GetFont(size: 35f, weight: MaisimFont.FontWeight.Bold),
                            Alpha = 0
                        },
                        trackArtistText = new MaisimSpriteText
                        {
                            Anchor = Anchor.TopRight,
                            Origin = Anchor.TopRight,
                            Position = new Vector2(0, 40),
                            Font = MaisimFont.GetFont(weight: MaisimFont.FontWeight.Regular),
                            Alpha = 0
                        }
                    }
                }
            };
            workingBeatmap.CurrentBeatmapSet.BindValueChanged(workingBeatmapChanged);
        }

        /// <summary>
        /// Update and show the new track's information.
        /// </summary>
        /// <param name="beatmapSet">The new track's <see cref="BeatmapSet"/></param>
        private void updateNewBeatmap(BeatmapSet beatmapSet)
        {
            trackTitleText.Text = beatmapSet.TrackMetadata.Title;
            trackArtistText.Text = beatmapSet.TrackMetadata.Artist;
            trackArtistText.FadeTo(1, 500, Easing.OutQuint);
            trackTitleText.FadeTo(1, 500, Easing.OutQuint);
            Scheduler.AddDelayed(
            () =>
            {
                trackArtistText.FadeTo(0, 2000, Easing.OutQuint);
                trackTitleText.FadeTo(0, 2000, Easing.OutQuint);
            }, 5000);
        }

        public override void OnEntering(ScreenTransitionEvent e)
        {
            maisimLogo.ScaleTo(1, 1000, Easing.OutQuint);
            playButton.ScaleTo(1, 700, Easing.OutQuint);
            editButton.ScaleTo(1, 800, Easing.OutQuint);
            browseButton.ScaleTo(1, 900, Easing.OutQuint);
            exitButton.ScaleTo(1, 1000, Easing.OutQuint);
            versionText.ScaleTo(1, 1000, Easing.OutQuint);
        }

        public override void OnSuspending(ScreenTransitionEvent e)
        {
            this.ScaleTo(0f, 750, Easing.OutQuint);
            this.MoveToX(-DrawWidth, 750, Easing.OutExpo);
        }

        public override void OnResuming(ScreenTransitionEvent e)
        {
            this.ScaleTo(1, 750, Easing.OutQuint);
            this.MoveToX(0, 750, Easing.OutExpo);
        }

        public override float BackgroundParallaxAmount => 0.5f;
    }
}
