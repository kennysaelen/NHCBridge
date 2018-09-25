using System;

namespace NHCBridge.NHCCommands
{
    public class NHCListActionsCommand : INHCCommand
    {
        private const string _command = "listactions";        
        public string Command { get { return _command; } }
        public string CommandResult { get; set; }
    }
}