using maisim.Game.Graphics.Sprites;
using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Input.Events;
using osuTK;
using osuTK.Graphics;

namespace maisim.Game.Graphics.UserInterface
{
    public class MaisimButton : Button
    {
        private readonly Color4 buttonColor;
        private readonly Box buttonBox;

        [BackgroundDependencyLoader]
        private void load()
        {
            CornerRadius = 30;
        }

        public MaisimButton(string text, Color4 buttonColor, Color4 buttonOutlineColor)
        {
            this.buttonColor = buttonColor;

            InternalChild = new Container
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Size = new Vector2(350, 50),
                Masking = true,
                CornerRadius = 30,
                BorderColour = buttonOutlineColor,
                BorderThickness = 5,
                Children = new Drawable[]
                {
                    buttonBox = new Box
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

        // TODO: Change this effect to make it different from main menu button
        protected override bool OnHover(HoverEvent e)
        {
            buttonBox.Colour = buttonColor.Darken(0.25f);
            return base.OnHover(e);
        }

        protected override void OnHoverLost(HoverLostEvent e)
        {
            buttonBox.Colour = buttonColor;
            base.OnHoverLost(e);
        }

        protected override bool OnMouseDown(MouseDownEvent e)
        {
            buttonBox.Colour = buttonColor.Darken(0.5f);
            return base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseUpEvent e)
        {
            buttonBox.Colour = buttonColor;
            base.OnMouseUp(e);
        }
    }
}
