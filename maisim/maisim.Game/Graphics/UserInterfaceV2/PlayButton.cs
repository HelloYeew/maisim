using maisim.Game.Beatmaps;
using maisim.Game.Graphics.Sprites;
using maisim.Game.Graphics.UserInterface;
using maisim.Game.Graphics.UserInterface.Overlays;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Input.Events;
using osuTK;
using osuTK.Input;

namespace maisim.Game.Graphics.UserInterfaceV2
{
    /// <summary>
    /// A button used on the main menu screen.
    /// </summary>
    public class PlayButton : Button
    {
        [Resolved]
        private CurrentWorkingBeatmap currentWorkingBeatmap { get; set; }

        private readonly Box buttonBox;
        private Colour4 difficultyColour => MaisimColour.GetDifficultyColor(currentWorkingBeatmap.DifficultyLevel);

        private void onDifficultyLevelChange(ValueChangedEvent<DifficultyLevel> difficultyChangedEvent) =>
            buttonBox.FadeColour(MaisimColour.GetDifficultyColor(difficultyChangedEvent.NewValue), BeatmapCard.FADE_COLOR_DURATION);

        public PlayButton()
        {
            InternalChild = new Container
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Size = new Vector2(300, 80),
                Masking = true,
                CornerRadius = 40,
                Children = new Drawable[]
                {
                    buttonBox = new Box
                    {
                        RelativeSizeAxes = Axes.Both,
                        Anchor = Anchor.CentreRight,
                        Origin = Anchor.CentreRight,
                    },
                    new GridContainer
                    {
                        RelativeSizeAxes = Axes.Both,
                        ColumnDimensions = new[]
                        {
                            new Dimension(GridSizeMode.Absolute, 100),
                            new Dimension(GridSizeMode.Absolute, 400)
                        },
                        Content = new[]
                        {
                            new Drawable[]
                            {
                                new Container
                                {
                                    Anchor = Anchor.CentreLeft,
                                    Origin = Anchor.CentreLeft,
                                    Size = new Vector2(100, 70),
                                    Children = new Drawable[]
                                    {
                                        new SpriteIcon
                                        {
                                            Anchor = Anchor.Centre,
                                            Origin = Anchor.Centre,
                                            Icon = FontAwesome.Solid.ArrowRight,
                                            Size = new Vector2(30),
                                            Colour = Color4Extensions.FromHex("ffffff")
                                        }
                                    }
                                },
                                new Container
                                {
                                    Anchor = Anchor.CentreLeft,
                                    Origin = Anchor.CentreLeft,
                                    Size = new Vector2(400, 70),
                                    Child = new MaisimSpriteText()
                                    {
                                        Anchor = Anchor.CentreLeft,
                                        Origin = Anchor.CentreLeft,
                                        Text = "let's go !",
                                        Font = MaisimFont.GetFont(size: 45f)
                                    }
                                }
                            }
                        }
                    },
                    new ClickHoverSounds()
                }
            };
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            buttonBox.Colour = difficultyColour;
            currentWorkingBeatmap.BindDifficultyLevelChanged(onDifficultyLevelChange);
        }

        protected override bool OnHover(HoverEvent e)
        {
            buttonBox.Colour = difficultyColour.Darken(0.25f);
            return base.OnHover(e);
        }

        protected override void OnHoverLost(HoverLostEvent e)
        {
            buttonBox.Colour = difficultyColour;
            base.OnHoverLost(e);
        }

        protected override bool OnMouseDown(MouseDownEvent e)
        {
            if (e.Button == MouseButton.Left)
            {
                buttonBox.FadeColour(difficultyColour.Darken(0.5f), 100);
                this.ScaleTo(0.92f, 500, Easing.OutElastic);
            }
            return base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseUpEvent e)
        {
            if (e.Button == MouseButton.Left)
            {
                buttonBox.FadeColour(difficultyColour, 100);
                this.ScaleTo(1, 500, Easing.OutElastic);
            }
            base.OnMouseUp(e);
        }
    }
}
