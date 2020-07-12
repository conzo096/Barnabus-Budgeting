using Barnabus_Budgeting.Backend;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Barnabus_Budgeting
{
	public partial class UserIncomeView : ContentView
	{
		public UserIncomeView()
		{
            App.Database.GetItems<IncomeTransaction>().ForEach(x => UserIncome.Add(x));
            InitializeComponent();
		}

        private async void OnEditTransaction(object sender, EventArgs e)
        {
            var item = (MenuItem)sender;
            var userIncome = (IncomeTransaction)item.CommandParameter;
            await Navigation.PushAsync(new AddUserIncomePage(userIncome));
        }

        private async void OnDeleteTransaction(object sender, EventArgs e)
        {
            var item = (MenuItem)sender;
            var itemToDelete = (IncomeTransaction)item.CommandParameter;

            await App.Database.DeleteItemAsync(itemToDelete);
            UserIncome.Remove(itemToDelete);
        }

        private async void OnAddNewTransactionClick(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new AddUserExpensePage());
        }

        public static ObservableCollection<IncomeTransaction> UserIncome { get; set; } = new ObservableCollection<IncomeTransaction>();
    }
}