using System;
using Exiled.API.Features;
using Exiled.Events.Handlers;

namespace DoorStreet
{
    internal class Plugin : Plugin<Config>
    {
        public override string Prefix { get; } = "StreetDoor";

        public override string Name{ get; } = "StreetDoor";

        public override string Author{ get; } = "XLEB_YSHEK";

        public override Version Version { get; } = new Version(2, 2, 8);

        public override Version RequiredExiledVersion { get; } = new Version(3, 0, 0);


        internal readonly EventHandler EventHandler = new EventHandler();        
        internal readonly Plugin Instance;
        public Plugin(){
            Instance = this;
        }

        public override void OnEnabled()
        {
            Log.Info(string.Format("Plugin {0} ({1}) by {2} enabled sucessfully!", Name, Version, Author));
            RegisterEvents();
        }

        public override void OnDisabled()
        {
            Log.Info(string.Format("Плагин {0} ({1}) by {2} Выключен!", Name, Version, Author));
            UnregisterEvents();
        }

        public void RegisterEvents()
        {
            Exiled.Events.Handlers.Server.RoundStarted += EventHandler.OnRoundStart;
            Exiled.Events.Handlers.Server.WaitingForPlayers += EventHandler.OnWaitingForPlayers;
        }

        public void UnregisterEvents()
        {
            Exiled.Events.Handlers.Server.RoundStarted -= EventHandler.OnRoundStart;
            Exiled.Events.Handlers.Server.WaitingForPlayers -= EventHandler.OnWaitingForPlayers;
        }

    }
}
