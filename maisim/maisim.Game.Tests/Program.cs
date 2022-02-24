using osu.Framework;
using osu.Framework.Platform;

namespace maisim.Game.Tests
{
    public static class Program
    {
        public static void Main()
        {
            using (GameHost host = Host.GetSuitableDesktopHost("maisim-test", new HostOptions { BindIPC = true }))
            using (var game = new maisimTestBrowser())
                host.Run(game);
        }
    }
}
