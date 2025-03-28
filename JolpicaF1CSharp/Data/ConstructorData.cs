using Newtonsoft.Json;

namespace JolpicaF1CSharp
{
    public struct ConstructorData
    {
        [JsonProperty("ConstructorID")]
        public string? constructorId { get; set; }

        [JsonProperty("URL")]
        public string? url { get; set; }

        [JsonProperty("Name")]
        public string name { get; set; }

        [JsonProperty("Nationality")]
        public string? nationality { get; set; }
    }

    public struct ConstructorFilters
    {
        [JsonProperty("Year")]
        public string? year { get; set; }

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
