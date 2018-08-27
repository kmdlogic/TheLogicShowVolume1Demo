using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace LogicDemo.Nexus
{
    public class NexusOrganization
    {
        public int Id { get; set; }
        public int Version { get; set; }
        public string Name { get; set; }
        public string PlannedMove { get; set; }
        public bool WillBeActiveInFuture { get; set; }
        public bool WillBeInactiveInFuture { get; set; }
        public bool Active { get; set; }
        public DateTime EffectiveStartDate { get; set; }
        public DateTime? EffectiveEndDate { get; set; }
        [JsonProperty("_links")]
        public Dictionary<string, NexusLink> Links { get; set; }
    }
}