using Newtonsoft.Json;

namespace JolpicaF1CSharp
{
    public struct SeasonData
    {
        [JsonProperty("Season")]
        public string season { get; set; }

        [JsonProperty("URL")]
        public string url { get; set; }
    }

    public struct SeasonFilters
    {
        [JsonProperty("Season")]
        public string? season { get; set; }

        [JsonProperty("Circuit")]
        public string? circuits { get; set; }

        [JsonProperty("Constructor")]
        public string? constructors { get; set; }

        [JsonProperty("Driver")]
        public string? drivers { get; set; }

        [JsonProperty("Grid")]
        public string? grid { get; set; }

        [JsonProperty("Status")]
        public string? status { get; set; }
    }
}
