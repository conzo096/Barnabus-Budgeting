using Barnabus_Budgeting.Backend;
using System;
using Xamarin.Forms;

namespace Barnabus_Budgeting
{
    public partial class AddUserIncomePage : ContentPage
    {
        public AddUserIncomePage()
        {
            InitializeComponent();
        }

        public AddUserIncomePage(IncomeTransaction item)
        {
            InitializeComponent();

            Title = "Edit User Income";
            AddTransactionButton.Text = "Edit User Income";

            TransactionToEdit = item;

            descriptionField.Text = TransactionToEdit.Description;
            amountField.Text = TransactionToEdit.Amount.ToString();
        }

        private async void OnAddTransactionClick(object sender, EventArgs e)
        {
            float.TryParse(amountField.Text, out float conversion);

            if (TransactionToEdit != null)
            {
                TransactionToEdit.Description = descriptionField.Text;
                TransactionToEdit.Amount = conversion;
                await App.Database.SaveItemAsync(TransactionToEdit);
            }
            else
            {
                ExpenseTransaction transaction = new ExpenseTransaction
                {
                    Description = descriptionField.Text,
                    Amount = conversion
                };

                await App.Database.SaveItemAsync(transaction);
                UserExpensesView.UserExpenses.Add(transaction);
            }

            await Navigation.PopAsync();
        }

        private IncomeTransaction TransactionToEdit { set; get; }
    }
}
