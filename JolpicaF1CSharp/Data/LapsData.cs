using Newtonsoft.Json;

namespace JolpicaF1CSharp
{
    public struct LapsData
    {
        [JsonProperty("Number")]
        public string number { get; set; }

        [JsonProperty("Timings")]
        public List<TimingsData> Timings { get; set; }
    }

    public struct TimingsData
    {
        [JsonProperty("DriverId")]
        public string driverId { get; set; }

        [JsonProperty("Position")]
        public string position { get; set; }

        [JsonProperty("Time")]
        public string time { get; set; }
    }

    public struct LapsFilters
    {
        [JsonProperty("Season")]
        public string? season { get; set; }

        [JsonProperty("Round")]
        public string? round { get; set; }

        [JsonProperty("LapNumber")]
        public string? lapNumber { get; set; }

        [JsonProperty("Driver")]
        public string? drivers { get; set; }

        [JsonProperty("Constructor")]
        public string? constructors { get; set; }
    }
}
