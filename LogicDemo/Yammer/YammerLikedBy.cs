using System.Collections.Generic;
using Newtonsoft.Json;

namespace LogicDemo.Yammer
{
    public class YammerLikedBy
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("names")]
        public List<YammerName> Names { get; set; }
    }
}
