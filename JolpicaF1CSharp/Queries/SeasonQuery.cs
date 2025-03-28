namespace JolpicaF1CSharp
{
    public class SeasonQuery : BaseQuery<SeasonFilters>
    {
        private static readonly string DEFAULT_QUERY = $"{IJolpicaF1Query.JOLPICAF1_ADDRESS}";
        private static readonly string END_QUERY = "/seasons";
        private static readonly List<string> FILTER_ORDER = new List<string>() { "Season", "Circuit", "Constructor", "Driver", "Grid", "Status" };
        public SeasonQuery() : base(DEFAULT_QUERY, END_QUERY, FILTER_ORDER)
        {
        }

    }
}
