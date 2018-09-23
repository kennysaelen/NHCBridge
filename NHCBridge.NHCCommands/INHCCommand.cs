using System;

namespace NHCBridge.NHCCommands
{
    public interface INHCCommand
    {
        string  Command { get; set; }
        int Id { get; set; }
        string Value1 { get; set; }
    }
}
