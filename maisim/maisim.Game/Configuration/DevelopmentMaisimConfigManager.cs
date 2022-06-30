using osu.Framework.Platform;

namespace maisim.Game.Configuration
{
    public class DevelopmentMaisimConfigManager : MaisimConfigManager
    {
        protected override string Filename => base.Filename.Replace(".ini", ".dev.ini");

        public DevelopmentMaisimConfigManager(Storage storage)
            : base(storage)
        {

        }
    }
}
