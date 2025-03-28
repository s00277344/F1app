using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace JolpicaF1CSharp
{
    public struct ResultData
    {
        [JsonProperty("Number")]
        public string number { get; set; }

        [JsonProperty("Position")]
        public string position { get; set; }

        [JsonProperty("PositionText")]
        public string positionText { get; set; }

        [JsonProperty("Points")]
        public string points { get; set; }

        [JsonProperty("Driver")]
        public DriversData Driver { get; set; }

        [JsonProperty("Constructor")]
        public ConstructorData? Constructor { get; set; }

        [JsonProperty("Grid")]
        public string? grid { get; set; }

        [JsonProperty("Laps")]
        public string? laps { get; set; }

        [JsonProperty("Status")]
        public string? status { get; set; }

        [JsonProperty("Time")]
        public Time? Time { get; set; }

        [JsonProperty("FastestLap")]
        public FastestLap? FastestLap { get; set; }
    }

    public struct FastestLap
    {
        [JsonProperty("Rank")]
        public string? rank { get; set; }

        [JsonProperty("Lap")]
        public string? lap { get; set; }

        [JsonProperty("Time")]
        public Time? Time { get; set; }

        [JsonProperty("AverageSpeed")]
        public AverageSpeed? AverageSpeed { get; set; }
    }

    public struct Time
    {
        [JsonProperty("Millis")]
        public string? millis { get; set; }

        [JsonProperty("Time")]
        public string? time { get; set; }
    }

    public struct AverageSpeed
    {
        [JsonProperty("Units")]
        public string? units { get; set; }

        [JsonProperty("Speed")]
        public string? speed { get; set; }
    }

    public struct ResultFilters
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

        [JsonProperty("Status")]
        public string? status { get; set; }
    }
}
