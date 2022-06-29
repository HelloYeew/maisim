using osu.Framework.Bindables;

namespace maisim.Game.Screen
{
    public class MaisimScreen : osu.Framework.Screens.Screen, IMaisimScreen
    {
        public virtual float BackgroundParallaxAmount => 1;
    }
}
