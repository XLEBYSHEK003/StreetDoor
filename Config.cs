using System;
using Exiled.API.Interfaces;

namespace StreetDoor
{

    public class Config : IConfig
    {
        
        public bool IsEnabled { get; set; } = true;
    }
}