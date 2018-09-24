using System;

namespace NHCBridge.NHCCommands
{
    public interface INHCCommand
    {
        string  Command { get; set; }

        string CommandResult { get; set; }
    }
}
