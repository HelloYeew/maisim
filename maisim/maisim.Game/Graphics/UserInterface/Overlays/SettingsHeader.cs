using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Localisation;
using osuTK.Graphics;

namespace maisim.Game.Graphics.UserInterface.Overlays
{
    public class SettingsHeader : SettingsSection
    {
        private readonly LocalisableString heading;
        private readonly LocalisableString subheading;

        public SettingsHeader(LocalisableString heading, LocalisableString subheading)
        {
            this.heading = heading;
            this.subheading = subheading;
        }

        public override bool EnableSeperator => false;

        public override LocalisableString Header => "";

        [BackgroundDependencyLoader]
        private void load()
        {
            RelativeSizeAxes = Axes.X;
            AutoSizeAxes = Axes.Y;
            Margin = new MarginPadding
            {
                Horizontal = SettingsPanel.CONTENT_MARGINS
            };
            Children = new Drawable[]
            {
                new TextFlowContainer
                {
                    AutoSizeAxes = Axes.Y,
                    RelativeSizeAxes = Axes.X,
                }.With(flow =>
                {
                    flow.AddText(heading, header =>
                    {
                        header.Colour = Color4.White;
                        header.Font = MaisimFont.GetFont(size:40);
                    });
                    flow.NewLine();
                    flow.AddText(subheading, subheader =>
                    {
                        subheader.Colour = Color4.White;
                        subheader.Font = MaisimFont.GetFont(size:18);
                    });
                })
            };
        }
    }
}
