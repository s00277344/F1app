namespace JolpicaF1CSharp
{
    public struct StandingList
    {
        public string season { get; set; }
        public string round { get; set; }
        public List<DriverStandingData>? DriverStandings { get; set; }
        public List<ConstructorStandingsData>? ConstructorStandings { get; set; }

    }

    public struct StandingTable
    {
        public string season { get; set; }
        public string round { get; set; }
        public List<StandingList>? StandingsLists { get; set; }
    }

    public struct ConstructorTable
    {
        public string season { get; set; }
        public string round { get; set; }
        public List<ConstructorData>? Constructors { get; set; } 
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
        public ConstructorTable? ConstructorTable { get; set; }
    }

    public struct Root
    {
        public MRData? MRData { get; set; }

        public List<T>? GetTarget<T>()
        {
            return typeof(T) switch
            {
                Type t when t == typeof(DriverStandingData) => MRData?.StandingsTable?.StandingsLists?.FirstOrDefault().DriverStandings as List<T>,
                Type t when t == typeof(ConstructorStandingsData) => MRData?.StandingsTable?.StandingsLists?.FirstOrDefault().ConstructorStandings as List<T>,
                Type t when t == typeof(ConstructorData) => MRData?.ConstructorTable?.Constructors as List<T>,
                _ => null
            };
        }
    }
}
