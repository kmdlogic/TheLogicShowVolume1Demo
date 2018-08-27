using Newtonsoft.Json;
using System.Collections.Generic;

namespace LogicDemo.Nexus
{
    public class NexusView
    {
        public string Type { get; set; }
        public string ViewType { get; set; }
        public bool ShowBulkOperations { get; set; }

        [JsonProperty("_links")]
        public Dictionary<string, NexusLink> Links { get; set; }
    }
}