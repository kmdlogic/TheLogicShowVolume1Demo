using Newtonsoft.Json;
using System.Collections.Generic;

namespace LogicDemo.Nexus
{
    public class NexusPatientIdentifier
    {
        public string Type { get; set; }
        public string Identifier { get; set; }
        public bool ManagedExternally { get; set; }
        [JsonProperty("_links")]
        public Dictionary<string, NexusLink> Links { get; set; }
    }
}