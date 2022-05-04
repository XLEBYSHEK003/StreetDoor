using System;
using Exiled.API.Features.Toys;
using Exiled.API.Features;
using Mirror;
using UnityEngine;

namespace DoorStreet
{
    internal class EventHandler
    {
        public EventHandler(Plugin plugin)
        {
            this.plugin = plugin;
            this.Config = plugin.Config;
        }

        public void OnRoundStart()
        {
            this.SpawnHCZDoor(new Vector3(14.332f, 995.2103f, -43.624f));
            this.SpawnHCZDoor(new Vector3(14.3f, 995.2103f, -23.542f));
            this.StenaPered(new Vector3(83.6f, 987.94f, -64.85f)); 
            this.StenaVerc(new Vector3(83.6f, 991.05f, -64.85f));
            this.Fly(new Vector3(84.62f, 988.68f, -69.135f), new Vector3(-0.13f, 1.97f, 4.65f), new Vector3(0, 0, 90));
            this.Stenalevo(new Vector3(86.45f, 987.94f, -62.155f), new Vector3(0, -90, 0), new Vector3(0.21f, 1.7f, 5.8f));
            this.Stenalevo(new Vector3(86.45f, 991.05f, -62.155f), new Vector3(0, -90, 0), new Vector3(0.21f, 2.85f, 5.8f));
            this.Zad(new Vector3(89.31f, 991.62f, -64.62f), new Vector3(0, 0, 0), new Vector3(0.08f, 1.7f, 5.06f));
            this.ShieldDoor(new Vector3(89.35f, 986.08f, -64.7f), new Vector3(0, 270, 0));
            this.StreetLight(new Vector3(83.44f, 991.15f, -66.02f), new Vector3(13.55f, -62.56f, 180), new Vector3(3.43f, 3.43f, 3.43f));
            this.Fly(new Vector3(86.45f, 992.36f, -64.2f), new Vector3(0.21f, 4.97f, 5.81f), new Vector3(0, 90, 90));

        }

        public void OnWaitingForPlayers()
        {
            Log.Info("Поиск игр");
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



        private void StenaPered(Vector3 position)
        {
            Primitive cubik = Primitive.Create();
            cubik.Position = position;
            cubik.Scale = new Vector3(0.21f, 1.7f, 5.6f);
            cubik.Type = PrimitiveType.Cube;
            cubik.Spawn();
            
        }

        private void StenaVerc(Vector3 position)
        {
            Primitive cubik = Primitive.Create();
            cubik.Position = position;
            cubik.Scale = new Vector3(0.21f, 2.85f, 5.6f);
            cubik.Type = PrimitiveType.Cube;
            cubik.Spawn();

        }

        private void Stenalevo(Vector3 position, Vector3 rotation, Vector3 scale )
        {
            Primitive cubik = Primitive.Create();
            cubik.Position = position;
            cubik.Scale = scale;
            cubik.Rotation = Quaternion.Euler(rotation);
            cubik.Type = PrimitiveType.Cube;
            cubik.Spawn();
            
        }

        private void Fly(Vector3 position, Vector3 scale, Vector3 rotation)
        {
            Primitive cubik = Primitive.Create();
            cubik.Position = position;
            cubik.Scale = scale;
            cubik.Rotation = Quaternion.Euler(rotation);
            cubik.Type = PrimitiveType.Cube;
            cubik.Spawn();

        }
        private void Zad(Vector3 position, Vector3 rotation, Vector3 scale)
        {
            Primitive cubik = Primitive.Create();
            cubik.Position = position;
            cubik.Scale = scale;
            cubik.Rotation = Quaternion.Euler(rotation);
            cubik.Type = PrimitiveType.Cube;
            cubik.Spawn();

        }

        private void StreetLight(Vector3 position, Vector3 rotation, Vector3 scale)
        {

           Exiled.API.Features.Toys.Light StreesLight = Exiled.API.Features.Toys.Light.Create();

            StreesLight.Position = position;
            StreesLight.Scale = scale;
            StreesLight.Rotation = Quaternion.Euler(rotation);
            StreesLight.Spawn();
        
        
        }


        public Plugin plugin;


        private Config Config;
    }
}
