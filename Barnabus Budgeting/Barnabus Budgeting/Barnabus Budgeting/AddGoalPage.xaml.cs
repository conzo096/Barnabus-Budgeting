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

        public AddGoalPage(MoneyItem item)
        {
            InitializeComponent();

            Title = "Edit item";
            
            titleField.Text = item.Title;
            descriptionField.Text = item.Description;
            amountField.Text = item.Amount.ToString();

        }

        private void OnAddGoalClick(object sender, EventArgs e)
        {
            float.TryParse(amountField.Text, out float conversion);
            MoneyItem item = new MoneyItem
            {
                Title = titleField.Text,
                Description = descriptionField.Text,
                Amount = conversion
                    
            };

            MainPage.Data.Add(item);

            Navigation.PopAsync();
        }
    }
}
