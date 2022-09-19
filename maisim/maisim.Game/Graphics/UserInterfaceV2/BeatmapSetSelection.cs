using System.Collections.Generic;
using System.Globalization;
using maisim.Game.Beatmaps;
using maisim.Game.Utils;
using Microsoft.Extensions.Logging;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Logging;
using osuTK;

namespace maisim.Game.Graphics.UserInterfaceV2
{
    public class BeatmapSetSelection : CompositeDrawable
    {
        // TODO: Move to DI this when we can read a beatmap from database and has a global beatmap set
        private Bindable<BeatmapSet> bindableBeatmapSet;

        public BeatmapSetSelection(Bindable<BeatmapSet> bindableBeatmapSet)
        {
            this.bindableBeatmapSet = bindableBeatmapSet;
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            // This container need to be wide equal to the screen width to prevent the scroll bar from being cut off.
            Anchor = Anchor.TopLeft;
            Origin = Anchor.TopLeft;
            RelativeSizeAxes = Axes.Y;
            Position = new Vector2(120, 0);
            Size = new Vector2(400, 1);
            InternalChildren = new Drawable[]
            {
                new Box
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    RelativeSizeAxes = Axes.Both,
                    Colour = MaisimColour.SongSelectionContainerColor,
                    Alpha = 0.5f
                },
                new BeatmapScrollSelection(bindableBeatmapSet)
            };
        }
    }
}
