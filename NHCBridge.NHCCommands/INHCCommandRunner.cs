using System;

namespace NHCBridge.NHCCommands
{
    public interface INHCCommandRunner
    {
        INHCCommand Command { get; set; }

        void execute();
    }
}