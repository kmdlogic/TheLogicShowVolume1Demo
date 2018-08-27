using Newtonsoft.Json;
using System.Collections.Generic;

namespace LogicDemo.Nexus
{
    public class NexusPatientPage
    {
        [JsonProperty("_links")]
        public Dictionary<string, NexusLink> Links { get; set; }
    }
}
