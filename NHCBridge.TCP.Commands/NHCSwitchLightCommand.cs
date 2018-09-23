using System;

namespace NHCBridge.NHCCommands
{
    public class NHCSwitchLightCommand : INHCCommand
    {
        public string Command { get; set; }
        public int Id { get; set; }
        public string Value1 { get; set; }
    }
}