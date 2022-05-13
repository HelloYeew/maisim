using System;
using maisim.Game.Component;
using osu.Framework.Allocation;
using osu.Framework.Audio;
using osu.Framework.Audio.Track;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Screens;
using osuTK;

namespace maisim.Game.Screen
{
    /// <summary>
    /// The main menu screen that includes all the main menu components.
    /// </summary>
    public class MainMenuScreen : osu.Framework.Screens.Screen
    {
        private Track track;

        private ITrackStore trackStore;

        [BackgroundDependencyLoader]
        private void load(AudioManager audioManager)
        {
            InternalChildren = new Drawable[]
            {
                new Container
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Size = new Vector2(400, 400),
                    RelativeSizeAxes = Axes.X,
                    Children = new Drawable[]
                    {
                        new Box
                        {
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            RelativePositionAxes = Axes.Both,
                            RelativeSizeAxes = Axes.X,
                            Size = new Vector2(300, 300),
                            Colour = Color4Extensions.FromHex("f5be39"),
                        },
                        new FillFlowContainer
                        {
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            RelativeSizeAxes = Axes.X,
                            RelativePositionAxes = Axes.Y,
                            Children = new Drawable[]
                            {
                                new MainMenuButton("Play",FontAwesome.Solid.Play)
                                {
                                    Anchor = Anchor.Centre,
                                    Origin = Anchor.Centre,
                                    Size = new Vector2(300,300),
                                    Action = () => this.Push(new SongSelectionScreen())
                                },new MainMenuButton("Edit",FontAwesome.Solid.Edit)
                                {
                                    Anchor = Anchor.Centre,
                                    Origin = Anchor.Centre,
                                    Size = new Vector2(300,300)
                                },new MainMenuButton("Browse",FontAwesome.Solid.ListUl)
                                {
                                    Anchor = Anchor.Centre,
                                    Origin = Anchor.Centre,
                                    Size = new Vector2(300,300)
                                },new MainMenuButton("Exit",FontAwesome.Solid.DoorOpen)
                                {
                                    Anchor = Anchor.Centre,
                                    Origin = Anchor.Centre,
                                    Size = new Vector2(300,300)
                                }
                            }
                        }
                    }
                }
            };

            trackStore = audioManager.Tracks;
            track = trackStore.Get("test4");
            // track = trackStore.Get("rei/ReI");
            track.Looping = true;
            // track.Seek(50000);
            track.Start();
        }

        public override void OnEntering(ScreenTransitionEvent e)
        {
            track.Start();

            this.FadeInFromZero(500);
        }

        public override void OnSuspending(ScreenTransitionEvent e)
        {
            track.Stop();
        }

        public override void OnResuming(ScreenTransitionEvent e)
        {
            track.Start();

            base.OnResuming(e);
        }

        public override bool OnExiting(ScreenExitEvent screenExitEvent)
        {
            track.Stop();

            return base.OnExiting(screenExitEvent);
        }
    }
}
