using Lx.X.Utilities.Mediator;
using X3._Master;
using Xamarin.Forms;

namespace X3
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Mediator.Start();

            MainPage = new MasterDetail();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}