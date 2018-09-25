using System;

namespace NHCBridge.NHCCommands
{
    public class NHCListLocationsCommand : INHCCommand
    {
        private const string _command = "listlocations";        
        public string Command { get { return _command; } }
        public string CommandResult { get; set; }
    }
}