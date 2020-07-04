using Barnabus_Budgeting.Backend;
using System;
using Xamarin.Forms;

namespace Barnabus_Budgeting
{
    public partial class AddTransactionPage : ContentPage
    {
        public AddTransactionPage()
        {
            var enums = Enum.GetValues(typeof(Transaction.TransactionType));

            InitializeComponent();
            transactionPickerField.ItemsSource = enums;
        }

        public AddTransactionPage(Transaction item)
        {
            var enums = Enum.GetValues(typeof(Transaction.TransactionType));

            InitializeComponent();

            transactionPickerField.ItemsSource = enums;
            Title = "Edit item";
            AddTransactionButton.Text = "Edit Transaction";

            TransactionToEdit = item;

            transactionPickerField.SelectedItem = TransactionToEdit.Type;
            descriptionField.Text = TransactionToEdit.Description;
            amountField.Text = TransactionToEdit.Amount.ToString();
        }

        private async void OnAddTransactionClick(object sender, EventArgs e)
        {
            float.TryParse(amountField.Text, out float conversion);

            if (transactionPickerField.SelectedItem == null)
            {
                await DisplayAlert("Warning", "Please enter a transaction type", "OK");
                return;
            }

            var userTransaction = (Transaction.TransactionType)transactionPickerField.SelectedItem;

            if (TransactionToEdit != null)
            {
                TransactionToEdit.Type = userTransaction;
                TransactionToEdit.Description = descriptionField.Text;
                TransactionToEdit.Amount = conversion;
                await App.Database.SaveItemAsync(TransactionToEdit);
            }
            else
            {
                Transaction transaction = new Transaction
                {
                    Type = userTransaction,
                    Description = descriptionField.Text,
                    Amount = conversion
                };

                await App.Database.SaveItemAsync(transaction);
                UserTransactionsView.UserTransactions.Add(transaction);
            }

            await Navigation.PopAsync();
        }

        private Transaction TransactionToEdit { set; get; }
    }
}
