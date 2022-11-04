using maisim.Game.Beatmaps;
using maisim.Game.Graphics.Sprites;
using osu.Framework.Allocation;
using osu.Framework.Audio.Track;
using osu.Framework.Bindables;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Effects;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Graphics.UserInterface;
using osuTK;
using osuTK.Graphics;

namespace maisim.Game.Graphics.UserInterface.Overlays
{
    public class NowPlayingOverlay : MaisimFocusedOverlayContainer
    {
        [Resolved]
        private MusicPlayer musicPlayer { get; set; }

        [Resolved]
        private WorkingBeatmapManager workingBeatmapManager { get; set; }

        [Resolved]
        private CurrentWorkingBeatmap currentWorkingBeatmap { get; set; }

        [Resolved]
        private TextureStore textureStore { get; set; }

        public const float PLAYER_HEIGHT = 200;
        public const float TRANSITION_LENGTH = 600;

        private IconButton prevButton;
        private IconButton playButton;
        private IconButton nextButton;
        private ProgressBar progressBar;

        private SpriteText title, artist, currentTime, totalTime;
        private Sprite cover;

        private Container playerContainer;

        protected Container MainContainer;

        /// <summary>
        /// A <see cref="ValueChangedEvent{T}"/> that is fired when the <see cref="Beatmap"/> in <see cref="currentWorkingBeatmap"/> is changed.
        /// </summary>
        /// <param name="beatmapSetEvent">The <see cref="BeatmapSet"/> change event.</param>
        private void workingBeatmapChanged(ValueChangedEvent<BeatmapSet> beatmapSetEvent)
        {
            updateTotalTime();
            title.Text = beatmapSetEvent.NewValue.TrackMetadata.Title;
            artist.Text = beatmapSetEvent.NewValue.TrackMetadata.Artist;
            cover.Texture = textureStore.Get(currentWorkingBeatmap.BeatmapSet.TrackMetadata.CoverPath);
        }

        public NowPlayingOverlay()
        {
            Width = 420;
            Margin = new MarginPadding(10);
        }

