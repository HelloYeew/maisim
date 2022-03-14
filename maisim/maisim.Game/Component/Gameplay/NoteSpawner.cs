using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osuTK;
using osuTK.Graphics;

namespace maisim.Game.Component.Gameplay
{
    public class NoteSpawner : CircularContainer
    {
        public bool ShowOutline { get; set; } = false;

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

        private Vector2 position()
        {
            return new Vector2(Position.X, Position.Y);
        }
    }
}
