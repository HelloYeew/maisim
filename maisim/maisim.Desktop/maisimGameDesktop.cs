using maisim.Game;

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
