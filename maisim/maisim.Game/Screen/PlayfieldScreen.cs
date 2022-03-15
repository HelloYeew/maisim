using maisim.Game.Component.Gameplay;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osuTK;

namespace maisim.Game.Screen
{
    public class PlayfieldScreen : osu.Framework.Screens.Screen
    {
        [BackgroundDependencyLoader]
        private void load()
        {
            InternalChildren = new Drawable[]
            {
                new MaisimRing
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Size = new Vector2(1),
                },
                new VisualSpawner
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                }
            };
        }
    }
}
