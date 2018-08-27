using Newtonsoft.Json;
using System.Collections.Generic;

namespace LogicDemo.Nexus
{
    public class NexusAddress
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string AddressLine4 { get; set; }
        public string AddressLine5 { get; set; }
        public string AdministrativeAreaCode { get; set; }
        public string CountryCode { get; set; }
        public string PostalCode { get; set; }
        public string PostalDistrict { get; set; }
        public bool Restricted { get; set; }
        public NexusGeoCoordinates GeoCoordinates { get; set; }
        [JsonProperty("_links")]
        public Dictionary<string, NexusLink> Links { get; set; }
    }
}