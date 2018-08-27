using Newtonsoft.Json;

namespace LogicDemo.Yammer
{
    public class YammerBody
    {
        [JsonProperty("parsed")]
        public string Parsed { get; set; }

        [JsonProperty("plain")]
        public string Plain { get; set; }

        [JsonProperty("rich")]
        public string Rich { get; set; }
    }
}
