using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicDemo.Nexus
{
    public class NexusPatient
    {
        public int Id { get; set; }
        public int Version { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string FullName { get; set; }
        public string FullReversedName { get; set; }
        public string HomePhoneNumber { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string WorkPhoneNumber { get; set; }
        public NexusPatientIdentifier PatientIdentifier { get; set; }
        public NexusAddress CurrentAddress { get; set; }
        public string CurrentAddressIndicator { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string PatientStatus { get; set; }
        public NexusPatientState PatientState { get; set; }
        public bool TelephonesRestricted { get; set; }
        [JsonProperty("_links")]
        public Dictionary<string, NexusLink> Links { get; set; }
    }
}
