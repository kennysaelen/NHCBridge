using System;

namespace NHCBridge.NHCCommands
{
    public class NHCSwitchLightCommand : INHCActionCommand
    {
        public string Command { get; set; }
        public int Id { get; set; }
        public string Value1 { get; set; }
        public string CommandResult { get; set; }
    }
}