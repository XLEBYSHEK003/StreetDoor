using System;
using Exiled.API.Interfaces;
using System.ComponentModel;

namespace StreetDoor
{
    public class Config : IConfig
    {
        [Description("Плагин SrteetDoor работает?")]
        public bool IsEnabled { get; set; } = true;


        [Description("Включить спавн дверей в проходе ХАОС на Gate A?")]
        public bool SpawnDoor { get; set; } = false;

    }
}
