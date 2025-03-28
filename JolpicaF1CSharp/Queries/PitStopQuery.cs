namespace JolpicaF1CSharp
{
    public class PitStopQuery : BaseQuery<PitStopFilters>
    {
        private static readonly string DEFAULT_QUERY = $"{IJolpicaF1Query.JOLPICAF1_ADDRESS}";
        private static readonly string END_QUERY = "/pitstops";
        private static readonly List<string> FILTER_ORDER = new List<string>() { "Season", "Round", "Driver", "Laps" };
        public PitStopQuery() : base(DEFAULT_QUERY, END_QUERY, FILTER_ORDER)
        {
            this.Filter(nameof(PitStopFilters.season), 2025);
            this.Filter(nameof(PitStopFilters.round), 1);
        }
    }
}
