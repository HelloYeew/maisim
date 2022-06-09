using maisim.Game.Graphics.Sprites;
using maisim.Game.Graphics.UserInterface;
using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Screens;
using osuTK;

namespace maisim.Game.Screen
{
    /// <summary>
    /// The main menu screen that includes all the main menu components.
    /// </summary>
    public class MainMenuScreen : osu.Framework.Screens.Screen
    {
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
                                new MainMenuButton("Play",FontAwesome.Solid.Play,Color4Extensions.FromHex("73E99B"))
                                {
                                    Anchor = Anchor.Centre,
                                    Origin = Anchor.Centre,
                                    Size = new Vector2(400, 60),
                                    Action = () => this.Push(new SongSelectionScreen())
                                },new MainMenuButton("Edit",FontAwesome.Solid.Edit,Color4Extensions.FromHex("E9C173"))
                                {
                                    Anchor = Anchor.Centre,
                                    Origin = Anchor.Centre,
                                    Size = new Vector2(400, 60)
                                },new MainMenuButton("Browse",FontAwesome.Solid.ListUl,Color4Extensions.FromHex("E773E9"))
                                {
                                    Anchor = Anchor.Centre,
                                    Origin = Anchor.Centre,
                                    Size = new Vector2(400, 60)
                                },new MainMenuButton("Exit",FontAwesome.Solid.DoorOpen,Color4Extensions.FromHex("E97373"))
                                {
                                    Anchor = Anchor.Centre,
                                    Origin = Anchor.Centre,
                                    Size = new Vector2(400, 60)
                                }
                            }
                        }
                    }
                }, new Sprite
                {
                    Anchor = Anchor.TopLeft,
                    Origin = Anchor.TopLeft,
                    Texture = textureStore.Get("logo"),
                    Size = new Vector2(300),
                    Position = new Vector2(30, 30),
                }, new MaisimSpriteText
                {
                    Anchor = Anchor.BottomLeft,
                    Origin = Anchor.BottomLeft,
                    Text = "Maisim development build"
                }
            };
        }

        public override void OnEntering(ScreenTransitionEvent e)
        {
            this.FadeInFromZero(500);
        }
    }
}
