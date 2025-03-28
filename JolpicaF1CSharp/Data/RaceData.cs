using Newtonsoft.Json;

namespace JolpicaF1CSharp
{
    public struct RaceData
    {
        [JsonProperty("Season")]
        public string season { get; set; }

        [JsonProperty("Round")]
        public string round { get; set; }

        [JsonProperty("URL")]
        public string? url { get; set; }

        [JsonProperty("RaceName")]
        public string raceName { get; set; }

        [JsonProperty("Circuit")]
        public CircuitData Circuit { get; set; }

        [JsonProperty("Date")]
        public string date { get; set; }

        [JsonProperty("Time")]
        public string? time { get; set; }

        [JsonProperty("Laps")]
        public List<LapsData>? Laps { get; set; }

        [JsonProperty("PitStops")]
        public List<PitStopData>? PitStops { get; set; }

        [JsonProperty("QualifyingResults")]
        public List<QualifyingData>? QualifyingResults { get; set; }

        [JsonProperty("Results")]
        public List<ResultData>? Results { get; set; }

        [JsonProperty("FirstPractice")]
        public SessionData? FirstPractice { get; set; }

        [JsonProperty("SecondPractice")]
        public SessionData? SecondPractice { get; set; }

        [JsonProperty("ThirdPractice")]
        public SessionData? ThirdPractice { get; set; }

        [JsonProperty("Qualifying")]
        public SessionData? Qualifying { get; set; }

        [JsonProperty("Sprint")]
        public SessionData? Sprint { get; set; }

        [JsonProperty("SprintQualifying")]
        public SessionData? SprintQualifying { get; set; }

        [JsonProperty("SprintShoutout")]
        public SessionData? SprintShoutout { get; set; }
    }

    public struct SessionData
    {
        [JsonProperty("Date")]
        public string? date { get; set; }

        [JsonProperty("Time")]
        public string? time { get; set; }
    }

    public struct RaceFilters
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

        [JsonProperty("Status")]
        public string? status { get; set; }
    }
}
