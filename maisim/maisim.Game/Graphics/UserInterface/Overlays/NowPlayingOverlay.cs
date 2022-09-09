using System;
using maisim.Game.Graphics.Sprites;
using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Effects;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
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

        public const float PLAYER_HEIGHT = 200;
        public const float TRANSITION_LENGTH = 600;
        public const float PROGRESS_HEIGHT = 10;
        public const float BOTTOM_BLACK_AREA_HEIGHT = 55;

        private Drawable background;
        private BasicSliderBar<double> progressBar;

        private SpriteIcon prevButton;
        private SpriteIcon playButton;
        private SpriteIcon nextButton;

        private SpriteText title, artist;
        private Sprite cover;

        private Container playerContainer;

        protected Container MainContainer;

        public NowPlayingOverlay()
        {
            Width = 420;
            Margin = new MarginPadding(10);
        }

        [BackgroundDependencyLoader]
        private void load(TextureStore textureStore)
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
                                    Child = new Sprite()
                                    {
                                        Anchor = Anchor.Centre,
                                        Origin = Anchor.Centre,
                                        RelativeSizeAxes = Axes.Both,
                                        Texture = textureStore.Get(workingBeatmap.CurrentBeatmapSet.Value.TrackMetadata.CoverPath),
                                        FillMode = FillMode.Fill,
                                    }
                                },
                                new Container()
                                {
                                    Anchor = Anchor.TopRight,
                                    Origin = Anchor.TopRight,
                                    Size = new Vector2(300,100),
                                    Children = new Drawable[]
                                    {
                                        title = new MaisimSpriteText()
                                        {
                                            Anchor = Anchor.TopLeft,
                                            Origin = Anchor.TopLeft,
                                            Position = new Vector2(0,23),
                                            Text = workingBeatmap.CurrentBeatmapSet.Value.TrackMetadata.Title
                                        },
                                        artist = new MaisimSpriteText()
                                        {
                                            Anchor = Anchor.BottomLeft,
                                            Origin = Anchor.BottomLeft,
                                            Position = new Vector2(0,-23),
                                            Text = workingBeatmap.CurrentBeatmapSet.Value.TrackMetadata.Artist,
                                            Colour = MaisimColour.NowPlayingArtistColor
                                        },
                                    }
                                }
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
