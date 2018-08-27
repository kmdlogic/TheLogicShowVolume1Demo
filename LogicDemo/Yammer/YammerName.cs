using Newtonsoft.Json;

namespace LogicDemo.Yammer
{
    public class YammerName
    {
        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("permalink")]
        public string Permalink { get; set; }

        [JsonProperty("user_id")]
        public long UserId { get; set; }

        [JsonProperty("network_id")]
        public long NetworkId { get; set; }
    }
}
