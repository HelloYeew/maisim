using maisim.Game.Beatmaps;
using maisim.Game.Graphics;
using maisim.Game.Graphics.UserInterface.Overlays;
using maisim.Game.Graphics.UserInterfaceV2;
using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osuTK;
using osuTK.Graphics;

namespace maisim.Game.Tests.Visual.ComponentV2
{
    public class TestScenePlayButton : maisimTestScene
    {
        [Cached]
        private CurrentWorkingBeatmap currentWorkingBeatmap = new CurrentWorkingBeatmap();

        private PlayButton playButton;

        public TestScenePlayButton()
        {
            Child = new Container
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Size = new Vector2(600),
                Masking = true,
                Children = new Drawable[]
                {
                    new Box
                    {
                        RelativeSizeAxes = Axes.Both,
                        Colour = Color4.DimGray
                    },
                    playButton = new PlayButton()
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Size = new Vector2(540, 80)
                    }
                }
            };
            AddStep("change difficulty level to basic",
                () => currentWorkingBeatmap.SetCurrentDifficultyLevel(DifficultyLevel.Basic));
            AddStep("change difficulty level to basic",
                () => currentWorkingBeatmap.SetCurrentDifficultyLevel(DifficultyLevel.Advanced));
            AddStep("change difficulty level to basic",
                () => currentWorkingBeatmap.SetCurrentDifficultyLevel(DifficultyLevel.Expert));
            AddStep("change difficulty level to basic",
                () => currentWorkingBeatmap.SetCurrentDifficultyLevel(DifficultyLevel.Master));
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            Dependencies.CacheAs(currentWorkingBeatmap);
        }
    }
}
