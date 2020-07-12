using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Barnabus_Budgeting
{
    public class SummaryCarouselDataTemplateSelector : DataTemplateSelector
    {
        public enum SummaryType { GOAL = 0, TRANSACTIONS = 1 };

        public SummaryCarouselDataTemplateSelector()
        {
            UserGoalsTemplate = new DataTemplate(typeof(UserGoalsView));
            UserTransactionsTemplate = new DataTemplate(typeof(UserExpensesView));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var summary = (SummaryType) item;
            switch (summary)
            {
                case SummaryType.GOAL:
                    return UserGoalsTemplate;
                case SummaryType.TRANSACTIONS:
                    return UserTransactionsTemplate;
            }

            // Not ideal but will work for now.
            return UserGoalsTemplate;
        }


        public DataTemplate UserGoalsTemplate { get; set; }
        public DataTemplate UserTransactionsTemplate { get; set; }
    }
}
