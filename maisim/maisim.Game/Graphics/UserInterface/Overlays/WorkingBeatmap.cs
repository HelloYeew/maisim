using System;
using System.Collections.Generic;
using maisim.Game.Beatmaps;
using maisim.Game.Utils;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics.Containers;

namespace maisim.Game.Graphics.UserInterface.Overlays
{
    /// <summary>
    /// The object that use to get the information of the current beatmap that is being played.
    /// </summary>
    public class WorkingBeatmap : CompositeDrawable
    {
        public Bindable<BeatmapSet> CurrentBeatmapSet { get; } = new Bindable<BeatmapSet>();
        public Bindable<DifficultyLevel> CurrentDifficultyLevel { get; } = new Bindable<DifficultyLevel>();

        private List<BeatmapSet> beatmapSetList = new List<BeatmapSet>();

        private readonly string[] beatmapSetTitleList =
        {
            "Diamond City Lights",
            "only my railgun",
            "RAISE MY SWORD",
            "Sukino Skill",
            "Tenkai e no Kippu",
            "ReI"
        };

        [BackgroundDependencyLoader]
        private void load()
        {
            // Load beatmap set list
            for(int i = 0; i < beatmapSetTitleList.Length; i++)
            {
                BeatmapSet beatmapSet = new BeatmapSetTestFixture(beatmapSetTitleList[i]).BeatmapSet;
                beatmapSet.DatabaseID = i + 1;
                beatmapSetList.Add(beatmapSet);
            }

            // random the beatmapset from the list and set it to the current beatmapset
            CurrentBeatmapSet.Value = beatmapSetList[RandomExtensions.NextInRange(new Random(), 0, beatmapSetList.Count - 1)];
            CurrentDifficultyLevel.Value = DifficultyLevel.Basic;
        }

        /// <summary>
        /// Go to the next beatmapset
        /// </summary>
        public void GoToNextBeatmapSet()
        {
            // We determine the next beatmapset by the current beatmapset's database id
            int nextBeatmapSetId = CurrentBeatmapSet.Value.DatabaseID + 1;
            if (nextBeatmapSetId > beatmapSetList.Count)
                nextBeatmapSetId = 1;
            // Set the next beatmapset to the current beatmapset
            // Get the beatmap set from the list by the database id
            CurrentBeatmapSet.Value = beatmapSetList.Find(beatmapSet => beatmapSet.DatabaseID == nextBeatmapSetId);
        }

        /// <summary>
        /// Go to the previous beatmapset
        /// </summary>
        public void GoToPreviousBeatmapSet()
        {
            int previousBeatmapSetId = CurrentBeatmapSet.Value.DatabaseID - 1;
            if (previousBeatmapSetId < 1)
                previousBeatmapSetId = beatmapSetList.Count;
            CurrentBeatmapSet.Value = beatmapSetList.Find(beatmapSet => beatmapSet.DatabaseID == previousBeatmapSetId);
        }
    }
}
