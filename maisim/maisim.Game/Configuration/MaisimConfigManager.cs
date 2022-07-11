using osu.Framework.Configuration;
using osu.Framework.Platform;
using osu.Framework.Testing;

namespace maisim.Game.Configuration
{
    [ExcludeFromDynamicCompile]
    public class MaisimConfigManager : IniConfigManager<MaisimSetting>
    {
        public MaisimConfigManager(Storage storage) : base(storage)
        {

        }

        protected override void InitialiseDefaults()
        {
            // UI
            SetDefault(MaisimSetting.MenuParallax, true);

            // Graphics
            SetDefault(MaisimSetting.ShowFpsDisplay, false);
        }
    }

    public enum MaisimSetting
    {
        MenuParallax,

        ShowFpsDisplay
    }
}
