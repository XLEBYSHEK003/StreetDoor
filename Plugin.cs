using System;
using Exiled.API.Features;
using Exiled.Events.Handlers;

namespace DoorStreet
{
    internal class Plugin : Plugin<Config>
    {
        public override string Prefix
        {
            get
            {
                return "StreetDoor";
            }
        }


        public override string Name
        {
            get
            {
                return "StreetDoor";
            }
        }

        public override string Author
        {
            get
            {
                return "XLEB_YSHEK";
            }
        }

        public override Version Version { get; } = new Version(2, 2, 8);

        public override Version RequiredExiledVersion { get; } = new Version(3, 0, 0);

        public override void OnEnabled()
        {
            this.handlers = new EventHandler(this);
            Log.Info(string.Format("Plugin {0} ({1}) by {2} enabled sucessfully!", this.Name, this.Version, this.Author));
            this.RegisterEvents();
        }

        public override void OnDisabled()
        {
            Log.Info(string.Format("Плагин {0} ({1}) by {2} Выключен!", this.Name, this.Version, this.Author));
            this.UnregisterEvents();
        }

        public void RegisterEvents()
        {
            Exiled.Events.Handlers.Server.RoundStarted += this.handlers.OnRoundStart;
            Exiled.Events.Handlers.Server.WaitingForPlayers += this.handlers.OnWaitingForPlayers;
        }

        public void UnregisterEvents()
        {
            Exiled.Events.Handlers.Server.RoundStarted -= this.handlers.OnRoundStart;
            Exiled.Events.Handlers.Server.WaitingForPlayers -= this.handlers.OnWaitingForPlayers;
        }

        public EventHandler handlers;
    }
}
