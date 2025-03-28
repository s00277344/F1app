using Newtonsoft.Json;

namespace JolpicaF1CSharp
{
    public struct DriversData
    {
        [JsonProperty("DriverId")]
        public string driverId { get; set; }

        [JsonProperty("PermanentNumber")]
        public string? permanentNumber { get; set; }

        [JsonProperty("Code")]
        public string? code { get; set; }

        [JsonProperty("URL")]
        public string? url { get; set; }

        [JsonProperty("GivenName")]
        public string givenName { get; set; }

        [JsonProperty("FamilyName")]
        public string familyName { get; set; }

        [JsonProperty("DateOfBirth")]
        public string? dateOfBirth { get; set; }

        [JsonProperty("Nationality")]
        public string? nationality { get; set; }
    }

    public struct DriversFilters
    {
        [JsonProperty("Season")]
        public string? season { get; set; }

        [JsonProperty("Round")]
        public string? round { get; set; }

        [JsonProperty("Circuit")]
        public string? circuits { get; set; }

        [JsonProperty("Constructor")]
        public string? constructors { get; set; }

        [JsonProperty("Driver")]
        public string? drivers { get; set; }

        [JsonProperty("Fastest")]
        public string? fastest { get; set; }

        [JsonProperty("Grid")]
        public string? grid { get; set; }

        [JsonProperty("Results")]
        public string? results { get; set; }

        [JsonProperty("Status")]
        public string? status { get; set; }
    }
}
