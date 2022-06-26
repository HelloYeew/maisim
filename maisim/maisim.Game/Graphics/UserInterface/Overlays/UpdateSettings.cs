using maisim.Game.Graphics.Sprites;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Localisation;
using osu.Framework.Platform;
using osuTK;

namespace maisim.Game.Graphics.UserInterface.Overlays
{
    public class UpdateSettings : SettingsSubsection
    {
        protected override LocalisableString Header => "logs";

        [BackgroundDependencyLoader]
        private void load(Storage storage)
        {
            Children = new Drawable[]
            {
                new MaisimSpriteText()
                {
                    Text = "folder",
                },
                new MaisimSpriteText()
                {
                    Text = "logs location : " + storage.GetFullPath(@"logs"),
                    Font = MaisimFont.Comfortaa.With(size: 20),
                },
                new MaisimButton
                {
                    Text = "open maisim folder",
                    Action = () => storage.PresentExternally(),
                    Size = new Vector2(SettingsPanel.WIDTH, 40),
                }
            };
        }
    }
}
