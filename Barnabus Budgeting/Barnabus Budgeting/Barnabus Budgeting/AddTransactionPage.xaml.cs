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

        public AddTransactionPage(UserGoal item)
        {
        }
    }
}
