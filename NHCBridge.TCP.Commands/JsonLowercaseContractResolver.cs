using System.Collections.Generic;
using Newtonsoft.Json.Serialization;

namespace NHCBridge.NHCCommands
{
    public class JsonLowercaseContractResolver : DefaultContractResolver
    {
        private Dictionary<string, string> PropertyMappings { get; set; }

        public JsonLowercaseContractResolver()
        {
            this.PropertyMappings = new Dictionary<string, string> 
            {
                {"Id", "id"},
                {"Command", "cmd"},
                {"Value1", "value1"},
            };
        }
            protected override string ResolvePropertyName(string propertyName)
            {
                string resolvedName = null;
                var resolved = this.PropertyMappings.TryGetValue(propertyName, out resolvedName);
                return (resolved) ? resolvedName : base.ResolvePropertyName(propertyName);
            }
    }
}