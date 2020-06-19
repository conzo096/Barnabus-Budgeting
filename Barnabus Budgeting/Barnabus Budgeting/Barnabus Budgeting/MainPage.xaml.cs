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

        void OnEditItem(object sender, EventArgs e)
        {
            var item = (MenuItem)sender;
            DisplayAlert("Todo: bring up edit page with values", item.CommandParameter.ToString(), "OK");
        }

        void OnDeleteItem(object sender, EventArgs e)
        {
            var item = (MenuItem)sender;

            Data.Remove((MoneyItem)item.CommandParameter);
        }
    }
}
