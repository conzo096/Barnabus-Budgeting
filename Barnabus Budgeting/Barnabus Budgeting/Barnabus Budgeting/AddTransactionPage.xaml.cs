﻿using Barnabus_Budgeting.Backend;
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
            Transaction transaction = new Transaction
            {
                Type = userTransaction,
                Description = descriptionField.Text,
                Amount = conversion
            };

            await App.Database.SaveItemAsync(transaction);
            SummaryPage.UserTransactions.Add(transaction);
            await Navigation.PopAsync();
        }
    }
}
