using maisim.Game.Component.Gameplay;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Screens;
using osuTK;

namespace maisim.Game.Screen.Gameplay
{
    public class PlayfieldScreen : ScreenStack
    {
        public Playfield Playfield { get; set; }

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
                },
                Playfield = new Playfield()
            };
        }
    }
}
