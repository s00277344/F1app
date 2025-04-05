using JolpicaF1CSharp;
using JolpicaF1CSharp.Queries;
using Newtonsoft.Json;

namespace app.Pages;

public partial class ConstructorStandings : ContentPage
{
    bool IsInitialized = false;

    JolpicaF1Reader jolpicaF1Reader = new JolpicaF1Reader();
    List<ConstructorStandingsData>? constructorStandingsDatas;
    int? year = 2025;

    public ConstructorStandings()
	{
		InitializeComponent();
	}

    private async Task request()
    {
        var query = new ConstructorStandingsQuery();
        if (year is not null)
            query.Filter(nameof(ConstructorStandingsFilters.season), year);

        var rawData = await jolpicaF1Reader.Query(query.GenerateQuery());
        if (rawData is null) return;

        constructorStandingsDatas = JsonConvert.DeserializeObject<Root>(rawData).GetTarget<ConstructorStandingsData>();
        listConstructors.ItemsSource = constructorStandingsDatas;
    }

    private async void ContentPage_Appearing(object sender, EventArgs e)
    {
        if (IsInitialized) return;
        IsInitialized = true;
        await request();
        YearFilter.ItemsSource = Enumerable.Range(1950, 76).Reverse().ToList<int>();
        YearFilter.SelectedIndex = 0;
    }

    private async void YearFilter_SelectedIndexChanged(object sender, EventArgs e)
    {
        year = (int)((Picker)sender).SelectedItem;
        await request();
    }

    private async void listDrivers_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (listConstructors.SelectedItem is not null)
        {
            NavigationPage page = new NavigationPage(new ConstructorDetailPage((ConstructorStandingsData)listConstructors.SelectedItem));
            await Navigation.PushAsync(page);
            listConstructors.SelectedItem = null;
        }
    }
}