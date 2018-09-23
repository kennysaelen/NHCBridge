using System;

namespace NHCBridge.TCP.Commands
{
    public interface INHCCommand
    {
        string  Command { get; set; }
        int Id { get; set; }
        string Value1 { get; set; }
    }
}
