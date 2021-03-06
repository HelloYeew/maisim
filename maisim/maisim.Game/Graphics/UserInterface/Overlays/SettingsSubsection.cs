using System.Collections.Generic;
using System.Linq;
using maisim.Game.Graphics.Sprites;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Localisation;
using osuTK;

namespace maisim.Game.Graphics.UserInterface.Overlays
{
    public abstract class SettingsSubsection : FillFlowContainer, IHasFilterableChildren
    {
        protected override Container<Drawable> Content => FlowContent;

        protected readonly FillFlowContainer FlowContent;

        protected abstract LocalisableString Header { get; }

        public IEnumerable<IFilterable> FilterableChildren => Children.OfType<IFilterable>();


        public virtual IEnumerable<LocalisableString> FilterTerms => new[] { Header };

        public bool MatchingFilter
        {
            set => this.FadeTo(value ? 1 : 0);
        }

        public bool FilteringActive { get; set; }

        protected SettingsSubsection()
        {
            RelativeSizeAxes = Axes.X;
            AutoSizeAxes = Axes.Y;
            Direction = FillDirection.Vertical;

            FlowContent = new FillFlowContainer
            {
                Margin = new MarginPadding { Top = SettingsSection.ITEM_SPACING },
                Direction = FillDirection.Vertical,
                Spacing = new Vector2(0, SettingsSection.ITEM_SPACING),
                RelativeSizeAxes = Axes.X,
                AutoSizeAxes = Axes.Y,
            };
        }

        protected const float SECTION_WIDTH = SettingsPanel.WIDTH - (SettingsPanel.CONTENT_MARGINS * 2);
        private const int header_height = 43;
        private const int header_font_size = 25;

        [BackgroundDependencyLoader]
        private void load()
        {
            AddRangeInternal(new Drawable[]
            {
                new MaisimSpriteText
                {
                    Text = Header,
                    Font = MaisimFont.GetFont(size: header_font_size),
                },
                FlowContent
            });

            Margin = new MarginPadding
            {
                Vertical = (header_height - header_font_size) * 0.5f,
                Horizontal = SettingsPanel.CONTENT_MARGINS
            };
        }
    }
}
