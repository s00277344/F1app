using Android;
using Android.App;
using Android.Appwidget;
using Android.Content;
using Android.Content.Res;
using Android.Runtime;
using Android.Widget;
using Microsoft.Maui.Controls.Compatibility;

namespace app;

[Application]
public class MainApplication : MauiApplication
{
	public MainApplication(IntPtr handle, JniHandleOwnership ownership)
		: base(handle, ownership)
	{
	}

	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
