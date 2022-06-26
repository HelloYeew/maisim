using maisim.Game.Graphics.Sprites;
using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osuTK;
using osuTK.Graphics;

namespace maisim.Game.Graphics.UserInterface
{
    public class MaisimButton : Button
    {
        private readonly Color4 buttonColor;
        private readonly Color4 buttonOutlineColor;

        [BackgroundDependencyLoader]
        private void load()
        {
            CornerRadius = 30;
        }

        public MaisimButton(string text, Color4 buttonColor, Color4 buttonOutlineColor)
        {
            this.buttonColor = buttonColor;
            this.buttonOutlineColor = buttonOutlineColor;

            InternalChild = new Container
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Size = new Vector2(400, 60),
                Masking = true,
                CornerRadius = 30,
                BorderThickness = 5,
                BorderColour = buttonOutlineColor,
                Children = new Drawable[]
                {
                    new Box
                    {
                        RelativeSizeAxes = Axes.Both,
                        Anchor = Anchor.CentreRight,
                        Origin = Anchor.CentreRight,
                        Colour = buttonColor
                    },
                    new MaisimSpriteText()
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Text = text
                    },
                    new ClickHoverSounds()
                }
            };
        }
    }
}
