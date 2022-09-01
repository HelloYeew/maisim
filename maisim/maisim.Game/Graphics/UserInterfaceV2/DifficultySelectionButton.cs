using maisim.Game.Beatmaps;
using maisim.Game.Graphics.Sprites;
using maisim.Game.Graphics.UserInterface;
using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Input.Events;

namespace maisim.Game.Graphics.UserInterfaceV2
{
    /// <summary>
    /// A button that's use to select <see cref="DifficultyLevel"/> in <see cref="BeatmapSetInfoBox"/>
    /// </summary>
    public class DifficultySelectionButton : Button
    {
        private DifficultyLevel difficultyLevel;
        private Container mainContainer;
        private Box backgroundBox;

        public DifficultySelectionButton(DifficultyLevel difficultyLevel)
        {
            this.difficultyLevel = difficultyLevel;
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            RelativeSizeAxes = Axes.Both;
            Padding = new MarginPadding(10);
            Child = mainContainer = new Container()
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                RelativeSizeAxes = Axes.Both,
                Masking = true,
                BorderThickness = 5,
                BorderColour = Colour4.White,
                CornerRadius = 10,
                Children = new Drawable[]
                {
                    backgroundBox = new Box()
                    {
                        RelativeSizeAxes = Axes.Both,
                        Colour = MaisimColour.GetDifficultyColor(difficultyLevel)
                    },
                    new MaisimSpriteText()
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Text = difficultyLevel.ToString()
                    },
                    // TODO: Change hover effect to make it different from other button
                    new ClickHoverSounds()
                }
            };
        }

        protected override bool OnHover(HoverEvent e)
        {
            backgroundBox.FadeColour(MaisimColour.GetDifficultyColor(difficultyLevel).Darken(0.25f), 100);
            return base.OnHover(e);
        }

        protected override void OnHoverLost(HoverLostEvent e)
        {
            backgroundBox.Colour = MaisimColour.GetDifficultyColor(difficultyLevel);
            base.OnHoverLost(e);
        }

        protected override bool OnMouseDown(MouseDownEvent e)
        {
            backgroundBox.FadeColour(MaisimColour.GetDifficultyColor(difficultyLevel).Darken(0.5f), 100);
            mainContainer.ScaleTo(0.9f, 100, Easing.OutQuint);
            return base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseUpEvent e)
        {
            backgroundBox.FadeColour(MaisimColour.GetDifficultyColor(difficultyLevel), 100);
            mainContainer.ScaleTo(1, 500, Easing.OutElastic);
            base.OnMouseUp(e);
        }
    }
}
