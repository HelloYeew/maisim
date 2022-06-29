using maisim.Game.Graphics.Sprites;
using maisim.Game.Graphics.UserInterface;
using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Screens;
using osuTK;

namespace maisim.Game.Screen
{
    /// <summary>
    /// The main menu screen that includes all the main menu components.
    /// </summary>
    public class MainMenuScreen : osu.Framework.Screens.Screen, IMaisimScreen
    {
        private Sprite maisimLogo;
        private MainMenuButton playButton;
        private MainMenuButton editButton;
        private MainMenuButton browseButton;
        private MainMenuButton exitButton;
        private MaisimSpriteText versionText;

        [BackgroundDependencyLoader]
        private void load(TextureStore textureStore)
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
                    Child = maisimLogo = new Sprite
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Texture = textureStore.Get("logo"),
                        Size = new Vector2(300),
                        Scale = new Vector2(0)
                    }
                },
                versionText = new MaisimSpriteText
                {
                    Anchor = Anchor.BottomLeft,
                    Origin = Anchor.BottomLeft,
                    Text = "maisim development build",
                    Scale = new Vector2(0)
                }
            };
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

        public float BackgroundParallaxAmount => 0.5f;
    }
}
