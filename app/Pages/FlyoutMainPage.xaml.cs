namespace app.Pages;

public partial class FlyoutMainPage : FlyoutPage
{
	public FlyoutMainPage()
	{
		InitializeComponent();
        flyoutMenuPage.CollectionView.SelectionChanged += OnSelectionChanged;
	}

	void OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
	{
		var item = e.CurrentSelection.FirstOrDefault() as FlyoutPageItem;

		if (item != null)
		{
			if (item.page is null)
				item.page = Activator.CreateInstance(item.TargetType) as Page;
			    Detail = new NavigationPage(item.page);
                if (!((IFlyoutPageController)this).ShouldShowSplitMode)
                    IsPresented = false;
        }
	}
}