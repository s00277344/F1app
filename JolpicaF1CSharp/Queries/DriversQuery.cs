namespace JolpicaF1CSharp
{
    public class DriversQuery : BaseQuery<DriversFilters>
    {
        private static readonly string DEFAULT_QUERY = $"{IJolpicaF1Query.JOLPICAF1_ADDRESS}";
        private static readonly string END_QUERY = "/drivers";
        private static readonly List<string> FILTER_ORDER = new List<string>() { "Season", "Round", "Circuit", "Constructor", "Driver", "Fastest", "Grid", "Results", "Status" };
        public DriversQuery() : base(DEFAULT_QUERY, END_QUERY, FILTER_ORDER)
        {
            this.Filter(nameof(DriversFilters.season), 2025);
        }
    }
}
