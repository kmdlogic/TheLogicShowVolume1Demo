using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicDemo.Nexus
{
    public class NexusPatientFilter
    {
        public int TotalItems { get; set; }
        public int PageSize{ get; set; }
        public List<NexusPatientPage> Pages { get; set; }
        [JsonProperty("_links")]
        public Dictionary<string, NexusLink> Links { get; set; }
    }
}
