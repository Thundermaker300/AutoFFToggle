using Exiled.API.Features;
using Exiled.API.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;
using ServerHandler = Exiled.Events.Handlers.Server;

namespace AutoFFToggle
{
    public class MainPlugin : Plugin<Config>
    {
        public static MainPlugin Singleton;
        public static EventHandlers Handlers;

        public override void OnEnabled()
        {
            if (Server.FriendlyFire)
            {
                Log.Warn("Friendly fire is already enabled! AutoFFToggle will be disabled.");
                return;
            }

            Singleton = this;
            Handlers = new();

            ServerHandler.WaitingForPlayers += Handlers.OnWaitingForPlayers;
            ServerHandler.RoundEnded += Handlers.OnRoundEnded;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            ServerHandler.WaitingForPlayers -= Handlers.OnWaitingForPlayers;
            ServerHandler.RoundEnded -= Handlers.OnRoundEnded;

            Singleton = null;
            Handlers = null;
            base.OnDisabled();
        }
    }

    public class Config : IConfig
    {
        [Description("Whether or not to enable AutoFFToggle.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Whether or not to enable AutoFFToggle debug logs.")]
        public bool Debug { get; set; } = false;

        [Description("Items to give at the end of the round.")]
        public List<ItemType> ItemsToGive { get; set; } = new();
    }
}
