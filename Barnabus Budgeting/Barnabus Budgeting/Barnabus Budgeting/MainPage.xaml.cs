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
        public ObservableCollection<MoneyItem> data = new ObservableCollection<MoneyItem>();

        public MainPage()
        {
            InitializeComponent();
            weekView.ItemsSource = data;
        }

        private async void OnAddNewMoneyItemClick(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new AddGoalPage(data));
        }
    }
}
