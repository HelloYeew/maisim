using maisim.Game.Screen;
using NUnit.Framework.Internal;
using osu.Framework.Allocation;
using osu.Framework.Audio;
using osu.Framework.Audio.Track;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.IO.Stores;
using Logger = osu.Framework.Logging.Logger;

namespace maisim.Game
{
    public class maisimGame : maisimGameBase
    {
        private MaisimScreenStack screenStack;

        private Container screenOffsetContainer;

        public static ITrackStore trackStore;

        [BackgroundDependencyLoader]
        private void load(AudioManager audio)
        {
            // Add your top-level game components here.
            // A screen stack and sample screen has been provided for convenience, but you can replace it if you don't want to use screens.
            // Child = screenStack = new ScreenStack {RelativeSizeAxes = Axes.Both};

            Add(screenStack = new MaisimScreenStack());

            Logger.LogPrint(Host.Storage.GetFullPath("."));
            var storage = Host.Storage.GetStorageForDirectory("tracks");

            trackStore = audio.GetTrackStore(new ResourceStore<byte[]>(new StorageBackedResourceStore(Host.Storage.GetStorageForDirectory("tracks"))));
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

            // screenStack.Push(new BackgroundScreen());
            screenStack.Push(new MainMenuScreen());
        }
    }
}
