using Newtonsoft.Json;

namespace JolpicaF1CSharp
{
    public struct CircuitData
    {
        [JsonProperty("CircuitId")]
        public string circuitId { get; set; }

        [JsonProperty("URL")]
        public string url { get; set; }

        [JsonProperty("CircuitName")]
        public string circuitName { get; set; }

        [JsonProperty("Location")]
        public LocationData Location { get; set; }
    }

    public struct LocationData
    {
        [JsonProperty("Lat")]
        public string lat { get; set; }

        [JsonProperty("Long")]
        public string lng { get; set; }

        [JsonProperty("Locality")]
        public string locality { get; set; }

        [JsonProperty("Country")]
        public string country { get; set; }
    }

    public struct CircuitFilters
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
