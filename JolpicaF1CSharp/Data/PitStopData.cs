using Newtonsoft.Json;

namespace JolpicaF1CSharp
{
    public struct PitStopData
    {
        [JsonProperty("DriverId")]
        public string driverId { get; set; }

        [JsonProperty("Lap")]
        public string? lap { get; set; }

        [JsonProperty("Stop")]
        public string? stop { get; set; }

        [JsonProperty("Time")]
        public string? time { get; set; }

        [JsonProperty("Duration")]
        public string? duration { get; set; }
    }

    public struct PitStopFilters
    {
        [JsonProperty("Season")]
        public string? season { get; set; }

        [JsonProperty("Round")]
        public string? round { get; set; }

        [JsonProperty("StopNumber")]
        public string? stopNumber { get; set; }

        [JsonProperty("Driver")]
        public string? drivers { get; set; }

        [JsonProperty("Laps")]
        public string? laps { get; set; }
    }
}
