using Barnabus_Budgeting.Backend;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Barnabus_Budgeting
{
    public partial class SummaryPage : ContentPage
    {
        public static ObservableCollection<UserGoal> UserGoalData { get; set; }

        public SummaryPage()
        {
            UserGoalData = new ObservableCollection<UserGoal>();
            var items = App.Database.GetItems();
            items.ForEach(x => UserGoalData.Add(x));

            InitializeComponent();
            goalListView.ItemsSource = UserGoalData;
        }

        private async void OnAddNewGoalClick(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new AddGoalPage());
        }

        private async void OnAddNewTransactionClick(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new AddTransactionPage());
        }

        private async void OnEditItem(object sender, EventArgs e)
        {
            var item = (MenuItem)sender;
            var userGoal = (UserGoal)item.CommandParameter;
            await Navigation.PushAsync(new AddGoalPage(userGoal));
        }

        private async void OnDeleteItem(object sender, EventArgs e)
        {
            var item = (MenuItem)sender;
            var itemToDelete = (UserGoal)item.CommandParameter;

            await App.Database.DeleteItemAsync(itemToDelete);
            UserGoalData.Remove(itemToDelete);
        }
    }
}
