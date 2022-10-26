using maisim.Game.Users;
using maisim.Game.Users.Activity;
using osu.Framework.Allocation;
using osu.Framework.Screens;

namespace maisim.Game.Screen
{
    public abstract class MaisimScreen : osu.Framework.Screens.Screen, IMaisimScreen
    {
        [Resolved]
        private User user { get; set; }

        public virtual float BackgroundParallaxAmount => 1;

        public virtual IUserActivity InitialUserActivity => new Idle();

        public override void OnEntering(ScreenTransitionEvent e)
        {
            user.Activity.Value = InitialUserActivity;
        }

        public override void OnResuming(ScreenTransitionEvent e)
        {
            user.Activity.Value = InitialUserActivity;
        }
    }
}
