using JolpicaF1CSharp;

namespace app.Pages;

public partial class ConstructorDetailPage : ContentPage
{
	ConstructorStandingsData constructorStandings;

	public ConstructorDetailPage()
	{
		InitializeComponent();
	}

	public ConstructorDetailPage(ConstructorStandingsData constructorStandings)
	{
		this.constructorStandings = constructorStandings;
		InitializeComponent();
	}

    private void ContentPage_Appearing(object sender, EventArgs e)
    {
		VerticalStackLayout.BindingContext = constructorStandings;
		if (constructorStandings.Constructor.constructorId is not null)
		{
            imgConstructor.Source = $"{constructorStandings.Constructor.constructorId}_logo.png";
#if ANDROID
			var context = Android.App.Application.Context;
			if (context.Resources?.GetIdentifier($"{constructorStandings.Constructor.constructorId}", "drawable", context.PackageName) != 0)
			{
				VerticalStackLayout.Add(new Label() { Text = "Livery (2025) :", FontSize = 24, FontAttributes = FontAttributes.Bold });
				VerticalStackLayout.Add(new Image() { Source = constructorStandings.Constructor.constructorId });
			}
#endif
		}
    }
}