using Newtonsoft.Json;

namespace JolpicaF1CSharp
{
    public struct DriverStandingData
    {
        [JsonProperty("Position")]
        public string? position { get; set; }

        [JsonProperty("Driver")]
        public DriversData Driver { get; set; }

        [JsonProperty("PositionText")]
        public string positionText { get; set; }

        [JsonProperty("Points")]
        public string points { get; set; }

        [JsonProperty("Wins")]
        public string wins { get; set; }

        [JsonProperty("Constructors")]
        public List<ConstructorData> Constructors { get; set; }
    }

    public struct DriverStandingFilters
    {
        [JsonProperty("Season")]
        public string? season { get; set; }

        [JsonProperty("Round")]
        public string? round { get; set; }

        [JsonProperty("Position")]
        public string? position { get; set; }

        [JsonProperty("Driver")]
        public DriversData Driver { get; set; }
    }
}
