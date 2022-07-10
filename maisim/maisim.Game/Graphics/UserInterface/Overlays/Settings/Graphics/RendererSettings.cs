using maisim.Game.Configuration;
using maisim.Game.Graphics.Sprites;
using osu.Framework.Allocation;
using osu.Framework.Configuration;
using osu.Framework.Graphics;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Localisation;

namespace maisim.Game.Graphics.UserInterface.Overlays.Settings.Graphics
{
    public class RendererSettings : SettingsSubsection
    {
        protected override LocalisableString Header => "renderer";

        [BackgroundDependencyLoader]
        private void load(FrameworkConfigManager config, MaisimConfigManager gameConfig)
        {
            Children = new Drawable[]
            {
                // TODO: Add renderer and threading settings
                new MaisimSpriteText
                {
                    Text = "Show FPS",
                    Font = MaisimFont.Comfortaa.With(size: 22)
                },
                new BasicCheckbox
                {
                    Current = gameConfig.GetBindable<bool>(MaisimSetting.ShowFpsDisplay)
                }
            };
        }
    }
}
