using Newtonsoft.Json;
using OpenF1CSharp;
using System.Threading.Tasks;

namespace app;

public partial class Calendar : ContentPage
{
    OpenF1Reader openF1Reader = new OpenF1Reader();
    List<MeetingData>? meetingData;
    int? year = 2025;
    string? location;

	public Calendar()
	{
		InitializeComponent();
	}

    private async Task request()
    {
        var query = new MeetingQuery();

        if (year != null)
            query.Filter(nameof(MeetingData.Year), year);

        var rawData = await openF1Reader.Query(query.GenerateQuery());

        if (rawData is null) return;

        meetingData = JsonConvert.DeserializeObject<List<MeetingData>>(rawData);
        listMeetings.ItemsSource = meetingData;
    }

    private void getLocations()
    {
        List<string> countries = new List<string>();
        if (meetingData != null)
            foreach (var meeting in meetingData)
                if (meeting.Location != null && !countries.Contains(meeting.Location))
                    countries.Add(meeting.Location);
        LocationFilter.ItemsSource = countries;
    }

    private async void ContentPage_Appearing(object sender, EventArgs e)
    {
        await request();
        YearFilter.ItemsSource = new List<int> { 2023, 2024, 2025 };
        getLocations();
    }


    private async void listMeetings_ItemTapped(object sender, EventArgs e)
    {
        var meetingData = (MeetingData)((ListView)sender).BindingContext;

        await Shell.Current.GoToAsync(nameof(MeetingDetailPage), true, new Dictionary<string, object> { {"MeetingData", meetingData } });
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

        var query = new MeetingQuery();

        if (year != null)
            query.Filter(nameof(MeetingData.Year), year);

        if (location != null)
            query.Filter(nameof(MeetingData.Location), location);

        var rawData = await openF1Reader.Query(query.GenerateQuery());

        if (rawData is null) return;

        meetingData = JsonConvert.DeserializeObject<List<MeetingData>>(rawData);
        listMeetings.ItemsSource = meetingData;
    }
}