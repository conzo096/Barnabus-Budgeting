using Barnabus_Budgeting.Backend;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Barnabus_Budgeting
{ 
	public partial class UserGoalsView : ContentView
	{
		public UserGoalsView()
		{
            UserGoalData = new ObservableCollection<UserGoal>();
            
            App.Database.GetItems<UserGoal>().ForEach(x => UserGoalData.Add(x));
            InitializeComponent();
        }

        private async void OnEditGoal(object sender, EventArgs e)
        {
            var item = (MenuItem)sender;
            var userGoal = (UserGoal)item.CommandParameter;
            await Navigation.PushAsync(new AddGoalPage(userGoal));
        }

        private async void OnDeleteGoal(object sender, EventArgs e)
        {
            var item = (MenuItem)sender;
            var itemToDelete = (UserGoal)item.CommandParameter;

            await App.Database.DeleteItemAsync(itemToDelete);
            UserGoalData.Remove(itemToDelete);
        }

        private async void OnSwipeLeft(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddGoalPage());
        }

        private async void OnSwipeRight(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddGoalPage());
        }

        private async void OnAddNewGoalClick(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new AddGoalPage());
        }

        public static ObservableCollection<UserGoal> UserGoalData { get; set; }
    }
}