using Android.App;
using Android.Appwidget;
using Android.Content;
using Android.Widget;
using AndroidResource = app.Resource;

namespace app.Platforms.Android
{
    [BroadcastReceiver(Label = "My Widget", Exported = true)]
    [IntentFilter(new[] { "android.appwidget.action.APPWIDGET_UPDATE" })]
    [MetaData("android.appwidget.provider", Resource = "@xml/my_widget_provider")]
    public class MyWidgetProvider : AppWidgetProvider
    {
        public override void OnUpdate(Context? context, AppWidgetManager? appWidgetManager, int[]? appWidgetIds)
        {
            if (appWidgetIds is not null)
            {
                foreach (var widgetId in appWidgetIds)
                {
                    if (context is not null && appWidgetManager is not null)
                    {
                        var views = new RemoteViews(context.PackageName, AndroidResource.Layout.widget_layout);
                        views.SetTextViewText(AndroidResource.Id.widgetText, "Hello from MAUI!");
                        appWidgetManager.UpdateAppWidget(widgetId, views);

                    }
                }
            }
        }
    }
}
