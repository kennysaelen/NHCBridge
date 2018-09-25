using System;

namespace NHCBridge.NHCCommands
{
    public interface INHCCommand
    {
        string  Command { get; }

        string CommandResult { get; set; }
    }
}
