using Newtonsoft.Json;
using System.Collections.Generic;

namespace LogicDemo.Nexus
{
    public class NexusCitizen
    {
        public int Id { get; set; }
        public int Version { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool DefaultPreference { get; set; }
        public List<NexusOrganization> Organizations { get; set; }
        public string Context { get; set; }
        public NexusView View { get; set; }
        [JsonProperty("_links")]
        public Dictionary<string, NexusLink> Links { get; set; }
    }
}