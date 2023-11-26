using SimpleMVVM4Maui.Views;

namespace SimpleMVVM4Maui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();
            MainPage = new EmpView();
        }
    }
}
