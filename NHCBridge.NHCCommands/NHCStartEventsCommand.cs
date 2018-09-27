using System;

namespace NHCBridge.NHCCommands
{
    public class NHCStartEventsCommand : INHCCommand
    {
        private const string _command = "startevents";        
        public string Command { get { return _command; } }
        public string CommandResult { get; set; }
    }
}