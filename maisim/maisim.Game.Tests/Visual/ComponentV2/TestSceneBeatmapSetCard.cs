using System.Reflection;
using maisim.Game.Beatmaps;
using maisim.Game.Configuration;
using maisim.Game.Graphics.UserInterfaceV2;
using maisim.Game.Utils;
using NUnit.Framework;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;

namespace maisim.Game.Tests.Visual.ComponentV2
{
    public class TestSceneBeatmapSetCard : maisimTestScene
    {
        [Resolved]
        private MaisimConfigManager configManager { get; set; }

        private BeatmapSetTestFixture mockObject = new BeatmapSetTestFixture();
        private BeatmapSetCard card;

        public TestSceneBeatmapSetCard()
        {
            string beatmapList = "Beatmap List :\n";
            string beatmapSetInfo = $"Beatmap Set Info ({BeatmapUtils.GetBeatmapSetString(mockObject.BeatmapSet)}) :\n";

            // Include all beatmap set parameters in the beatmap set info.
            foreach (PropertyInfo property in typeof(BeatmapSet).GetProperties())
            {
                beatmapSetInfo += $"{property.Name} - {property.GetValue(mockObject.BeatmapSet)} \n";
            }

            foreach (var beatmap in mockObject.BeatmapSet.Beatmaps)
            {
                beatmapList +=
                    $"{BeatmapUtils.GetBeatmapString(beatmap)}\n";
            }

            Children = new Drawable[]
            {
                card = new BeatmapSetCard(mockObject.BeatmapSet)
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

        [Test]
        public void TestBeatmapSetCard()
        {
            AddStep("Set use unicode info to true", () => configManager.SetValue(MaisimSetting.UseUnicodeInfo, true));
            AddAssert("Title is in unicode", () => card.GetTitle() == mockObject.BeatmapSet.TrackMetadata.TitleUnicode);
            AddAssert("Artist is in unicode", () => card.GetArtist() == mockObject.BeatmapSet.TrackMetadata.ArtistUnicode);
            AddStep("Set use unicode info to false", () => configManager.SetValue(MaisimSetting.UseUnicodeInfo, false));
            AddAssert("Title use original one", () => card.GetTitle() == mockObject.BeatmapSet.TrackMetadata.Title);
            AddAssert("Artist use original one", () => card.GetArtist() == mockObject.BeatmapSet.TrackMetadata.Artist);
        }
    }
}
