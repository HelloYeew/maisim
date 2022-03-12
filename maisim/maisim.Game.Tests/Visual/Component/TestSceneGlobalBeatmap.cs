using maisim.Game.Beatmaps;
using maisim.Game.Component;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;

namespace maisim.Game.Tests.Visual.Component;

public class TestSceneGlobalBeatmap : maisimTestScene
{
    private GlobalBeatmap mockGlobalBeatmap;
    private TrackMetadata dummyTrackMetadata;
    private Bindable<TrackMetadata> currentWorkingTrackMetadata;
    private Bindable<TrackMetadata> currentBindTrackMetadata;

    public TestSceneGlobalBeatmap()
    {
        mockGlobalBeatmap = new GlobalBeatmap();
        dummyTrackMetadata = new TrackMetadata
        {
            Title = "FREEDOM DiVE↓",
            Artist = "xi",
            CoverPath = "Test/parousia.jpg",
            Bpm = 0
        };
        currentBindTrackMetadata.SetDefault();

        Children = new Drawable[]
        {
            new CurrentWorkingBeatmapTest()
        };
    }

    public class CurrentWorkingBeatmapTest : CompositeDrawable
    {
        private string title;
        private string artist;
        private string coverPath;
        private float bpm;
        private TextFlowContainer currentWorkingBeatmapText;

        [BackgroundDependencyLoader]
        private void load()
        {
            title = "";
            artist = "";
            coverPath = "";
            bpm = 0;

            InternalChildren = new Drawable[]
            {
                currentWorkingBeatmapText = new TextFlowContainer
                {
                    Anchor = Anchor.CentreLeft,
                    Origin = Anchor.CentreLeft,
                    RelativeSizeAxes = Axes.Both,
                    Text = "Title : " + title + "\nArtist : " + artist + "\nCoverPath : " + coverPath + "\nBpm : " + bpm
                }
            };
        }
    }
}
