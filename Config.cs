using System;
using Exiled.API.Interfaces;
using System.ComponentModel;

namespace DoorStreet
{
    public class Config : IConfig
    {
        [Description("Плагин SrteetDoor работает?")]
        public bool IsEnabled { get; set; } = true;
        
    }
}
