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
    public abstract class SettingsSection : Container
    {
        protected FillFlowContainer FlowContent;
        protected override Container<Drawable> Content => FlowContent;

        private IBindable<SettingsSection> selectedSection;

        public abstract bool EnableSeperator { get; }

        public abstract LocalisableString Header { get; }

        public const int ITEM_SPACING = 14;

        private const int header_size = 30;
        private const int border_size = 4;

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
            if (EnableSeperator)
            {
                AddRangeInternal(new Drawable[]
                {
                    new Box
                    {
                        Name = "separator",
                        Colour = Colour4.Aquamarine,
                        RelativeSizeAxes = Axes.X,
                        Height = border_size,
                    }
                });
            }

            AddRangeInternal(new Drawable[]
            {
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
    }
}
