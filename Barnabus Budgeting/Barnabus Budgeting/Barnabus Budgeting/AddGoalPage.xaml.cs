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

        public AddGoalPage(UserGoal item)
        {
            InitializeComponent();

            Title = "Edit item";
            AddButtonField.Text = "Edit Goal";

            GoalToEdit = item;
            titleField.Text = GoalToEdit.Title;
            descriptionField.Text = GoalToEdit.Description;
            amountField.Text = GoalToEdit.Amount.ToString();

        }

        private async void OnAddGoalClick(object sender, EventArgs e)
        {
            float.TryParse(amountField.Text, out float conversion);
            if (GoalToEdit != null)
            {
                GoalToEdit.Title = titleField.Text;
                GoalToEdit.Description = descriptionField.Text;
                GoalToEdit.Amount = conversion;
                await App.Database.SaveItemAsync(GoalToEdit);
            }
            else
            {
                UserGoal item = new UserGoal
                {
                    Title = titleField.Text,
                    Description = descriptionField.Text,
                    Amount = conversion
                };

                await App.Database.SaveItemAsync(item);
                SummaryPage.UserGoalData.Add(item);
            }


            await Navigation.PopAsync();
        }

        //TODO: Seperate AddGoalPage and UpdateGoalPage to avoid this logic?
        private UserGoal GoalToEdit { set; get; }  
    }
}
