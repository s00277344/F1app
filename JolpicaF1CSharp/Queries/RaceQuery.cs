namespace JolpicaF1CSharp
{
    public class RaceQuery : BaseQuery<RaceFilters>
    {
        private static readonly string DEFAULT_QUERY = $"{IJolpicaF1Query.JOLPICAF1_ADDRESS}";
        private static readonly string END_QUERY = "/races";
        private static readonly List<string> FILTER_ORDER = new List<string>() { "Season", "Round", "Circuit", "Constructor", "Driver", "Grid", "Status" };
        public RaceQuery() : base(DEFAULT_QUERY, END_QUERY, FILTER_ORDER)
        {
            this.Filter(nameof(QualifyingFilters.season), 2025);
        }
    }
}
