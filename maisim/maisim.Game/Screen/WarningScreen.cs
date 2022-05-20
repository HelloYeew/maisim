using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Screens;
using osuTK;
using osuTK.Graphics;

namespace maisim.Game.Screen
{
    public class WarningScreen : osu.Framework.Screens.Screen
    {
        private SpriteIcon warningSprite;

        private readonly osu.Framework.Screens.Screen nextScreen;

        private readonly float icon_y = -100f;

        public WarningScreen(osu.Framework.Screens.Screen nextScreen)
        {
            this.nextScreen = nextScreen;
            ValidForResume = false;
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            InternalChildren = new Drawable[]
            {
                new Container()
                {
                    Colour = Color4Extensions.FromHex("73bfe9"),
                    RelativeSizeAxes = Axes.Both,
                    Alpha = 0.5f,
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Scale = new Vector2(1.5f),
                },
                warningSprite = new SpriteIcon
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Icon = FontAwesome.Solid.ExclamationTriangle,
                    Size = new Vector2(40),
                    Y = icon_y,
                    Colour = Color4.Yellow
                },
                new SpriteText()
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Text = "Warning :",
                    Font = new FontUsage(size: 30),
                    Y = -40f,
                    Colour = Color4Extensions.FromHex("ffff7d")
                },
                new SpriteText()
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Text = "This project is under a heavy development process.",
                    Font = new FontUsage(size: 30),
                },
                new SpriteText()
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Text = "If something goes wrong, please make an issue on the repository.",
                    Font = new FontUsage(size: 30),
                    Y = 40f
                },
                new SpriteText()
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Text = "- HelloYeew",
                    Font = new FontUsage(size: 30),
                    Y = 80f
                },
            };
        }

        protected override void LoadComplete()
        {
            if (nextScreen != null)
                LoadComponentAsync(nextScreen);
        }

        public override void OnEntering(ScreenTransitionEvent e)
        {
            base.OnEntering(e);

            warningSprite.FlashColour(Color4Extensions.FromHex("ffffed"), 500, Easing.OutQuint).Loop();

            this.FadeInFromZero(500)
                .Then(3000)
                .FadeOut(250)
                .MoveToY(-200, 250, Easing.OutQuint)
                .Finally(next =>
                {
                    if (nextScreen != null)
                        this.Push(nextScreen);
                });
        }
    }
}
