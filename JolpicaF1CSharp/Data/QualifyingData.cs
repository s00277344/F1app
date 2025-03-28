using Newtonsoft.Json;

namespace JolpicaF1CSharp
{
    public struct QualifyingData
    {
        [JsonProperty("Number")]
        public string number { get; set; }

        [JsonProperty("Position")]
        public string? position { get; set; }

        [JsonProperty("Driver")]
        public DriversData Driver { get; set; }

        [JsonProperty("Constructor")]
        public ConstructorData Constructor { get; set; }

        [JsonProperty("Q1")]
        public string? Q1 { get; set; }

        [JsonProperty("Q2")]
        public string? Q2 { get; set; }

        [JsonProperty("Q3")]
        public string? Q3 { get; set; }
    }

    public struct QualifyingFilters
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

        [JsonProperty("Grid")]
        public string? grid { get; set; }

        [JsonProperty("Fastest")]
        public string? fastest { get; set; }

        [JsonProperty("Status")]
        public string? status { get; set; }
    }
}
