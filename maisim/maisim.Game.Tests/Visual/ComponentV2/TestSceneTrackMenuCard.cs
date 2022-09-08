using System.Reflection;
using maisim.Game.Beatmaps;
using maisim.Game.Graphics.UserInterfaceV2;
using maisim.Game.Utils;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;

namespace maisim.Game.Tests.Visual.ComponentV2
{
    public class TestSceneTrackMenuCard : maisimTestScene
    {
        public TestSceneTrackMenuCard()
        {
            BeatmapSetTestFixture mockObject = new BeatmapSetTestFixture();

            string beatmapList = "Beatmap List :\n";
            string beatmapSetInfo = $"Beatmap Set Info ({mockObject.BeatmapSet}) :\n";

            // Include all beatmap set parameters in the beatmap set info.
            foreach (PropertyInfo property in typeof(BeatmapSet).GetProperties())
            {
                beatmapSetInfo += $"{property.Name} - {property.GetValue(mockObject.BeatmapSet)} \n";
            }

            foreach (var beatmap in mockObject.BeatmapSet.Beatmaps)
            {
                beatmapList += beatmap + "\n";
            }

            Children = new Drawable[]
            {
                new BeatmapSetCard(mockObject.BeatmapSet)
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                },
                new TextFlowContainer()
                {
                    Anchor = Anchor.TopLeft,
                    Origin = Anchor.TopLeft,
                    RelativeSizeAxes = Axes.X,
                    AutoSizeAxes = Axes.Y,
                    Text = beatmapSetInfo
                },
                new TextFlowContainer()
                {
                    Anchor = Anchor.TopRight,
                    Origin = Anchor.TopRight,
                    RelativeSizeAxes = Axes.Y,
                    AutoSizeAxes = Axes.X,
                    Text = beatmapList,
                    TextAnchor = Anchor.TopRight,
                }
            };
        }
    }
}
