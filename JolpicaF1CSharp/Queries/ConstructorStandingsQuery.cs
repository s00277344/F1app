namespace JolpicaF1CSharp.Queries
{
    public class ConstructorStandingsQuery : BaseQuery<ConstructorStandingsFilters>
    {
        private static readonly string DEFAULT_QUERY = $"{IJolpicaF1Query.JOLPICAF1_ADDRESS}";
        private static readonly string END_QUERY = "/constructorstandings";
        private static readonly List<string> FILTER_ORDER = new List<string>() { "Season", "Round", "Constructor" };
        public ConstructorStandingsQuery() : base(DEFAULT_QUERY, END_QUERY, FILTER_ORDER)
        {
            this.Filter(nameof(ConstructorStandingsFilters.season), 2025);
        }
    }
}
