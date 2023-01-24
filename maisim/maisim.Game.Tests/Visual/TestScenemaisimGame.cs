using osu.Framework.Allocation;
using osu.Framework.Platform;

namespace maisim.Game.Tests.Visual
{
    public partial class TestScenemaisimGame : maisimTestScene
    {
        // Add visual tests to ensure correct behaviour of your game: https://github.com/ppy/osu-framework/wiki/Development-and-Testing
        // You can make changes to classes associated with the tests and they will recompile and update immediately.

        private maisimGame game;

        [BackgroundDependencyLoader]
        private void load(GameHost host)
        {
            game = new maisimGame();
            game.SetHost(host);

            AddGame(game);
        }
    }
}
