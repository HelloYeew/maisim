using maisim.Game.Component.Gameplay.Notes;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osuTK;
using osuTK.Graphics;

namespace maisim.Game.Component.Gameplay
{
    /// <summary>
    /// A spawner that spawn a <see cref="DrawableNote"/> at its position.
    /// </summary>
    public class NoteSpawner : CircularContainer
    {
        /// <summary>
        /// Show the spawner location as a small circle.
        /// </summary>
        public bool ShowOutline { get; set; }

        /// <summary>
        /// Target that the spawner is spawning notes for.
        /// </summary>
        public float TargetAngles { get; set; }

        [BackgroundDependencyLoader]
        private void load()
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            Size = new Vector2(1,1);

            if (ShowOutline)
            {
                Child = new Circle
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    RelativeSizeAxes = Axes.Both,
                    Colour = Color4.White,
                    Size = new Vector2(5)
                };
            }
        }
    }
}
