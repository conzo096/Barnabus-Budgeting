using Barnabus_Budgeting.Backend;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Barnabus_Budgeting
{
	public partial class UserTransactionsView : ContentView
	{
		public UserTransactionsView()
		{
            App.Database.GetItems<Transaction>().ForEach(x => UserTransactions.Add(x));
            InitializeComponent();
		}

        private async void OnEditTransaction(object sender, EventArgs e)
        {
            var item = (MenuItem)sender;
            var userGoal = (Transaction)item.CommandParameter;
            await Navigation.PushAsync(new AddTransactionPage(userGoal));
        }

        private async void OnDeleteTransaction(object sender, EventArgs e)
        {
            var item = (MenuItem)sender;
            var itemToDelete = (Transaction)item.CommandParameter;

            await App.Database.DeleteItemAsync(itemToDelete);
            UserTransactions.Remove(itemToDelete);
        }

        private async void OnAddNewTransactionClick(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new AddTransactionPage());
        }

        public static ObservableCollection<Transaction> UserTransactions { get; set; } = new ObservableCollection<Transaction>();
    }
}