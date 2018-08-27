using Newtonsoft.Json;
using System.Collections.Generic;

namespace LogicDemo.Nexus
{
    public class NexusPatientStateType
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        [JsonProperty("_links")]
        public Dictionary<string, NexusLink> Links { get; set; }
    }
}