using maisim.Game.Component.Gameplay.Notes;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Testing;
using osuTK;

namespace maisim.Game.Tests.Visual.Component.Gameplay
{
    public class TestSceneGameplayElement : GridTestScene
    {
        public TestSceneGameplayElement() : base(4, 3)
        {
            Cell(0, 0).Children = new Drawable[]
            {
                new SpriteText
                {
                    Anchor = Anchor.TopLeft,
                    Origin = Anchor.TopLeft,
                    Text = nameof(DrawableTapNote)
                },
                new DrawableTapNote()
            };

            Cell(0, 1).Children = new Drawable[]
            {
                new SpriteText
                {
                    Anchor = Anchor.TopLeft,
                    Origin = Anchor.TopLeft,
                    Text = nameof(DrawableTapBothNote)
                },
                new DrawableTapBothNote
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Scale = new Vector2(1.5f)
                }
            };

            Cell(0, 2).Children = new Drawable[]
            {
                new SpriteText
                {
                    Anchor = Anchor.TopLeft,
                    Origin = Anchor.TopLeft,
                    Text = nameof(DrawableBreakNote)
                },
                new DrawableBreakNote
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Scale = new Vector2(1.5f)
                }
            };

            Cell(1, 0).Children = new Drawable[]
            {
                new SpriteText
                {
                    Anchor = Anchor.TopLeft,
                    Origin = Anchor.TopLeft,
                    Text = nameof(DrawableSlideStarNote)
                },
                new DrawableSlideStarNote
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Scale = new Vector2(1.5f)
                }
            };

            Cell(1, 1).Children = new Drawable[]
            {
                new SpriteText
                {
                    Anchor = Anchor.TopLeft,
                    Origin = Anchor.TopLeft,
                    Text = nameof(DrawableSlidePathNote)
                },
                new DrawableSlidePathNote
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Scale = new Vector2(1.5f)
                }
            };

            Cell(2, 0).Children = new Drawable[]
            {
                new SpriteText
                {
                    Anchor = Anchor.TopLeft,
                    Origin = Anchor.TopLeft,
                    Text = nameof(DrawableTouchNote)
                },
                new DrawableTouchNote
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Scale = new Vector2(1.5f)
                }
            };

            Cell(3, 0).Children = new Drawable[]
            {
                new SpriteText
                {
                    Anchor = Anchor.TopLeft,
                    Origin = Anchor.TopLeft,
                    Text = nameof(DrawableTouchNote)
                },
                new TouchHold
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Scale = new Vector2(1.5f)
                }
            };
        }
    }
}
