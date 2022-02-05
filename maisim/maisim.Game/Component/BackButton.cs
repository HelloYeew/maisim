using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Input.Bindings;
using osuTK;
using osuTK.Graphics;

namespace maisim.Game.Component
{
    public class BackButton : VisibilityContainer
    {
        [BackgroundDependencyLoader]
        private void load()
        {
            InternalChildren = new Drawable[]
            {
                new Circle
                {
                    RelativeSizeAxes = Axes.Both,
                    Anchor = Anchor.BottomLeft,
                    Origin = Anchor.Centre,
                    Size = new Vector2(7),
                    Colour = Color4Extensions.FromHex("205ac8"),
                },new Container
                {
                    RelativeSizeAxes = Axes.Both,
                    Anchor = Anchor.BottomLeft,
                    Origin = Anchor.Centre,
                    Size = new Vector2(3),
                    Child = new SpriteText
                    {
                        Text = "Back",
                        Anchor = Anchor.TopRight,
                        Origin = Anchor.Centre,
                        Font = new FontUsage(size: 50)
                    }
                }
            };
        }

        protected override void PopIn()
        {
            this.FadeIn(150, Easing.OutQuint);
        }

        protected override void PopOut()
        {
            this.FadeOut(400, Easing.OutQuint);
        }
    }
}
