namespace JolpicaF1CSharp
{
    public class DriverStandingsQuery : BaseQuery<DriverStandingData>
    {
        private static readonly string DEFAULT_QUERY = $"{IJolpicaF1Query.JOLPICAF1_ADDRESS}";
        private static readonly string END_QUERY = "/driverstandings.json";
        public DriverStandingsQuery() : base(DEFAULT_QUERY, END_QUERY)
        {
            this.Filter(nameof(DriverStandingData.year), 2025);
        }
    }
}
