using System;
using maisim.Game.Beatmaps;
using maisim.Game.Component;
using maisim.Game.Graphics.UserInterfaceV2;
using maisim.Game.Utils;
using NUnit.Framework.Internal;
using osu.Framework.Allocation;
using osu.Framework.Audio.Track;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Screens;
using Logger = osu.Framework.Logging.Logger;

namespace maisim.Game.Screen
{
    /// <summary>
    /// The song selection screen that shows a list of all the songs to the user who can select a track to play from there.
    /// </summary>
    public class SongSelectionScreen : MaisimScreen
    {
        public override float BackgroundParallaxAmount => 0.2f;

        // TODO: These two bindables need to pass via DI instead of assign a random one.
        private Bindable<DifficultyLevel> bindableDifficultyLevel = new Bindable<DifficultyLevel>();

        private Bindable<BeatmapSet> bindableBeatmapSet = new Bindable<BeatmapSet>(new BeatmapSetTestFixture().BeatmapSet);

        // TODO: This is for testing purposes only. This must be remove with the upper bindable.
        private Track currentTrack;

        [BackgroundDependencyLoader]
        private void load(ITrackStore tracks)
        {
            InternalChildren = new Drawable[]
            {
                new BeatmapSetSelection(bindableBeatmapSet),
                new BeatmapSetInfoBox(bindableDifficultyLevel,bindableBeatmapSet)
                {
                    Anchor = Anchor.TopRight,
                    Origin = Anchor.TopRight,
                    RelativeSizeAxes = Axes.Y,
                },
                new BackButton
                {
                    Anchor = Anchor.BottomLeft,
                    Origin = Anchor.BottomLeft,
                    Action = () => this.Exit()
                }
            };
            currentTrack = tracks.Get(bindableBeatmapSet.Value.AudioFileName);
            currentTrack.Looping = true;
        }

        public override void OnEntering(ScreenTransitionEvent e)
        {
            currentTrack.Seek(bindableBeatmapSet.Value.PreviewTime);
            currentTrack.Start();

            base.OnEntering(e);
        }

        public override void OnSuspending(ScreenTransitionEvent e)
        {
            currentTrack.Stop();

            base.OnSuspending(e);
        }

        public override void OnResuming(ScreenTransitionEvent e)
        {
            currentTrack.Start();

            base.OnResuming(e);
        }

        public override bool OnExiting(ScreenExitEvent e)
        {
            currentTrack.Stop();

            return base.OnExiting(e);
        }

        protected override void Update()
        {
            // if track's end is reached, restart it with seeking to the preview time
            // To make it precise, floor the double to int
            if (currentTrack.HasCompleted)
            {
                currentTrack.Seek(bindableBeatmapSet.Value.PreviewTime);
                currentTrack.Start();
            }

            base.Update();
        }
    }
}
