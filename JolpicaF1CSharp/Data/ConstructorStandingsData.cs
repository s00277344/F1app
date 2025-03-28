using Newtonsoft.Json;

namespace JolpicaF1CSharp
{
    public struct ConstructorStandingsData
    {
        [JsonProperty("Position")]
        public string? position { get; set; }

        [JsonProperty("PositionText")]
        public string positionText { get; set; }

        [JsonProperty("Points")]
        public string points {  get; set; }

        [JsonProperty("Wins")]
        public string wins { get; set; }

        [JsonProperty("Constructor")]
        public ConstructorData Constructor { get; set; }
    }

    public struct ConstructorStandingsFilters
    {
        [JsonProperty("Season")]
        public string? season { get; set; }

        [JsonProperty("Round")]
        public string? round { get; set; }

        [JsonProperty("Constructor")]
        public string? Constructor {  get; set; }

        [JsonProperty("Position")]
        public string? position { get; set; }
    }
}
