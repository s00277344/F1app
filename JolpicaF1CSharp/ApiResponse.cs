namespace JolpicaF1CSharp
{
    public struct StandingList
    {

        public string season { get; set; }
        public string round { get; set; }
        public List<DriverStandingData>? DriverStandings { get; set; }
    }

    public struct StandingTable
    {
        public string season { get; set; }
        public string round { get; set; }
        public List<StandingList>? StandingsLists { get; set; }
    }

    public struct MRData
    {
        public string xmnls { get; set; }
        public string series { get; set; }
        public string url { get; set; }
        public string limit { get; set; }
        public string offset { get; set; }
        public string total { get; set; }
        public StandingTable? StandingsTable { get; set; }
    }

    public struct Root
    {
        public MRData? MRData { get; set; }
    }
}
