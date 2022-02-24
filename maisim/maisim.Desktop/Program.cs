using osu.Framework.Platform;
using osu.Framework;
using maisim.Game;

namespace maisim.Desktop
{
    public static class Program
    {
        public static void Main()
        {
            using (GameHost host = Host.GetSuitableDesktopHost("maisim", new HostOptions { BindIPC = true }))
            using (osu.Framework.Game game = new maisimGame())
                host.Run(new maisimGameDesktop());
        }
    }
}
