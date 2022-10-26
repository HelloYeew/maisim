using maisim.Game.Users;
using osu.Framework.Screens;

namespace maisim.Game.Screen
{
    /// <summary>
    /// Interface for screens that are used in the game.
    /// </summary>
    public interface IMaisimScreen : IScreen
    {
        float BackgroundParallaxAmount { get; }

        IUserActivity InitialUserActivity { get; }
    }
}
