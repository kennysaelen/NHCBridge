using System;

namespace NHCBridge.TCP.Commands
{
    public class NHCSwitchLightCommand : INHCCommand
    {
        public string Command { get; set; }
        public int Id { get; set; }
        public string Value1 { get; set; }
    }
}