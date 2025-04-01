using JolpicaF1CSharp;

namespace app.Pages;

public partial class DriverDetailPage : ContentPage
{
	DriverStandingData driverData;
	public DriverDetailPage()
	{
		InitializeComponent();
	}

	public DriverDetailPage(DriverStandingData driverData)
	{
		this.driverData = driverData;
		InitializeComponent();
	}

    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        VerticalStackLayout.BindingContext = driverData;
        imgDriver.Source = $"{driverData.Driver.driverId}.png";
		if (driverData.Constructors.Count > 0)
			txtConstructor.Text = $"Constructor : {driverData.Constructors.First().name}";
    }
}