using maisim.Game.Graphics.Gameplay;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Screens;
using osuTK;

namespace maisim.Game.Screen.Gameplay
{
    /// <summary>
    /// A screenstack that contain all gameplay element and handle the <see cref="Playfield"/> screen.
    /// </summary>
    public partial class PlayfieldScreen : ScreenStack
    {
        /// <summary>
        /// A <see cref="Playfield"/> screen instance inside this screenstack.
        /// </summary>
        public Playfield Playfield { get; set; }

        public PlayfieldScreen()
        {
            Playfield = new Playfield();
        }

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
                Playfield
            };
        }
    }
}
