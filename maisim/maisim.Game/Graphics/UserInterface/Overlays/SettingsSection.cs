using System.Collections.Generic;
using System.Linq;
using maisim.Game.Graphics.Sprites;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Localisation;
using osuTK;
using osuTK.Graphics;

namespace maisim.Game.Graphics.UserInterface.Overlays
{
    public abstract class SettingsSection : Container, IHasFilterableChildren
    {
        protected FillFlowContainer FlowContent;
        protected override Container<Drawable> Content => FlowContent;

        private IBindable<SettingsSection> selectedSection;

        public abstract LocalisableString Header { get; }

        public IEnumerable<IFilterable> FilterableChildren => Children.OfType<IFilterable>();
        public virtual IEnumerable<LocalisableString> FilterTerms => new[] {Header};

        public const int ITEM_SPACING = 14;

        private const int header_size = 24;
        private const int border_size = 4;

        private const float inactive_alpha = 0.8f;

        private bool matchingFilter = true;

        [Resolved(canBeNull: true)] private SettingsPanel settingsPanel { get; set; }

        protected SettingsSection()
        {
            AutoSizeAxes = Axes.Y;
            RelativeSizeAxes = Axes.X;

            FlowContent = new FillFlowContainer()
            {
                Margin = new MarginPadding
                {
                    Top = 36
                },
                Spacing = new Vector2(0, ITEM_SPACING),
                Direction = FillDirection.Vertical,
                AutoSizeAxes = Axes.Y,
                RelativeSizeAxes = Axes.X
            };
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            AddRangeInternal(new Drawable[]
            {
                new Box
                {
                    Name = "separator",
                    Colour = Colour4.Aquamarine,
                    RelativeSizeAxes = Axes.X,
                    Height = border_size,
                },
                new Container
                {
                    Padding = new MarginPadding {Top = border_size},
                    RelativeSizeAxes = Axes.X,
                    AutoSizeAxes = Axes.Y,
                    Children = new Drawable[]
                    {
                        new Container
                        {
                            RelativeSizeAxes = Axes.X,
                            AutoSizeAxes = Axes.Y,
                            Padding = new MarginPadding
                            {
                                Top = 24,
                                Bottom = 40,
                            },
                            Children = new Drawable[]
                            {
                                new MaisimSpriteText
                                {
                                    Font = MaisimFont.GetFont(size: header_size),
                                    Text = Header,
                                    Colour = Color4.White,
                                    Margin = new MarginPadding
                                    {
                                        Horizontal = SettingsPanel.CONTENT_MARGINS
                                    }
                                },
                                FlowContent
                            }
                        },
                    }
                },
            });
        }

        public bool MatchingFilter
        {
            get => matchingFilter;
            set
            {
                bool wasPresent = IsPresent;

                matchingFilter = value;

                if (IsPresent != wasPresent)
                    Invalidate(Invalidation.Presence);
            }
        }

        public bool FilteringActive { get; set; }

        private bool isCurrentSection => selectedSection.Value == this;
    }
}
