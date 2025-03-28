namespace JolpicaF1CSharp
{
    public struct StandingList
    {
        public List<DriverStandingData>? DriverStandings { get; set; }
        public List<ConstructorStandingsData>? ConstructorStandings { get; set; }

    }

    public struct StandingTable
    {
        public List<StandingList>? StandingsLists { get; set; }
    }

    public struct ConstructorTable
    {
        public List<ConstructorData>? Constructors { get; set; } 
    }

    public struct DriverTable
    {
        public List<DriversData>? Drivers { get; set; }
    }

    public struct CircuitTable
    {
        public List<CircuitData>? Circuits { get; set; }
    }

    public struct RaceTable
    {
        public List<RaceData>? Races { get; set; }
    }

    public struct SeasonTable
    {
        public List<SeasonData>? Seasons { get; set; }
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
        public DriverTable? DriverTable {  get; set; }
        public CircuitTable? CircuitTable { get; set; }
        public RaceTable? RaceTable { get; set; }
        public SeasonTable? SeasonTable { get; set; }
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
                Type t when t == typeof(DriversData) => MRData?.DriverTable?.Drivers as List<T>,
                Type t when t == typeof(CircuitData) => MRData?.CircuitTable?.Circuits as List<T>,
                Type t when t == typeof(LapsData) => MRData?.RaceTable?.Races?.FirstOrDefault().Laps as List<T>,
                Type t when t == typeof(PitStopData) => MRData?.RaceTable?.Races?.FirstOrDefault().PitStops as List<T>,
                Type t when t == typeof(QualifyingData) => MRData?.RaceTable?.Races?.FirstOrDefault().QualifyingResults as List<T>,
                Type t when t == typeof(RaceData) => MRData?.RaceTable?.Races as List<T>,
                Type t when t == typeof(ResultData) => MRData?.RaceTable?.Races?.FirstOrDefault().Results as List<T>,
                Type t when t == typeof(SeasonData) => MRData?.SeasonTable?.Seasons as List<T>,                
                _ => null
            };
        }
    }
}
