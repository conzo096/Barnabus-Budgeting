using Barnabus_Budgeting.Backend;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Barnabus_Budgeting
{
	public partial class UserExpensesView : ContentView
	{
		public UserExpensesView()
		{
            App.Database.GetItems<ExpenseTransaction>().ForEach(x => UserExpenses.Add(x));
            InitializeComponent();
		}

        private async void OnEditTransaction(object sender, EventArgs e)
        {
            var item = (MenuItem)sender;
            var userGoal = (ExpenseTransaction)item.CommandParameter;
            await Navigation.PushAsync(new AddUserExpensePage(userGoal));
        }

        private async void OnDeleteTransaction(object sender, EventArgs e)
        {
            var item = (MenuItem)sender;
            var itemToDelete = (ExpenseTransaction)item.CommandParameter;

            await App.Database.DeleteItemAsync(itemToDelete);
            UserExpenses.Remove(itemToDelete);
        }

        private async void OnAddNewTransactionClick(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new AddUserExpensePage());
        }

        public static ObservableCollection<ExpenseTransaction> UserExpenses { get; set; } = new ObservableCollection<ExpenseTransaction>();
    }
}