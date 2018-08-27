using Newtonsoft.Json;

namespace LogicDemo.Yammer
{
    public class YammerFile
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("size")]
        public long Size { get; set; }
    }
}
