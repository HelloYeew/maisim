﻿using maisim.Game.Screen;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;

namespace maisim.Game
{
    public class maisimGame : maisimGameBase
    {
        private MaisimScreenStack screenStack;

        private Container screenOffsetContainer;

        [BackgroundDependencyLoader]
        private void load()
        {
            // Add your top-level game components here.
            // A screen stack and sample screen has been provided for convenience, but you can replace it if you don't want to use screens.
            // Child = screenStack = new ScreenStack {RelativeSizeAxes = Axes.Both};

            Add(screenStack = new MaisimScreenStack());
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();

            AddRange(new Drawable[]
            {
                screenOffsetContainer = new Container
                {
                    RelativeSizeAxes = Axes.Both,
                    Children = new Drawable[]
                    {
                        screenStack = new MaisimScreenStack
                        {
                            RelativeSizeAxes = Axes.Both
                        }
                    }
                }
            });

            screenStack.Push(new WarningScreen(new MainMenuScreen()));
        }
    }
}
