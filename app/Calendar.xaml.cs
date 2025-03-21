using Newtonsoft.Json;
using OpenF1CSharp;
using System.Threading.Tasks;

namespace app;

public partial class Calendar : ContentPage
{
    List<MeetingData>? meetingData;

	public Calendar()
	{
		InitializeComponent();
	}

    private async void ContentPage_Appearing(object sender, EventArgs e)
    {
        OpenF1Reader openF1Reader = new OpenF1Reader();

        var rawData = await openF1Reader.Query(new MeetingQuery()
            .Filter(nameof(MeetingData.Year), 2025)
            .GenerateQuery());

        if (rawData is null) return;

        meetingData = JsonConvert.DeserializeObject<List<MeetingData>>(rawData);
        listMeetings.ItemsSource = meetingData;
    }

    private void listMeetings_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {

    }

    private void listMeetings_ItemTapped(object sender, ItemTappedEventArgs e)
    {

    }
}