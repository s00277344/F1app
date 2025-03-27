using JolpicaF1CSharp.Data;
using Newtonsoft.Json;

namespace JolpicaF1CSharp
{
    public struct DriverStandingData
    {
        [JsonProperty("year")]
        public string? year { get; set; }

        [JsonProperty("position")]
        public string? position { get; set; }

        [JsonProperty("positionText")]
        public string positionText { get; set; }

        [JsonProperty("points")]
        public string points { get; set; }

        [JsonProperty("wins")]
        public string wins { get; set; }

        [JsonProperty("Driver")]
        public DriversData Driver { get; set; }

        [JsonProperty("Constructors")]
        public List<ConstructorData> Constructors { get; set; }
    }
}
