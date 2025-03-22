using OpenF1CSharp;

namespace app;

[QueryProperty(nameof(MeetingData), "MeetingData")]
public partial class MeetingDetailPage : ContentPage
{
	public MeetingData? MeetingData { get; set; }
	public MeetingDetailPage()
	{
		InitializeComponent();
	}

	public MeetingDetailPage(MeetingData meetingData)
	{
		InitializeComponent();
		this.MeetingData = meetingData;

		BindingContext = this;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
		OnPropertyChanged(nameof(MeetingData));
    }
}