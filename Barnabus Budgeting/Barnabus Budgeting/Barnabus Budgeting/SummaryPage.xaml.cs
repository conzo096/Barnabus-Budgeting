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
    public partial class SummaryPage : ContentPage
    {
        public static ObservableCollection<MoneyItem> Data { get; set; }

        public SummaryPage()
        {
            Data = new ObservableCollection<MoneyItem>();
            var items = App.Database.GetItems();
            items.ForEach(x => Data.Add(x));

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

        private async void OnDeleteItem(object sender, EventArgs e)
        {
            var item = (MenuItem)sender;
            var itemToDelete = (MoneyItem)item.CommandParameter;

            await App.Database.DeleteItemAsync(itemToDelete);
            Data.Remove(itemToDelete);
        }
    }
}
