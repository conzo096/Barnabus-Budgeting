using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Barnabus_Budgeting
{
    public class SummaryCarouselDataTemplateSelector : DataTemplateSelector
    {
        public enum SummaryType { GOAL = 0, INCOME = 1, EXPENSE = 2 };

        public SummaryCarouselDataTemplateSelector()
        {
            UserGoalsTemplate = new DataTemplate(typeof(UserGoalsView));
            UserIncomeTemplate = new DataTemplate(typeof(UserIncomeView));
            UserExpenseTemplate = new DataTemplate(typeof(UserExpensesView));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var summary = (SummaryType) item;
            switch (summary)
            {
                case SummaryType.GOAL:
                    return UserGoalsTemplate;
                case SummaryType.INCOME:
                    return UserIncomeTemplate;
                case SummaryType.EXPENSE:
                    return UserExpenseTemplate;
            }

            // Not ideal but will work for now.
            return UserGoalsTemplate;
        }


        public DataTemplate UserGoalsTemplate { get; set; }
        public DataTemplate UserIncomeTemplate { get; set; }
        public DataTemplate UserExpenseTemplate { get; set; }
    }
}
