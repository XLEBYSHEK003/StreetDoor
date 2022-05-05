using System;
using Exiled.API.Features.Toys;
using Exiled.API.Features;
using Mirror;
using UnityEngine;

namespace DoorStreet
{
    internal class EventHandler
    {

        public void OnRoundStart()
        {
            SpawnHCZDoor(new Vector3(14.332f, 995.2103f, -43.624f));
            SpawnHCZDoor(new Vector3(14.3f, 995.2103f, -23.542f));
            StreetLight(new Vector3(83.44f, 991.15f, -66.02f), new Vector3(13.55f, -62.56f, 180), new Vector3(3.43f, 3.43f, 3.43f));
            SpawnCube(new Vector3(83.6f, 987.94f, -64.85f)); 
            SpawnCube(new Vector3(83.6f, 991.05f, -64.85f));
            SpawnCube(new Vector3(84.62f, 988.68f, -69.135f), new Vector3(-0.13f, 1.97f, 4.65f), new Vector3(0, 0, 90));
            SpawnCube(new Vector3(86.45f, 987.94f, -62.155f), new Vector3(0, -90, 0), new Vector3(0.21f, 1.7f, 5.8f));
            SpawnCube(new Vector3(86.45f, 991.05f, -62.155f), new Vector3(0, -90, 0), new Vector3(0.21f, 2.85f, 5.8f));
            SpawnCube(new Vector3(89.31f, 991.62f, -64.62f), new Vector3(0, 0, 0), new Vector3(0.08f, 1.7f, 5.06f));
            SpawnCube(new Vector3(89.35f, 986.08f, -64.7f), new Vector3(0, 270, 0));
            SpawnCube(new Vector3(86.45f, 992.36f, -64.2f), new Vector3(0.21f, 4.97f, 5.81f), new Vector3(0, 90, 90));

        }

        public void OnWaitingForPlayers()
        {
            Log.Info("Player finding");
        }

        private void SpawnHCZDoor(Vector3 position)
        {
            GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(NetworkManager.singleton.spawnPrefabs.Find((GameObject p) => p.gameObject.name == "HCZ BreakableDoor"));
            gameObject.transform.position = position;
            gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            NetworkServer.Spawn(gameObject);
        }

        private void ShieldDoor(Vector3 position, Vector3 rotation)
        {
            GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(NetworkManager.singleton.spawnPrefabs.Find((GameObject p) => p.gameObject.name == "EZ BreakableDoor"));
            gameObject.transform.position = position;
            gameObject.transform.Rotate(rotation);
            gameObject.transform.localScale = new Vector3(2f, 1.48f, 1f);
            NetworkServer.Spawn(gameObject);
        }

        private void SpawnCube(Vector3 position)
        {
            Primitive cubik = Primitive.Create();
            cubik.Position = position;
            cubik.Scale = new Vector3(0.21f, 1.7f, 5.6f);
            cubik.Type = PrimitiveType.Cube;
            cubik.Spawn();
        }

        private void StreetLight(Vector3 position, Vector3 rotation, Vector3 scale)
        {
            Light StreesLight = Light.Create();
            StreesLight.Position = position;
            StreesLight.Scale = scale;
            StreesLight.Rotation = Quaternion.Euler(rotation);
            StreesLight.Spawn();
        }
    }
}
