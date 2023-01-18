using maisim.Game.Graphics.UserInterface;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osuTK;

namespace maisim.Game.Tests.Visual.Component
{
    public partial class TestSceneSongSelectionBackground : maisimTestScene
    {
        public TestSceneSongSelectionBackground()
        {
            Child = new Container
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Size = new Vector2(400, 400),
                RelativePositionAxes = Axes.X,
                Children = new Drawable[]
                {
                    new SongSelectionBackground(Color4Extensions.FromHex("fb5f99"))
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        RelativePositionAxes = Axes.Both,
                        RelativeSizeAxes = Axes.Both,
                    }
                }
            };
        }
    }
}
