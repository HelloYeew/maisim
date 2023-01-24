using System;
using System.Collections.Generic;
using maisim.Game.Beatmaps;
using maisim.Game.Utils;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics.Containers;
using osu.Framework.Logging;

namespace maisim.Game.Graphics.UserInterface.Overlays
{
    /// <summary>
    /// The object that use to get the information of the current beatmap that is being played.
    /// </summary>
    public partial class WorkingBeatmapManager : CompositeDrawable
    {
        [Resolved]
        private CurrentWorkingBeatmap currentWorkingBeatmap { get; set; }

        private List<BeatmapSet> beatmapSetList = new List<BeatmapSet>();

        private void beatmapSetChanged(ValueChangedEvent<BeatmapSet> beatmapSetEvent) =>
            onBeatmapChanged(beatmapSetEvent.OldValue, beatmapSetEvent.NewValue);

        [BackgroundDependencyLoader]
        private void load()
        {
            // Load beatmap set list
            for(int i = 0; i < TestUtil.AvailableBeatmapSetTrack.Length; i++)
            {
                BeatmapSet beatmapSet = new BeatmapSetTestFixture(TestUtil.AvailableBeatmapSetTrack[i]).BeatmapSet;
                beatmapSet.DatabaseID = i + 1;
                beatmapSet.BeatmapSetID = i + 1;
                beatmapSetList.Add(beatmapSet);
            }

            // random the beatmapset from the list and set it to the current beatmapset
            currentWorkingBeatmap.SetCurrentBeatmapSet(beatmapSetList[RandomExtensions.NextInRange(new Random(), 0, beatmapSetList.Count - 1)]);
            currentWorkingBeatmap.SetCurrentDifficultyLevel(DifficultyLevel.Basic);

            // bind the event
            currentWorkingBeatmap.BindBeatmapSetChanged(beatmapSetChanged);
        }

        /// <summary>
        /// Go to the next beatmapset
        /// </summary>
        public void GoToNextBeatmapSet()
        {
            Scheduler.Add(() =>
            {
                Logger.Log("Go to next beatmapset", LoggingTarget.Runtime, LogLevel.Debug);
                // We determine the next beatmapset by the current beatmapset's database id
                int nextBeatmapSetId = currentWorkingBeatmap.BeatmapSet.DatabaseID + 1;
                if (nextBeatmapSetId > beatmapSetList.Count)
                    nextBeatmapSetId = 1;
                // Set the next beatmapset to the current beatmapset
                // Get the beatmap set from the list by the database id
                currentWorkingBeatmap.SetCurrentBeatmapSet(beatmapSetList.Find(beatmapSet => beatmapSet.DatabaseID == nextBeatmapSetId));
                Logger.Log($"Current beatmapset id: {currentWorkingBeatmap.BeatmapSet.DatabaseID.ToString()}");
            });
        }

        /// <summary>
        /// Go to the previous beatmapset
        /// </summary>
        public void GoToPreviousBeatmapSet()
        {
            Scheduler.Add(() =>
            {
                int previousBeatmapSetId = currentWorkingBeatmap.BeatmapSet.DatabaseID - 1;
                if (previousBeatmapSetId < 1)
                    previousBeatmapSetId = beatmapSetList.Count;
                currentWorkingBeatmap.SetCurrentBeatmapSet(beatmapSetList.Find(beatmapSet => beatmapSet.DatabaseID == previousBeatmapSetId));
            });
        }

        /// <summary>
        /// A method that will be called when the beatmapset has changed in <see cref="WorkingBeatmapManager"/>'s <see cref="Bindable{T}"/>
        /// </summary>
        /// <param name="oldBeatmapSet">Old beatmapset</param>
        /// <param name="newBeatmapSet">New beatmapset</param>
        private void onBeatmapChanged(BeatmapSet oldBeatmapSet, BeatmapSet newBeatmapSet)
        {
            Logger.Log($"Current working beatmap set changed from ({oldBeatmapSet?.BeatmapSetID}) {oldBeatmapSet?.TrackMetadata.Title} - {oldBeatmapSet?.TrackMetadata.Artist} to ({newBeatmapSet?.BeatmapSetID}) {newBeatmapSet?.TrackMetadata.Title} - {newBeatmapSet?.TrackMetadata.Artist}");
        }
    }
}
