using app.Pages;

namespace app
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();
            MainPage = new FlyoutMainPage();
        }
    }
}