        [BackgroundDependencyLoader]
        private void load(TextureStore localTextureStore)
        {
            Children = new Drawable[]
            {
                MainContainer = new Container()
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    RelativeSizeAxes = Axes.X,
                    AutoSizeAxes = Axes.Y,
                    Position = new Vector2(0, Toolbar.Toolbar.HEIGHT+10),
                    Children = new Drawable[]
                    {
                        playerContainer = new Container()
                        {
                            RelativeSizeAxes = Axes.X,
                            Height = PLAYER_HEIGHT,
                            Masking = true,
                            CornerRadius = 10,
                            EdgeEffect = new EdgeEffectParameters
                            {
                                Type = EdgeEffectType.Shadow,
                                Colour = Color4.Black.Opacity(0.7f),
                                Radius = 0.1f
                            },
                            Children = new Drawable[]
                            {
                                new Container()
                                {
                                    Anchor = Anchor.TopLeft,
                                    Origin = Anchor.TopLeft,
                                    Size = new Vector2(100),
                                    Padding = new MarginPadding(10),
                                    Child = new Container()
                                    {
                                        Anchor = Anchor.Centre,
                                        Origin = Anchor.Centre,
                                        RelativeSizeAxes = Axes.Both,
                                        Masking = true,
                                        CornerRadius = 10,
                                        Child = cover = new Sprite()
                                        {
                                            Anchor = Anchor.Centre,
                                            Origin = Anchor.Centre,
                                            RelativeSizeAxes = Axes.Both,
                                            Texture = localTextureStore.Get(currentWorkingBeatmap.BeatmapSet.TrackMetadata.CoverPath),
                                            FillMode = FillMode.Fill,
                                        }
                                    }
                                },
                                new Container()
                                {
                                    Anchor = Anchor.TopRight,
                                    Origin = Anchor.TopRight,
                                    Size = new Vector2(320,100),
                                    Children = new Drawable[]
                                    {
                                        title = new MaisimSpriteText()
                                        {
                                            Anchor = Anchor.TopLeft,
                                            Origin = Anchor.TopLeft,
                                            Position = new Vector2(0,23),
                                            Text = currentWorkingBeatmap.BeatmapSet.TrackMetadata.Title
                                        },
                                        artist = new MaisimSpriteText()
                                        {
                                            Anchor = Anchor.BottomLeft,
                                            Origin = Anchor.BottomLeft,
                                            Position = new Vector2(0,-23),
                                            Text = currentWorkingBeatmap.BeatmapSet.TrackMetadata.Artist,
                                            Colour = MaisimColour.NowPlayingArtistColor
                                        },
                                    }
                                },
                                new Container()
                                {
                                    Anchor = Anchor.BottomCentre,
                                    Origin = Anchor.BottomCentre,
                                    RelativeSizeAxes = Axes.X,
                                    Size = new Vector2(1,50),
                                    Position = new Vector2(0,-12),
                                    Children = new Drawable[]
                                    {
                                        playButton = new IconButton()
                                        {
                                            Icon = FontAwesome.Solid.Play,
                                            Action = () => musicPlayer.TogglePause()
                                        },
                                        prevButton = new IconButton()
                                        {
                                            Icon = FontAwesome.Solid.FastBackward,
                                            Action = () => musicPlayer.TogglePrevious(),
                                            Position = new Vector2(-50,0)
                                        },
                                        nextButton = new IconButton()
                                        {
                                            Icon = FontAwesome.Solid.FastForward,
                                            Action = () => musicPlayer.ToggleNext(),
                                            Position = new Vector2(50,0)
                                        },
                                    }
                                },
                                new Container()
                                {
                                    Anchor = Anchor.Centre,
                                    Origin = Anchor.Centre,
                                    RelativeSizeAxes = Axes.X,
                                    Size = new Vector2(0.65f,20),
                                    Position = new Vector2(0, 20),
                                    Masking = true,
                                    CornerRadius = 12,
                                    Child = progressBar = new ProgressBar(true)
                                    {
                                        Anchor = Anchor.Centre,
                                        Origin = Anchor.Centre,
                                        RelativeSizeAxes = Axes.X,
                                        Height = 18,
                                        FillColour = MaisimColour.NowPlayingProgressBarFillColor,
                                        BackgroundColour = MaisimColour.NowPlayingProgressBarBackgroundColor,
                                        OnSeek = musicPlayer.SeekTo
                                    }
                                },
                                new Container()
                                {
                                    Anchor = Anchor.Centre,
                                    Origin = Anchor.Centre,
                                    RelativeSizeAxes = Axes.X,
                                    Size = new Vector2(1,20),
                                    Position = new Vector2(0, 20),
                                    Masking = true,
                                    CornerRadius = 10,
                                    Children = new Drawable[]
                                    {
                                        currentTime = new MaisimSpriteText()
                                        {
                                            Anchor = Anchor.CentreLeft,
                                            Origin = Anchor.CentreLeft,
                                            Position = new Vector2(10,0),
                                            Text = "00:00"
                                        },
                                        totalTime = new MaisimSpriteText()
                                        {
                                            Anchor = Anchor.CentreRight,
                                            Origin = Anchor.CentreRight,
                                            Position = new Vector2(-10,0),
                                            Text = "00:00"
                                        }
                                    }
                                }
                            }
                        },
                    }
                }
            };

            currentWorkingBeatmap.BindValueChanged(workingBeatmapChanged);
            updateTotalTime();
        }

        protected override void Update()
        {
            base.Update();
            updateCurrentTime();
            updateTotalTime();
            progressBar.EndTime = musicPlayer.Track.Value.Length;
            progressBar.CurrentTime = musicPlayer.Track.Value.CurrentTime;
            playButton.Icon = musicPlayer.Track.Value.IsRunning ? FontAwesome.Solid.Pause : FontAwesome.Solid.Play;
        }

        protected override void PopIn()
        {
            base.PopIn();
            this.FadeIn(TRANSITION_LENGTH, Easing.OutQuint);
            MainContainer.ScaleTo(1, TRANSITION_LENGTH, Easing.OutElastic);
        }

        protected override void PopOut()
        {
            base.PopIn();
            this.FadeOut(TRANSITION_LENGTH, Easing.OutQuint);
            MainContainer.ScaleTo(0.9f, TRANSITION_LENGTH, Easing.OutQuint);
        }

        protected override void UpdateAfterChildren()
        {
            base.UpdateAfterChildren();

            Height = MainContainer.Height;
        }

        /// <summary>
        /// Update the current time of the song in the player
        /// </summary>
        private void updateCurrentTime()
        {
            double time = musicPlayer.Track.Value.CurrentTime;
            int minutes = (int) time / 1000 / 60;
            int seconds = (int) time / 1000 % 60;
            currentTime.Text = minutes.ToString("00") + ":" + seconds.ToString("00");
        }

        /// <summary>
        /// Update the total time of the song in the player
        /// </summary>
        private void updateTotalTime()
        {
            double length = musicPlayer.Track.Value.Length;
            int minutes = (int) length / 1000 / 60;
            int seconds = (int) length / 1000 % 60;
            totalTime.Text = minutes.ToString("00") + ":" + seconds.ToString("00");
        }
    }
}
