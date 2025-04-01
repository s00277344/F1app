using JolpicaF1CSharp;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace app.Pages;

public partial class DriversStandings : ContentPage
{
    bool IsInitialized = false;

    JolpicaF1Reader jolpicaF1Reader = new JolpicaF1Reader();
    List<DriverStandingData>? driverStandingDatas;
    int? year = 2025;

    public DriversStandings()
	{
		InitializeComponent();
	}

    private async Task request()
    {
        var query = new DriverStandingsQuery();
        if (year is not null)
            query.Filter(nameof(DriverStandingFilters.season), year);

        var rawData = await jolpicaF1Reader.Query(query.GenerateQuery());
        if (rawData is null) return;

        driverStandingDatas = JsonConvert.DeserializeObject<Root>(rawData).GetTarget<DriverStandingData>();
        listDrivers.ItemsSource = driverStandingDatas;
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
        if (listDrivers.SelectedItem is not null)
        {
            NavigationPage page = new NavigationPage(new DriverDetailPage((DriverStandingData)listDrivers.SelectedItem));
            await Navigation.PushAsync(page);
            listDrivers.SelectedItem = null;
        }
    }
}