using Barnabus_Budgeting.Backend;
using System;
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
            AddButtonField.Text = "Edit Goal";

            titleField.Text = item.Title;
            descriptionField.Text = item.Description;
            amountField.Text = item.Amount.ToString();

        }

        private async void OnAddGoalClick(object sender, EventArgs e)
        {
            float.TryParse(amountField.Text, out float conversion);
            MoneyItem item = new MoneyItem
            {
                Title = titleField.Text,
                Description = descriptionField.Text,
                Amount = conversion
                    
            };

            await App.Database.SaveItemAsync(item);

            SummaryPage.UserGoalData.Add(item);
            await Navigation.PopAsync();
        }
    }
}
