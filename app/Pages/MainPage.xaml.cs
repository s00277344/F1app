using JolpicaF1CSharp;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace app.Pages
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        bool IsInitialized = false;
        JolpicaF1Reader jolpicaF1Reader;
        RaceData raceData;

        public MainPage()
        {
            InitializeComponent();
            jolpicaF1Reader = new JolpicaF1Reader();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count+=5;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private async void ContentPage_Appearing(object sender, EventArgs e)
        {
            if (IsInitialized) return;
            IsInitialized = true;
            var rawData = await jolpicaF1Reader.Query(new RaceQuery()
                .Filter(nameof(RaceFilters.season), "current")
                .Filter(nameof(RaceFilters.round), "next")
                .GenerateQuery());
            if (rawData == null) return;

            var temp = JsonConvert.DeserializeObject<Root>(rawData).GetTarget<RaceData>();
            if (temp is null) return;

            raceData = temp.FirstOrDefault();
            RaceNameLabel.Text = raceData.raceName;
            GridNextRace.BindingContext = raceData;
        }

        private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            NavigationPage page = new NavigationPage(new MeetingDetailPage(raceData));

            await Navigation.PushAsync(page);
        }
    }

}
