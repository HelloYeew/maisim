using System;
using DiscordRPC;
using DiscordRPC.Message;
using maisim.Game.Graphics.UserInterface.Overlays;
using maisim.Game.Users.Activity;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Logging;

namespace maisim.Desktop
{
    public class DiscordRichPresence : Component
    {
        private const string client_id = "938878612969508894";

        private DiscordRpcClient client;

        [Resolved]
        private CurrentWorkingBeatmap currentWorkingBeatmap { get; set; }

        [Resolved]
        private maisim.Game.Users.User gameUser { get; set; }

        private readonly RichPresence presence = new RichPresence
        {
            Assets = new Assets
            {
                // TODO: Change this to icon of the game
                LargeImageKey = "tempicon",
                LargeImageText = "maisim",
                SmallImageKey = "tempicon3",
                SmallImageText = "maisim"
            }
        };

        [BackgroundDependencyLoader]
        private void load()
        {
            client = new DiscordRpcClient(client_id)
            {
                SkipIdenticalPresence = false // handles better on discord IPC loss, see updateStatus call in onReady.
            };

            client.OnReady += onReady;

            client.OnConnectionFailed += (_, __) => client.Deinitialize();

            gameUser.Activity.BindValueChanged(_ =>
            {
                updateStatus();
                Logger.Log("Discord status activity changed from " + _.OldValue + " to " + _.NewValue, LoggingTarget.Runtime, LogLevel.Debug);
            });

            currentWorkingBeatmap.BindBeatmapSetChanged(_ =>
            {
                updateStatus();
                Logger.Log("Discord status beatmap changed from " + _.OldValue + " to " + _.NewValue, LoggingTarget.Runtime, LogLevel.Debug);
            });

            client.Initialize();
        }

        private void onReady(object _, ReadyMessage __)
        {
            updateStatus();
        }

        private void updateStatus()
        {
            if (!client.IsInitialized)
                return;

            presence.State = gameUser.Activity.Value.Status;
            presence.Details = null;

            client.SetPresence(presence);
        }

        protected override void Dispose(bool isDisposing)
        {
            client.Dispose();
            base.Dispose(isDisposing);
        }
    }
}
