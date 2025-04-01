using JolpicaF1CSharp;

namespace app.Pages;

public partial class MeetingDetailPage : ContentPage
{
	RaceData raceData;
	public MeetingDetailPage()
	{
		InitializeComponent();
	}

	public MeetingDetailPage(RaceData raceData)
	{
		this.raceData = raceData;
		InitializeComponent();
	}

    private void ContentPage_Appearing(object sender, EventArgs e)
    {
		NameLabel.Text = raceData.raceName;
		List<SessionData?> sessions = new List<SessionData?>();
        sessions.Add(new SessionData { date = raceData.FirstPractice?.date, time = raceData.FirstPractice?.time, name = "First Practice"});
        if (raceData.Sprint is not null)
        {
            if (raceData.season == "2023")
                sessions.Add(new SessionData { date = raceData.SprintShoutout?.date, time = raceData.SprintShoutout?.time, name = "Sprint Shoutout" });
            else
                sessions.Add(new SessionData { date = raceData.SprintQualifying?.date, time = raceData.SprintQualifying?.time, name = "Sprint Qualifying" });
            sessions.Add(new SessionData { date = raceData.Sprint?.date, time = raceData.Sprint?.time, name = "Sprint" });
        }
        else
        {
            sessions.Add(new SessionData { date = raceData.SecondPractice?.date, time = raceData.SecondPractice?.time, name = "Second Practice" });
            sessions.Add(new SessionData { date = raceData.ThirdPractice?.date, time = raceData.ThirdPractice?.time, name = "Third Practice" });
        }
        sessions.Add(new SessionData { date = raceData.Qualifying?.date, time = raceData.Qualifying?.time, name = "Qualifying" });
        sessions.Add(new SessionData { date = raceData.date, time = raceData.time, name = "Race" });
        Sessions.ItemsSource = sessions;

        imgCircuit.Source = $"{raceData.Circuit.circuitId}.png";
    }
}