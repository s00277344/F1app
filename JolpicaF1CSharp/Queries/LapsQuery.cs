namespace JolpicaF1CSharp
{
    public class LapsQuery : BaseQuery<LapsFilters>
    {
        private static readonly string DEFAULT_QUERY = $"{IJolpicaF1Query.JOLPICAF1_ADDRESS}";
        private static readonly string END_QUERY = "/laps";
        private static readonly List<string> FILTER_ORDER = new List<string>() { "Season", "Round", "Driver", "Constructor" };
        public LapsQuery() : base(DEFAULT_QUERY, END_QUERY, FILTER_ORDER)
        {
            this.Filter(nameof(LapsFilters.season), 2025);
            this.Filter(nameof(LapsFilters.round), 1);
        }
    }
}
