namespace JolpicaF1CSharp
{
    public class CircuitQuery : BaseQuery<CircuitFilters>
    {
        private static readonly string DEFAULT_QUERY = $"{IJolpicaF1Query.JOLPICAF1_ADDRESS}";
        private static readonly string END_QUERY = "/circuits";
        private static readonly List<string> FILTER_ORDER = new List<string>() { "Season", "Round", "Circuit", "Constructor", "Driver", "Fastest", "Grid", "Results", "Status" };
        public CircuitQuery() : base(DEFAULT_QUERY, END_QUERY, FILTER_ORDER)
        {
            this.Filter(nameof(CircuitFilters.season), 2025);
        }
    }
}
