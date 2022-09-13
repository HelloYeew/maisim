using System;
using maisim.Game.Beatmaps;
using maisim.Game.Component;
using maisim.Game.Graphics.UserInterface.Overlays;
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
        [Resolved]
        private WorkingBeatmap workingBeatmap { get; set; }

        public override float BackgroundParallaxAmount => 0.2f;

        [BackgroundDependencyLoader]
        private void load()
        {
            InternalChildren = new Drawable[]
            {
                new BeatmapSetSelection(workingBeatmap.CurrentBeatmapSet),
                new BeatmapSetInfoBox(workingBeatmap.CurrentDifficultyLevel,workingBeatmap.CurrentBeatmapSet)
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
        }
    }
}
