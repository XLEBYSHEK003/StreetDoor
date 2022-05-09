using System;
using Exiled.API.Features.Toys;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using Mirror;
using UnityEngine;

namespace StreetDoor
{
    internal class EventHandler
    {

        public void OnRoundStart()
        {

            Cubik(new Vector3(83.58f, 991.23f, -59.3f), new Vector3(0.26f, 2.4f, 15.47f), new Vector3(0, 0, 0)); //Перед верх
            Cubik(new Vector3(83.58f, 987.9f, -54.83f), new Vector3(0.26f, 1.91f, 6.5f), new Vector3(0, 0, 0)); //Перед низ лево
            Cubik(new Vector3(83.58f, 987.9f, -63.55f), new Vector3(0.26f, 1.91f, 6.7f), new Vector3(0, 0, 0)); //Перед низ право
            Cubik(new Vector3(84.9f, 991.02f, -59.36f), new Vector3(0.26f, 2.4f, 15.47f), new Vector3(0, 0, 90)); //Потолок
            Cubik(new Vector3(85.97f, 990.57f, -59.24f), new Vector3(0.26f, 1.1f, 15.7f), new Vector3(0, 0, 0)); //зад верх
            Cubik(new Vector3(85.97f, 988.66f, -63.69f), new Vector3(0.26f, 2.94f, 6.8f), new Vector3(0, 0, 0)); //Зад низ лево
            Cubik(new Vector3(85.97f, 988.66f, -54.79f), new Vector3(0.26f, 2.94f, 6.35f), new Vector3(0, 0, 0)); // Зад низ право
            Cubik(new Vector3(90.36f, 989.1f, -54.1f), new Vector3(9.25f, 0.1f, 4.93f), new Vector3(0, 0, -25)); // Лестница
            Cubik(new Vector3(86.44f, 991.37f, -66.93f), new Vector3(0.26f, 2.34f, 5.65f), new Vector3(0, 90, 0)); // Верх Верх Комната
            Cubik(new Vector3(86.36f, 989.98f, -67.14f), new Vector3(0.65f, 5.69f, 1.03f), new Vector3(0, 90, 0)); // Верх право стена комната
            Cubik(new Vector3(85.55f, 988.18f, -70.32f), new Vector3(0.24f, 5.63f, 1.65f), new Vector3(0, 0, 90)); // Полка для оружия
            // Двери
            SpawnEZDoor(new Vector3(83.57f, 987.16f -59.21f), new Vector3(0, 90, 0));
            SpawnEZDoor(new Vector3(85.94f, 987.16f -59.1f), new Vector3(0, 90, 0));
            SpawnHCZDoor(new Vector3(87.72f, 987.16f, -66.86f), new Vector3(0, 0, 0));
            //Свет
            Light(new Vector3(83f, 990.9f, -59.25f), Color.red, 5f); // Красная лампочка над дверью
            Light(new Vector3(86.4f, 990.53f, -59.19f), Color.red, 5f); // Красная лампочка над дверью 2
            Light(new Vector3(86.4f, 992.01f, -68.91f), Color.blue, 5f); //Синяя лампочка

            //Двери у ХАОС
            if (Config.SpawnDoor == true) 
            {  
                SpawnHCZDoor(new Vector3(14.332f, 995.2103f, -43.624f), new Vector3 (0, 0, 0));
                SpawnHCZDoor(new Vector3(14.3f, 995.2103f, -23.542f), new Vector3(0, 0, 0));
            }    

        }

        public void OnWaitingForPlayers()
        {
            Log.Info("Поиск игры");
        }

        public GameObject CubikDestroy = GameObject.Find("cubik");
        public void OnRoundEnd(EndingRoundEventArgs ev)
        {

            NetworkServer.UnSpawn(CubikDestroy);
            NetworkServer.Destroy(CubikDestroy);

        }

        private void SpawnHCZDoor(Vector3 position, Vector3 rotation)
        {
            GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(NetworkManager.singleton.spawnPrefabs.Find((GameObject p) => p.gameObject.name == "HCZ BreakableDoor"));
            
            gameObject.transform.position = position;
            gameObject.transform.Rotate(rotation);
            gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            NetworkServer.Spawn(gameObject);
        }

        private void SpawnEZDoor(Vector3 position, Vector3 rotation)
        {
            GameObject EZDoor = UnityEngine.Object.Instantiate<GameObject>(NetworkManager.singleton.spawnPrefabs.Find((GameObject p) => p.gameObject.name == "EZ BrokenDoor"));

            EZDoor.transform.position = position;
            EZDoor.transform.Rotate(rotation);
            EZDoor.transform.localScale = new Vector3(1.18f, 0.9f, 1f);
            NetworkServer.Spawn(EZDoor);
        }



        private void Cubik(Vector3 position, Vector3 scale, Vector3 rotation)
        {
            Primitive cubik = Primitive.Create();

            cubik.Position = position;
            cubik.Scale = scale;
            cubik.Rotation = Quaternion.Euler(rotation);
            cubik.Type = PrimitiveType.Cube;
            cubik.Spawn();

        }

        private void Light(Vector3 position, Color color, float y)
        {

            Exiled.API.Features.Toys.Light StreetLight = Exiled.API.Features.Toys.Light.Create();

            StreetLight.Position = position;
            StreetLight.Color = color;
            StreetLight.Range = y;
            StreetLight.Spawn();
        }

        public Plugin plugin;

        private Config Config;
    }
}
