using System;
using maisim.Game.Graphics.Sprites;
using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Effects;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Localisation;
using osuTK;
using osuTK.Graphics;

namespace maisim.Game.Graphics.UserInterface.Overlays
{
    public class NowPlayingOverlay : MaisimFocusedOverlayContainer
    {
        [Resolved]
        private MusicPlayer musicPlayer { get; set; }

        [Resolved]
        private WorkingBeatmap workingBeatmap { get; set; }

        public const float PLAYER_HEIGHT = 130;
        public const float TRANSITION_LENGTH = 600;
        public const float PROGRESS_HEIGHT = 10;
        public const float BOTTOM_BLACK_AREA_HEIGHT = 55;

        private Drawable background;
        private BasicSliderBar<double> progressBar;

        private SpriteIcon prevButton;
        private SpriteIcon playButton;
        private SpriteIcon nextButton;

        private SpriteText title, artist;

        private Container dragContainer;
        private Container playerContainer;

        protected Container MainContainer;

        public NowPlayingOverlay()
        {
            Width = 400;
            Margin = new MarginPadding(10);
        }

        [BackgroundDependencyLoader]
        private void load()
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
                                title = new MaisimSpriteText
                                {
                                    Anchor = Anchor.TopCentre,
                                    Origin = Anchor.BottomCentre,
                                    Position = new Vector2(0,40),
                                    Font = MaisimFont.GetFont(size:25, italics:true),
                                    Colour = Color4.White,
                                    Text = workingBeatmap.CurrentBeatmapSet.Value.TrackMetadata.Title
                                },
                                artist = new MaisimSpriteText
                                {
                                    Anchor = Anchor.TopCentre,
                                    Origin = Anchor.TopCentre,
                                    Position = new Vector2(0,45),
                                    Font = MaisimFont.GetFont(size:15, italics:true, weight: MaisimFont.FontWeight.Bold),
                                    Colour = Color4.White,
                                    Text = workingBeatmap.CurrentBeatmapSet.Value.TrackMetadata.Artist
                                },
                                new Container
                                {
                                    Padding = new MarginPadding { Bottom = PROGRESS_HEIGHT },
                                    Height = BOTTOM_BLACK_AREA_HEIGHT,
                                    RelativeSizeAxes = Axes.X,
                                    Anchor = Anchor.BottomCentre,
                                    Origin = Anchor.BottomCentre,
                                    Children = new Drawable[]
                                    {
                                        new FillFlowContainer<SpriteIcon>
                                        {
                                            AutoSizeAxes = Axes.Both,
                                            Direction = FillDirection.Horizontal,
                                            Spacing = new Vector2(5),
                                            Origin = Anchor.Centre,
                                            Anchor = Anchor.Centre,
                                            Children = new[]
                                            {
                                                prevButton = new SpriteIcon()
                                                {
                                                    Anchor = Anchor.Centre,
                                                    Origin = Anchor.Centre,
                                                    // Action = () => musicController.PreviousTrack(),
                                                    Icon = FontAwesome.Solid.StepBackward,
                                                    Size = new Vector2(20)
                                                },
                                                playButton = new SpriteIcon()
                                                {
                                                    Anchor = Anchor.Centre,
                                                    Origin = Anchor.Centre,
                                                    Scale = new Vector2(1.4f),
                                                    // Action = () => musicController.TogglePause(),
                                                    Icon = FontAwesome.Regular.PlayCircle,
                                                    Size = new Vector2(20)
                                                },
                                                nextButton = new SpriteIcon()
                                                {
                                                    Anchor = Anchor.Centre,
                                                    Origin = Anchor.Centre,
                                                    // Action = () => musicController.NextTrack(),
                                                    Icon = FontAwesome.Solid.StepForward,
                                                    Size = new Vector2(20)
                                                },
                                            }
                                        }
                                    }
                                },
                                // progressBar = new BasicSliderBar<double>()
                                // {
                                //     Anchor = Anchor.BottomCentre,
                                //     Origin = Anchor.BottomCentre,
                                //     Height = PROGRESS_HEIGHT / 2,
                                //     // BackgroundColour = Color4.YellowDarker.Opacity(0.5f)
                                // }
                            }
                        },
                    }
                }
            };
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
    }
}
