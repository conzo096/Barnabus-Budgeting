﻿using Barnabus_Budgeting.Backend;
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
        public SummaryPage()
        {
            UserGoalData = new ObservableCollection<UserGoal>();
            UserTransactions = new ObservableCollection<Transaction>();

            App.Database.GetItems<UserGoal>().ForEach(x => UserGoalData.Add(x));
            App.Database.GetItems<Transaction>().ForEach(x => UserTransactions.Add(x));

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

        public static ObservableCollection<UserGoal> UserGoalData { get; set; }
        public static ObservableCollection<Transaction> UserTransactions { get; set; }

    }
}