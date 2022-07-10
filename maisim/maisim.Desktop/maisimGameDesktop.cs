using maisim.Game;
using osu.Framework.Platform;

namespace maisim.Desktop
{
    public class maisimGameDesktop : maisimGame
    {
        protected override void LoadComplete()
        {
            base.LoadComplete();

            LoadComponentAsync(new DiscordRichPresence(), Add);
        }
    }
}
