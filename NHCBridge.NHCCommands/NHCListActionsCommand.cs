using System;

namespace NHCBridge.NHCCommands
{
    public class NHCListActionsCommand : INHCCommand
    {
        public string Command { get; set; }
        public string CommandResult { get; set; }
    }
}