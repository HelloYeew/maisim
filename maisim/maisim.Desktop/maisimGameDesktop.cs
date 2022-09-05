using maisim.Game;
using osu.Framework.Development;
using osu.Framework.Platform;

namespace maisim.Desktop
{
    public class maisimGameDesktop : maisimGame
    {
        public override void SetHost(GameHost host)
        {
            base.SetHost(host);
            var desktopWindow = (SDL2DesktopWindow)host.Window;

            desktopWindow.Title = "maisim";
            if (DebugUtils.IsDebugBuild)
            {
                desktopWindow.Title += " development";
            }
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();

            LoadComponentAsync(new DiscordRichPresence(), Add);
        }
    }
}
