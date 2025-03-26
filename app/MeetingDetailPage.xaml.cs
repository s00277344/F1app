using Newtonsoft.Json;
using OpenF1CSharp;
using System.Diagnostics;

namespace app;

public partial class MeetingDetailPage : ContentPage
{
	int MeetingKey = 1255;
	public MeetingDetailPage()
	{
		InitializeComponent();
	}

    private async void ContentPage_Appearing(object sender, EventArgs e)
    {
		OpenF1Reader openF1Reader = new OpenF1Reader();

		var rawData = await openF1Reader.Query(new SessionQuery()
			.Filter(nameof(SessionData.MeetingKey), MeetingKey)
			.GenerateQuery());

		if (rawData is null)
		{
			Debug.WriteLine("raw data empty");
			return;
		}
		var Data = JsonConvert.DeserializeObject<List<SessionData>>(rawData);
		Sessions.ItemsSource = Data;

		
		rawData = await openF1Reader.Query(new MeetingQuery()
			.Filter(nameof(MeetingData.MeetingKey), MeetingKey)
			.GenerateQuery());

		if (rawData is null)
		{
            Debug.WriteLine("raw data empty");
            return;
        }
		var data = JsonConvert.DeserializeObject<List<MeetingData>>(rawData);
		if (data is null) return;
		NameLabel.Text = $"{data.First().MeetingName} Schedule";
    }
}