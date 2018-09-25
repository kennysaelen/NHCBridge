using System;

namespace NHCBridge.NHCCommands
{
    public class NHCSystemInfoCommand : INHCCommand
    {
        private const string _command = "systeminfo";        
        public string Command { get { return _command; } }
        public string CommandResult { get; set; }
    }
}