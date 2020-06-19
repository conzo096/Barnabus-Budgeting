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
    public partial class MainPage : ContentPage
    {
        public static ObservableCollection<MoneyItem> Data { get; set; } 

        public MainPage()
        {
            Data = new ObservableCollection<MoneyItem>();

            InitializeComponent();
            weekView.ItemsSource = Data;
        }

        private async void OnAddNewMoneyItemClick(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new AddGoalPage());
        }

        private async void OnEditItem(object sender, EventArgs e)
        {
            var item = (MenuItem)sender;
            await Navigation.PushAsync(new AddGoalPage((MoneyItem)item.CommandParameter));
        }

        private void OnDeleteItem(object sender, EventArgs e)
        {
            var item = (MenuItem)sender;
            Data.Remove((MoneyItem)item.CommandParameter);
        }
    }
}
