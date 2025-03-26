namespace app.Pages;

public partial class FlyoutMainPage : FlyoutPage
{
	public FlyoutMainPage()
	{
		InitializeComponent();
        flyoutMenuPage.CollectionView.SelectionChanged += OnSelectionChanged;
	}

	void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		var item = e.CurrentSelection.FirstOrDefault() as FlyoutPageItem;

		if (item != null)
		{
			var temp = Activator.CreateInstance(item.TargetType);
			if (temp != null)
			{
                Detail = new NavigationPage(temp as Page);
                if (!((IFlyoutPageController)this).ShouldShowSplitMode)
                    IsPresented = false;
            }
        }
	}
}