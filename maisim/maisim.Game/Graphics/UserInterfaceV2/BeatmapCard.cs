using maisim.Game.Beatmaps;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osuTK;

namespace maisim.Game.Graphics.UserInterfaceV2
{
    public class BeatmapCard : CompositeDrawable
    {
        private Bindable<DifficultyLevel> bindableDifficultyLevel;

        private Box backgroundBox;

        public BeatmapCard(Bindable<DifficultyLevel> bindableDifficultyLevel)
        {
            this.bindableDifficultyLevel = bindableDifficultyLevel;
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            RelativeSizeAxes = Axes.X;
            Size = new Vector2(1, 170);
            InternalChildren = new Drawable[]
            {
                new Container()
                {
                    Anchor = Anchor.TopRight,
                    Origin = Anchor.TopRight,
                    RelativeSizeAxes = Axes.Both,
                    Padding = new MarginPadding(10),
                    Child = new Container()
                    {
                        RelativeSizeAxes = Axes.Both,
                        CornerRadius = 10,
                        Masking = true,
                        Child = backgroundBox = new Box()
                        {
                            Anchor = Anchor.TopRight,
                            Origin = Anchor.TopRight,
                            RelativeSizeAxes = Axes.Both,
                            Colour = MaisimColour.GetDifficultyColor(bindableDifficultyLevel.Value)
                        }
                    }
                }
            };
        }

        protected override void Update()
        {
            base.Update();

            backgroundBox.Colour = MaisimColour.GetDifficultyColor(bindableDifficultyLevel.Value);
        }
    }
}
