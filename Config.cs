using System;
using Exiled.API.Interfaces;
using System.ComponentModel;

namespace DoorStreet
{
    public class Config : IConfig
    {
        [Description("Плагин на двери возле ХАОС работает?.")]
        public bool IsEnabled { get; set; } = true;
        
    }
}
