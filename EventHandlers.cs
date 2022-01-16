using System;
using Exiled.API.Features;
using Mirror;
using UnityEngine;

namespace StreetDoor
{

    public class EventHandlers
    {
        public EventHandlers(Plugin plugin)
        {
            this.plugin = plugin;
            this.Config = plugin.Config;
        }

        public void OnRoundStart()
        {
            this.SpawnHCZDoor(new Vector3(14.332f, 995.2103f, -43.624f));
            this.SpawnHCZDoor(new Vector3(14.3f, 995.2103f, -23.542f));
            this.SpawnEZDoor(new Vector3(173.44f, -599.32f, 98.71f));
        }

        public void OnWaitingForPlayers()
        {
            Log.Info("wfp");
        }

        private void SpawnHCZDoor(Vector3 position)
        {
            GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(NetworkManager.singleton.spawnPrefabs.Find((GameObject p) => p.gameObject.name == "HCZ BreakableDoor"));
            gameObject.transform.position = position;
            gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            NetworkServer.Spawn(gameObject);
        }

        private void SpawnEZDoor(Vector3 position)
        {
            GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(NetworkManager.singleton.spawnPrefabs.Find((GameObject p) => p.gameObject.name == "EZ BreakableDoor"));
            gameObject.transform.position = position;
            gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            NetworkServer.Spawn(gameObject);
        }

        private void SpawnHeavyDoor(Vector3 position)
        {
            GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(NetworkManager.singleton.spawnPrefabs.Find((GameObject p) => p.gameObject.name == "Unsecured Pryable GateDoor"));
            gameObject.transform.position = position;
            gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            NetworkServer.Spawn(gameObject);
        }


        public Plugin plugin;


        private Config Config;
    }
}
