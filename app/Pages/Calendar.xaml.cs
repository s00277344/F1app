using JolpicaF1CSharp;
using Newtonsoft.Json;

namespace app.Pages;

public partial class Calendar : ContentPage
{
    bool IsInitialized = false;

    JolpicaF1Reader jolpicaF1Reader = new JolpicaF1Reader();
    List<RaceData>? raceData;
    int? year = 2025;
    Dictionary<string, string> locations = new Dictionary<string, string>();
    string? location;

	public Calendar()
	{
		InitializeComponent();
    }

    private async Task request()
    {
        var query = new RaceQuery();

        if (year is not null)
            query.Filter(nameof(RaceFilters.season), year);

        var rawData = await jolpicaF1Reader.Query(query.GenerateQuery());
        if (rawData is null) return;

        raceData = JsonConvert.DeserializeObject<Root>(rawData).GetTarget<RaceData>();
        listMeetings.ItemsSource = raceData;
    }

    private void getLocations()
    {
        locations.Clear();
        if (raceData is not null && locations is not null)
        {
            locations.Add(" ", " ");
            foreach (var race in raceData)
                if (race.Circuit.Location.country is not null && !locations.ContainsKey(race.Circuit.Location.country))
                    locations.Add(race.Circuit.Location.country, race.Circuit.circuitId);
            LocationFilter.ItemsSource = locations.Keys.ToList();
            LocationFilter.SelectedIndex = 0;
        }
    }

    private async void ContentPage_Appearing(object sender, EventArgs e)
    {
        if (IsInitialized) return;
        IsInitialized = true;
        await request();
        YearFilter.ItemsSource = Enumerable.Range(1950, 76).Reverse().ToList<int>();
        YearFilter.SelectedIndex = 0;
        getLocations();
    }

    private async void YearFilter_SelectedIndexChanged(object sender, EventArgs e)
    {
        year = (int)((Picker)sender).SelectedItem;
        await request();
        getLocations();
    }

    private async void LocationFilter_SelectedIndexChanged(object sender, EventArgs e)
    {
        location = (string)((Picker)sender).SelectedItem;

        var query = new RaceQuery();
        if (year is not null)
            query.Filter(nameof(RaceFilters.season), year);
        if (location is not null && location != " ")
            query.Filter(nameof(RaceFilters.circuits), locations.GetValueOrDefault(location));

        var rawData = await jolpicaF1Reader.Query(query.GenerateQuery());
        if (rawData is null) return;

        raceData = JsonConvert.DeserializeObject<Root>(rawData).GetTarget<RaceData>();
        listMeetings.ItemsSource = raceData;
    }

    private async void listMeetings_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (listMeetings.SelectedItem is not null)
        {
            NavigationPage page = new NavigationPage(new MeetingDetailPage(((RaceData)listMeetings.SelectedItem)));

            await Navigation.PushAsync(page);
            listMeetings.SelectedItem = null;
        }
    }
}