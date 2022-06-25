
using System.Collections.Generic;
using osu.Framework.Allocation;
using osu.Framework.Extensions.IEnumerableExtensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Primitives;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.UserInterface;
using osuTK;
using osuTK.Graphics;

namespace maisim.Game.Graphics.UserInterface.Overlays
{
    public class SettingsPanel : MaisimFocusedOverlayContainer
    {
        public const float CONTENT_MARGINS = 20;

        public const float TRANSITION_LENGTH = 600;

        public const float WIDTH = 400;

        protected Container<Drawable> ContentContainer;
        private FillFlowContainer scrollContainer;

        protected virtual float ExpandedPosition => 0;

        protected virtual IEnumerable<SettingsSection> CreateSections() => null;

        protected virtual Drawable CreateHeader() => new Container();

        protected virtual Drawable CreateFooter() => new Container();

        public SettingsPanel()
        {
            RelativeSizeAxes = Axes.Y;
            AutoSizeAxes = Axes.X;
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            InternalChild = ContentContainer = new NonMaskedContent
            {
                X = -WIDTH + ExpandedPosition,
                Width = WIDTH,
                RelativeSizeAxes = Axes.Y,
                Children = new Drawable[]
                {
                    new Box
                    {
                        Anchor = Anchor.TopRight,
                        Origin = Anchor.TopRight,
                        Scale = new Vector2(2, 1), // over-extend to the left for transitions
                        RelativeSizeAxes = Axes.Both,
                        Colour = MaisimColour.Gray(0.2f),
                        Alpha = 1
                    }
                }
            };

            Add(scrollContainer = new FillFlowContainer()
            {
                Masking = true,
                RelativeSizeAxes = Axes.Both,
            });

            CreateSections()?.ForEach(scrollContainer.Add);
        }

        protected override void PopIn()
        {
            base.PopIn();

            ContentContainer.MoveToX(ExpandedPosition, TRANSITION_LENGTH, Easing.OutQuint);

            this.FadeTo(1, TRANSITION_LENGTH, Easing.OutQuint);
        }

        protected override void PopOut()
        {
            base.PopOut();

            ContentContainer.MoveToX(-WIDTH, TRANSITION_LENGTH, Easing.OutQuint);

            this.FadeTo(0, TRANSITION_LENGTH, Easing.OutQuint);
        }

        private class NonMaskedContent : Container<Drawable>
        {
            // masking breaks the pan-out transform with nested sub-settings panels.
            protected override bool ComputeIsMaskedAway(RectangleF maskingBounds) => false;
        }
    }
}
