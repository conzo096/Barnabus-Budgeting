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
        public AddGoalPage()
        {
            InitializeComponent();
        }

        private void OnAddGoalClick(object sender, EventArgs e)
        {
            MoneyItem item = new MoneyItem
            {
                Title = titleField.Text,
                Description = titleField.Text
            };

            MainPage.Data.Add(item);

            Navigation.PopAsync();
        }
    }
}
