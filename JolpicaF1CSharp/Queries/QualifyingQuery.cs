namespace JolpicaF1CSharp
{
    public class QualifyingQuery : BaseQuery<QualifyingFilters>
    {
        private static readonly string DEFAULT_QUERY = $"{IJolpicaF1Query.JOLPICAF1_ADDRESS}";
        private static readonly string END_QUERY = "/qualifying";
        private static readonly List<string> FILTER_ORDER = new List<string>() { "Season", "Round", "Circuit", "Constructor", "Driver", "Grid", "Fastest", "Status" };
        public QualifyingQuery() : base(DEFAULT_QUERY, END_QUERY, FILTER_ORDER)
        {
            this.Filter(nameof(QualifyingFilters.season), 2025);
        }
    }
}
