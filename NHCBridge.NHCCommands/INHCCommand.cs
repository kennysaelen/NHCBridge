using System;
using Newtonsoft.Json;

namespace NHCBridge.NHCCommands
{
    public interface INHCCommand
    {
        string  Command { get; }

        [JsonIgnore]
        string CommandResult { get; set; }
    }
}
