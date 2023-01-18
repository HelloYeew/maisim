using System;
using maisim.Game.Database;
using maisim.Game.Configuration;
using maisim.Game.Store;
using maisim.Resources;
using osu.Framework.Allocation;
using osu.Framework.Audio;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.IO.Stores;
using osu.Framework.Bindables;
using osu.Framework.Development;
using osu.Framework.Graphics.Performance;
using osu.Framework.Logging;
using osu.Framework.Platform;
using osuTK;

namespace maisim.Game
{
    // ReSharper disable once InconsistentNaming
    public partial class maisimGameBase : osu.Framework.Game
    {
        // Anything in this class is shared between the test browser and the game implementation.
        // It allows for caching global dependencies that should be accessible to tests, or changing
        // the screen scaling for all components including the test browser and framework overlays.

        private BeatmapDatabaseContext beatmapDatabase = new BeatmapDatabaseContext();

        protected override Container<Drawable> Content { get; }

        private MaisimTextureStore textureStore;

        protected MaisimConfigManager LocalConfig { get; private set; }

        protected Storage Storage { get; set; }

        public MaisimStore Store;

        private AudioManager audioManager;

        private DependencyContainer dependencies;

        private Bindable<bool> fpsDisplayVisible;

        protected maisimGameBase()
        {
            // Ensure game and tests scale with window size and screen DPI.
            base.Content.Add(Content = new DrawSizePreservingFillContainer
            {
                // You may want to change TargetDrawSize to your "default" resolution, which will decide how things scale and position when using absolute coordinates.
                TargetDrawSize = new Vector2(1366, 768)
            });
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            Resources.AddStore(new DllResourceStore(typeof(maisimResources).Assembly));

            AddFont(Resources, @"Fonts/MPlus1p/MPlus1p-Bold");
            AddFont(Resources, @"Fonts/MPlus1p/MPlus1p-Regular");
            AddFont(Resources, @"Fonts/MPlus1p/MPlus1p-BoldItalic");
            AddFont(Resources, @"Fonts/MPlus1p/MPlus1p-Italic");
            AddFont(Resources, @"Fonts/MPlus1p/MPlus1p-Light");
            AddFont(Resources, @"Fonts/MPlus1p/MPlus1p-Medium");

            AddFont(Resources, @"Fonts/Comfortaa/Comfortaa-Regular");
            AddFont(Resources, @"Fonts/Comfortaa/Comfortaa-Bold");
            AddFont(Resources, @"Fonts/Comfortaa/Comfortaa-BoldItalic");
            AddFont(Resources, @"Fonts/Comfortaa/Comfortaa-Italic");
            AddFont(Resources, @"Fonts/Comfortaa/Comfortaa-Light");

            AddFont(Resources, @"Fonts/Kanit/Kanit-Bold");

            AddFont(Resources, @"Fonts/GothicA1/GothicA1-Bold");

            AddFont(Resources, @"Fonts/Noto/Noto-Basic");
            AddFont(Resources, @"Fonts/Noto/Noto-Hangul");
            AddFont(Resources, @"Fonts/Noto/Noto-CJK-Basic");
            AddFont(Resources, @"Fonts/Noto/Noto-CJK-Compatibility");

            Logger.Log("Game storage path : " + Host.Storage.GetFullPath(""), LoggingTarget.Database);
            Logger.Log("Environment application data : "+ Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), LoggingTarget.Database);

            ResourceStore<byte[]> trackResourceStore = new ResourceStore<byte[]>();
            trackResourceStore.AddStore(new NamespacedResourceStore<byte[]>(new MaisimStore(Host.Storage), "beatmaps"));
            trackResourceStore.AddStore(new NamespacedResourceStore<byte[]>(Resources, "Tracks"));

            dependencies.Cache(textureStore = new MaisimTextureStore(Host.Renderer, Host.CreateTextureLoaderStore(new NamespacedResourceStore<byte[]>(Resources, "Textures"))));
            dependencies.Cache(audioManager = new AudioManager(Host.AudioThread, trackResourceStore, new NamespacedResourceStore<byte[]>(Resources, "Samples")));
            dependencies.CacheAs(this);
            dependencies.CacheAs(LocalConfig);
            dependencies.CacheAs(beatmapDatabase);
            beatmapDatabase.InitializeDatabase();
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();

            fpsDisplayVisible = LocalConfig.GetBindable<bool>(MaisimSetting.ShowFpsDisplay);
            fpsDisplayVisible.ValueChanged += visible => { FrameStatistics.Value = visible.NewValue ? FrameStatisticsMode.Minimal : FrameStatisticsMode.None; };
            fpsDisplayVisible.TriggerChange();
        }

        public override void SetHost(GameHost host)
        {
            base.SetHost(host);
            Storage = host.Storage;
            LocalConfig ??= DebugUtils.IsDebugBuild
                ? new DevelopmentMaisimConfigManager(Storage)
                : new MaisimConfigManager(Storage);
        }

        protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent) => dependencies = new DependencyContainer(base.CreateChildDependencies(parent));
    }
}
