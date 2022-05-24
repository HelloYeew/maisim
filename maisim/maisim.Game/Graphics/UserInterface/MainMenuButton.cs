using maisim.Game.Graphics;
using maisim.Game.Graphics.Sprites;
using osu.Framework.Allocation;
using osu.Framework.Audio.Sample;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Audio;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Input.Events;
using osuTK;
using osuTK.Graphics;

namespace maisim.Game.Component
{
    /// <summary>
    /// A button used on the main menu screen.
    /// </summary>
    public class MainMenuButton : Button
    {
        private DrawableSample drawableHoverSample;
        private DrawableSample drawableClickSample;
        private readonly string buttonText;
        private readonly IconUsage buttonIcon;
        private Color4 buttonColor;

        public MainMenuButton(string buttonText, IconUsage buttonIcon, Color4 buttonColor)
        {
            this.buttonText = buttonText;
            this.buttonIcon = buttonIcon;
            this.buttonColor = buttonColor;
        }

        [BackgroundDependencyLoader]
        private void load(ISampleStore sampleStore)
        {
            InternalChild = new Container()
            {
                new Box()
                {
                    Anchor = Anchor.CentreRight,
                    Origin = Anchor.CentreRight,
                    RelativeSizeAxes = Axes.Both,
                    Colour = buttonColor
                }
            };

            drawableHoverSample = new DrawableSample(sampleStore.Get("hover.wav"));
            drawableClickSample = new DrawableSample(sampleStore.Get("click.wav"));
        }

        protected override bool OnHover(HoverEvent e)
        {
            drawableHoverSample.Play();
            return base.OnHover(e);
        }

        protected override bool OnClick(ClickEvent e)
        {
            drawableClickSample.Play();
            return base.OnClick(e);
        }
    }
}
