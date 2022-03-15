using maisim.Game.Component.Gameplay.Notes;
using osu.Framework.Allocation;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics;
using osuTK;

namespace maisim.Game.Screen.Gameplay
{
    public class Playfield : osu.Framework.Screens.Screen
    {
        [BackgroundDependencyLoader]
        private void load()
        {

        }

        public void spawnNote(DrawableNote note)
        {
            AddInternal(note);
        }
    }
}
