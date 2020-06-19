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
    public partial class AddGoalPage : ContentPage
    {
        ObservableCollection<MoneyItem> allItems;
        public AddGoalPage(ObservableCollection<MoneyItem> data)
        {
            allItems = data;
            InitializeComponent();
        }

        private void OnAddGoalClick(object sender, EventArgs e)
        {
            MoneyItem item = new MoneyItem();
            item.Title = titleField.Text;
            item.Description = titleField.Text;

            allItems.Add(item);

            Navigation.PopAsync();
        }
    }
}
