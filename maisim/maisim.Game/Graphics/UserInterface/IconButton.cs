using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Input.Events;
using osuTK;
using osuTK.Graphics;

namespace maisim.Game.Graphics.UserInterface
{
    /// <summary>
    /// A custom button with a sprite icon.
    /// </summary>
    public class IconButton : Button
    {
        public IconUsage Icon { get; set; }
        private SpriteIcon spriteIcon;

        private Box backgroundBox;

        [BackgroundDependencyLoader]
        private void load()
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            Size = new Vector2(50);
            Child = new Container()
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                RelativeSizeAxes = Axes.Both,
                Masking = true,
                CornerRadius = 5,
                Children = new Drawable[]
                {
                    backgroundBox = new Box()
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        RelativeSizeAxes = Axes.Both,
                        Colour = MaisimColour.Gray(.2f),
                        Alpha = 0
                    },
                    spriteIcon = new SpriteIcon()
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        RelativeSizeAxes = Axes.Both,
                        Size = new Vector2(0.5f),
                        Icon = Icon,
                        Colour = Color4.White
                    }
                }
            };
        }

        protected override bool OnHover(HoverEvent e)
        {
            backgroundBox.FadeTo(0.5f, 100);
            return base.OnHover(e);
        }

        protected override void OnHoverLost(HoverLostEvent e)
        {
            backgroundBox.FadeTo(0, 100);
            base.OnHoverLost(e);
        }

        protected override bool OnMouseDown(MouseDownEvent e)
        {
            this.ScaleTo(0.8f, 100);
            return base.OnMouseDown(e);
        }

        protected override void Update()
        {
            spriteIcon.Icon = Icon;

            base.Update();
        }
    }
}
