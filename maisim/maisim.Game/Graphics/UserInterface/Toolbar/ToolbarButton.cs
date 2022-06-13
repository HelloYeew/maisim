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
using osuTK;
using osuTK.Graphics;

namespace maisim.Game.Graphics.UserInterface.Toolbar
{
    public class ToolbarButton : ClickableContainer
    {
        protected virtual Anchor TooltipAnchor => Anchor.TopLeft;
        private readonly Box HoverBackground;
        private readonly Box flashBackground;
        private readonly FillFlowContainer Flow;
        private readonly Container IconContainer;
        private readonly MaisimSpriteText DrawableText;
        private readonly FillFlowContainer tooltipContainer;
        private readonly MaisimSpriteText tooltip2;
        private readonly MaisimSpriteText keyBindingTooltip;
        private readonly MaisimSpriteText tooltip1;

        [Resolved]
        private TextureStore textures { get; set; }

        public ToolbarButton()
        {
            Width = Toolbar.HEIGHT;
            RelativeSizeAxes = Axes.Y;
            Children = new Drawable[]
            {
                HoverBackground = new Box
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
                Flow = new FillFlowContainer()
                {
                    Direction = FillDirection.Horizontal,
                    Spacing = new Vector2(5),
                    Anchor = Anchor.TopCentre,
                    Origin = Anchor.TopCentre,
                    Padding = new MarginPadding { Left = Toolbar.HEIGHT / 2, Right = Toolbar.HEIGHT / 2 },
                    RelativeSizeAxes = Axes.Y,
                    AutoSizeAxes = Axes.X,
                    Child = IconContainer = new Container() {
                        Anchor = Anchor.CentreLeft,
                        Origin = Anchor.CentreLeft,
                        Size = new Vector2(26),
                        Child = new Container()
                        {
                            Size = new Vector2(26),
                            Children = new Drawable[]
                            {
                                new Circle()
                                {
                                    Size = new Vector2(Toolbar.HEIGHT - 5),
                                    Anchor = Anchor.Centre,
                                    Origin = Anchor.Centre,
                                    Colour = Color4.Yellow,  // TODO: Make color provider class
                                },
                                new SpriteIcon()
                                {
                                    Anchor = Anchor.Centre,
                                    Origin = Anchor.Centre,
                                    Icon = FontAwesome.Solid.Cog,
                                    Colour = Color4.Black,
                                    Size = new Vector2(35),
                                }
                            }
                        }
                    }
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
                            Text = "wang"
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
                                Text = "kljasdfkljfas"
                            }
                        }
                    }
                }
            };
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
            HoverBackground.FadeIn(200);
            tooltipContainer.FadeIn(100);

            return base.OnHover(e);
        }

        protected override void OnHoverLost(HoverLostEvent e)
        {
            HoverBackground.FadeOut(200);
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
