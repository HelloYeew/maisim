using maisim.Game.Users.Activity;
using osu.Framework.Bindables;

namespace maisim.Game.Users
{
    public class User
    {
        public Bindable<IUserActivity> Activity { get; } = new Bindable<IUserActivity>(new InMainMenu());
    }
}
