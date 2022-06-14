using maisim.Game.Graphics.Containers;
using maisim.Game.Graphics.Sprites;
using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Extensions.EnumExtensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Effects;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Input.Events;
using osu.Framework.Localisation;
using osuTK;
using osuTK.Graphics;

namespace maisim.Game.Graphics.UserInterface.Toolbar
{
    public class ToolbarButton : ClickableContainer
    {
        protected virtual Anchor TooltipAnchor => Anchor.TopLeft;
        private readonly Box hoverBackground;
        private readonly Box flashBackground;
        private readonly FillFlowContainer flow;
        private readonly ConstrainedIconContainer IconContainer;
        private readonly MaisimSpriteText DrawableText;
        private readonly FillFlowContainer tooltipContainer;
        private readonly MaisimSpriteText tooltip1;
        private readonly MaisimSpriteText tooltip2;
        private readonly Container BackgroundContainer;

        [Resolved]
        private TextureStore textures { get; set; }

        public ToolbarButton()
        {
            Width = Toolbar.HEIGHT;
            RelativeSizeAxes = Axes.Y;
            Children = new Drawable[]
            {
                hoverBackground = new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    Colour = Toolbar.toolbarColour.Opacity(180),
                    Blending = BlendingParameters.Additive,
                    Alpha = 0,
                },
                flashBackground = new Box()
                {
                    RelativeSizeAxes = Axes.Both,
                    Alpha = 0,
                    Colour = Color4.White.Opacity(100)
                },
                flow = new FillFlowContainer()
                {
                    Direction = FillDirection.Horizontal,
                    Spacing = new Vector2(5),
                    Anchor = Anchor.TopCentre,
                    Origin = Anchor.TopCentre,
                    Padding = new MarginPadding { Left = Toolbar.HEIGHT / 2, Right = Toolbar.HEIGHT / 2 },
                    RelativeSizeAxes = Axes.Y,
                    AutoSizeAxes = Axes.X,
                    Children = new Drawable[]
                    {
                        IconContainer = new ConstrainedIconContainer
                        {
                            Anchor = Anchor.CentreLeft,
                            Origin = Anchor.CentreLeft,
                            Size = new Vector2(26),
                            Alpha = 0
                        },
                        DrawableText = new MaisimSpriteText
                        {
                            Anchor = Anchor.CentreLeft,
                            Origin = Anchor.CentreLeft,
                        },
                    },
                },
                tooltipContainer = new FillFlowContainer
                {
                    Direction = FillDirection.Vertical,
                    RelativeSizeAxes = Axes.Both, // stops us being considered in parent's autosize
                    Anchor = TooltipAnchor.HasFlagFast(Anchor.x0) ? Anchor.BottomLeft : Anchor.BottomRight,
                    Origin = TooltipAnchor,
                    Position = new Vector2(TooltipAnchor.HasFlagFast(Anchor.x0) ? 5 : -5, 5),
                    Alpha = 0,
                    Children = new Drawable[]
                    {
                        tooltip1 = new MaisimSpriteText()
                        {
                            Anchor = TooltipAnchor,
                            Origin = TooltipAnchor,
                            Shadow = true,
                            Font = MaisimFont.GetFont(size:30),
                        },
                        new FillFlowContainer
                        {
                            AutoSizeAxes = Axes.Both,
                            Anchor = TooltipAnchor,
                            Origin = TooltipAnchor,
                            Direction = FillDirection.Horizontal,
                            Child = tooltip2 = new MaisimSpriteText
                            {
                                Font = MaisimFont.GetFont(size:20),
                            }
                        }
                    }
                },
                new ClickHoverSounds()
            };
        }

        public void SetIcon(Drawable icon)
        {
            IconContainer.Icon = icon;
            IconContainer.Show();
        }

        public void SetIcon(string textureName)
        {
            SetIcon(new Sprite
            {
                Texture = textures.Get(textureName),
            });
        }

        public LocalisableString Text
        {
            get => DrawableText.Text;
            set => DrawableText.Text = value;
        }

        public LocalisableString TooltipMainText
        {
            get => tooltip1.Text;
            set => tooltip1.Text = value;
        }

        public LocalisableString TooltipSubText
        {
            get => tooltip2.Text;
            set => tooltip2.Text = value;
        }

        protected override bool OnMouseDown(MouseDownEvent e) => true;

        protected override bool OnClick(ClickEvent e)
        {
            flashBackground.FadeOutFromOne(800, Easing.OutQuint);
            tooltipContainer.FadeOut(100);
            return base.OnClick(e);
        }

        protected override bool OnHover(HoverEvent e)
        {
            hoverBackground.FadeIn(200);
            tooltipContainer.FadeIn(100);

            return base.OnHover(e);
        }

        protected override void OnHoverLost(HoverLostEvent e)
        {
            hoverBackground.FadeOut(200);
            tooltipContainer.FadeOut(100);
        }
    }

    public class OpaqueBackground : Container
    {
        public OpaqueBackground()
        {
            RelativeSizeAxes = Axes.Both;
            Masking = true;
            MaskingSmoothness = 0;
            EdgeEffect = new EdgeEffectParameters
            {
                Type = EdgeEffectType.Shadow,
                Colour = Color4.Black.Opacity(40),
                Radius = 5,
            };

            Children = new Drawable[]
            {
                new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    Colour = Toolbar.toolbarColour
                },
            };
        }
    }
}
