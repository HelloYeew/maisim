using maisim.Game.Configuration;
using maisim.Game.Graphics.Sprites;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Localisation;

namespace maisim.Game.Graphics.UserInterface.Overlays.Settings.UserInterface
{
    public class GeneralSection : SettingsSubsection
    {
        protected override LocalisableString Header => "general";

        [BackgroundDependencyLoader]
        private void load(MaisimConfigManager gameConfig)
        {
            Children = new Drawable[]
            {
                new MaisimSpriteText
                {
                    Text = "Menu Parallax",
                    Font = MaisimFont.Comfortaa.With(size: 22)
                },
                new BasicCheckbox
                {
                    Current = gameConfig.GetBindable<bool>(MaisimSetting.MenuParallax)
                }
            };
        }
    }
}
