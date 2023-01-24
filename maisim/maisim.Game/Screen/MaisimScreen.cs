namespace maisim.Game.Screen
{
    public abstract partial class MaisimScreen : osu.Framework.Screens.Screen, IMaisimScreen
    {
        public virtual float BackgroundParallaxAmount => 1;
    }
}
