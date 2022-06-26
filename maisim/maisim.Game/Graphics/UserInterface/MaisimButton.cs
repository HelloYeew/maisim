using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.UserInterface;

namespace maisim.Game.Graphics.UserInterface
{
    public class MaisimButton : BasicButton
    {
        [BackgroundDependencyLoader]
        private void load()
        {
            BackgroundColour = Colour4.MediumPurple;
            CornerRadius = 30;
        }
    }
}
