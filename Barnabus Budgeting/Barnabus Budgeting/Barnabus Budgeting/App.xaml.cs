using Barnabus_Budgeting.Backend;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Barnabus_Budgeting
{
    public partial class App : Application
    {
        static BarnabusDatabase database;
        public static BarnabusDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new BarnabusDatabase();
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new CarouselPage
            {
                Children = { new SummaryPage(), new AddTransactionPage() }
            };
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
