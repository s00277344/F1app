namespace JolpicaF1CSharp
{
    public class DriverStandingsQuery : BaseQuery<DriverStandingData>
    {
        private static readonly string DEFAULT_QUERY = $"{IJolpicaF1Query.JOLPICAF1_ADDRESS}";
        private static readonly string END_QUERY = "/driverstandings";
        private static readonly List<string> FILTER_ORDER = new List<string>() { "year", "round", "Driver" };
        public DriverStandingsQuery() : base(DEFAULT_QUERY, END_QUERY, FILTER_ORDER)
        {
            this.Filter(nameof(DriverStandingData.year), 2025);
        }
    }
}
