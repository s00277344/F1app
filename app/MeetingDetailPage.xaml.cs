using Newtonsoft.Json;
using OpenF1CSharp;

namespace app;

public partial class MeetingDetailPage : ContentPage
{
	public MeetingDetailPage()
	{
		InitializeComponent();
	}

    private async void ContentPage_Appearing(object sender, EventArgs e)
    {
		OpenF1Reader openF1Reader = new OpenF1Reader();

		var rawData = await openF1Reader.Query(new SessionQuery()
			.Filter(nameof(SessionData.MeetingKey), 1255)
			.GenerateQuery());

		if (rawData is null) return;
		var Data = JsonConvert.DeserializeObject<List<SessionData>>(rawData);
		Sessions.ItemsSource = Data;
    }
}