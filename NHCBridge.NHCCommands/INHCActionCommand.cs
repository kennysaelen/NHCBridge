using System;

namespace NHCBridge.NHCCommands
{
    public interface INHCActionCommand : INHCCommand
    {
        int Id { get; set; }
        string Value1 { get; set; }
    }
}