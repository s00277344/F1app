using Newtonsoft.Json;

namespace JolpicaF1CSharp
{
    public struct DriversData
    {
        [JsonProperty("driverId")]
        public string driverId { get; set; }

        [JsonProperty("permanentNumber")]
        public string? permanentNumber { get; set; }

        [JsonProperty("code")]
        public string? code { get; set; }

        [JsonProperty("url")]
        public string? url { get; set; }

        [JsonProperty("givenName")]
        public string givenName { get; set; }

        [JsonProperty("familyName")]
        public string familyName { get; set; }

        [JsonProperty("dateOfBirth")]
        public string? dateOfBirth { get; set; }

        [JsonProperty("nationality")]
        public string? nationality { get; set; }
    }
}
