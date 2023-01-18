using System;
using maisim.Game.Configuration;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Input;
using osu.Framework.Utils;
using osuTK;

namespace maisim.Game.Graphics.Containers
{
    public partial class ParallaxContainer : Container, IRequireHighFrequencyMousePosition
    {
        public const float DEFAULT_PARALLAX_AMOUNT = 0.02f;

        /// <summary>
        /// The amount of parallax to apply to the container. If set to negative, the parallellax will be reversed from the direction of the mouse.
        /// </summary>
        public float ParallaxAmount = DEFAULT_PARALLAX_AMOUNT;

        private const float parallax_duration = 100;

        private readonly Container content;
        private InputManager input;
        private Bindable<bool> parallaxEnabled;
        private bool firstUpdate = true;

        public ParallaxContainer()
        {
            RelativeSizeAxes = Axes.Both;
            AddInternal(content = new Container
            {
                RelativeSizeAxes = Axes.Both,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre
            });
        }

        protected override Container<Drawable> Content => content;

        [BackgroundDependencyLoader]
        private void load(MaisimConfigManager config)
        {
            parallaxEnabled = config.GetBindable<bool>(MaisimSetting.MenuParallax);
            parallaxEnabled.ValueChanged += delegate
            {
                if (!parallaxEnabled.Value)
                {
                    content.MoveTo(Vector2.Zero, firstUpdate ? 0 : 1000, Easing.OutQuint);
                    content.Scale = new Vector2(1 + Math.Abs(ParallaxAmount));
                }
            };
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();
            input = GetContainingInputManager();
        }

        protected override void Update()
        {
            base.Update();

            if (parallaxEnabled.Value)
            {
                Vector2 offset = Vector2.Zero;

                if (input.CurrentState.Mouse != null)
                {
                    var sizeDiv2 = DrawSize / 2;

                    Vector2 relativeAmount = ToLocalSpace(input.CurrentState.Mouse.Position) - sizeDiv2;

                    const float base_factor = 0.999f;

                    relativeAmount.X = (float)(Math.Sign(relativeAmount.X) * Interpolation.Damp(0, 1, base_factor, Math.Abs(relativeAmount.X)));
                    relativeAmount.Y = (float)(Math.Sign(relativeAmount.Y) * Interpolation.Damp(0, 1, base_factor, Math.Abs(relativeAmount.Y)));

                    offset = relativeAmount * sizeDiv2 * ParallaxAmount;
                }

                double elapsed = Math.Clamp(Clock.ElapsedFrameTime, 0, parallax_duration);

                content.Position = Interpolation.ValueAt(elapsed, content.Position, offset, 0, parallax_duration, Easing.OutQuint);
                content.Scale = Interpolation.ValueAt(elapsed, content.Scale, new Vector2(1 + Math.Abs(ParallaxAmount)), 0, 1000, Easing.OutQuint);
            }

            firstUpdate = false;
        }
    }
}
