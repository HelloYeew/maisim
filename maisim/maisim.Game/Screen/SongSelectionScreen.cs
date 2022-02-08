using maisim.Game.Component;
using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osuTK;

namespace maisim.Game.Screen
{
    public class SongSelectionScreen : osu.Framework.Screens.Screen
    {
        [BackgroundDependencyLoader]
        private void load()
        {
            InternalChildren = new Drawable[]
            {
                new Container
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Size = new Vector2(320,320),
                    RelativePositionAxes = Axes.X,
                    Children = new Drawable[]
                    {
                        new SongSelectionBackground(Color4Extensions.FromHex("fb5f99"))
                        {
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            RelativePositionAxes = Axes.Both,
                            RelativeSizeAxes = Axes.Both,
                        },new Container
                        {
                            Anchor = Anchor.TopCentre,
                            Origin = Anchor.TopCentre,
                            RelativePositionAxes = Axes.Both,
                            RelativeSizeAxes = Axes.Both,
                            Children = new Drawable[]
                            {
                                new TrackCardFocused("Test/sukino-skill.jpg", "Sukino Skill", "Wake Up, Girls!",
                                    100.6969f, "SSS", 1278, 2424, true, true, "HelloYeew", 120)
                                {
                                    Anchor = Anchor.TopCentre,
                                    Origin = Anchor.TopCentre,
                                    RelativePositionAxes = Axes.Both,
                                    Size = new Vector2(300,384)
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}
