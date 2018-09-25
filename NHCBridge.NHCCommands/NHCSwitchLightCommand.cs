using System;

namespace NHCBridge.NHCCommands
{
    public class NHCSwitchLightCommand : INHCActionCommand
    {
        private const string _command = "executeactions";        
        public string Command { get { return _command; } }
        public int Id { get; set; }
        public string Value1 { get; set; }
        public string CommandResult { get; set; }
    }
}