using JolpicaF1CSharp;
using JolpicaF1CSharp.Queries;
using Newtonsoft.Json;

namespace app.Pages
{
    public partial class MainPage : ContentPage
    {
        bool IsInitialized = false;
        JolpicaF1Reader jolpicaF1Reader;
        RaceData raceData;
        DriverStandingData driverData;
        ConstructorStandingsData constructorData;

        public MainPage()
        {
            InitializeComponent();
            jolpicaF1Reader = new JolpicaF1Reader();
        }

        private async void ContentPage_Appearing(object sender, EventArgs e)
        {
            if (IsInitialized) return;
            IsInitialized = true;

            // GET FOR NEXT RACE
            var rawData = await jolpicaF1Reader.Query(new RaceQuery()
                .Filter(nameof(RaceFilters.season), "current")
                .Filter(nameof(RaceFilters.round), "next")
                .GenerateQuery());
            if (rawData is null) return;

            var temp = JsonConvert.DeserializeObject<Root>(rawData).GetTarget<RaceData>();
            if (temp is null) return;

            raceData = temp.FirstOrDefault();
            RaceNameLabel.Text = raceData.raceName;
            GridNextRace.BindingContext = raceData;

            // GET FAV DRIVER
            rawData = await jolpicaF1Reader.Query(new DriverStandingsQuery()
                .Filter(nameof(DriverStandingFilters.season), "current")
                .Filter(nameof(DriverStandingFilters.Driver), "leclerc")
                .GenerateQuery());
            if (rawData is null) return;

            var temp2 = JsonConvert.DeserializeObject<Root>(rawData).GetTarget<DriverStandingData>();
            if (temp2 is null) return;

            driverData = temp2.FirstOrDefault();
            GridFavDriver.BindingContext = driverData;

            // GET FAV CONSTRUCTOR
            rawData = await jolpicaF1Reader.Query(new ConstructorStandingsQuery()
                .Filter(nameof(ConstructorStandingsFilters.season), "current")
                .Filter(nameof(ConstructorStandingsFilters.Constructor), "ferrari")
                .GenerateQuery());
            if (rawData is null) return;

            var temp3 = JsonConvert.DeserializeObject<Root>(rawData).GetTarget<ConstructorStandingsData>();
            if (temp3 is null) return;

            constructorData = temp3.FirstOrDefault();
            GridFavConstructor.BindingContext = constructorData;
        }

        private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            if (sender is Grid grid && grid.GestureRecognizers.FirstOrDefault() is TapGestureRecognizer tap)
            {
                if (tap.CommandParameter is string paramter)
                {
                    Page? newPage = paramter switch
                    {
                        "Race" => new MeetingDetailPage(raceData),
                        "Driver" => new DriverDetailPage(driverData),
                        _ => null
                    };
                    
                    if (newPage is not null)
                        await Navigation.PushAsync(newPage);
                }
            }
        }
    }

}
