using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Barnabus_Budgeting
{
    public class SummaryCarouselDataTemplateSelector : DataTemplateSelector
    {
        public SummaryCarouselDataTemplateSelector()
        {
            UserGoalsTemplate = new DataTemplate(typeof(UserGoalsView));
            UserTransactionsTemplate = new DataTemplate(typeof(UserExpensesView));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var summary = (SummaryPage.SummaryTypes) item;
            switch (summary)
            {
                case SummaryPage.SummaryTypes.GOAL:
                    return UserGoalsTemplate;
                case SummaryPage.SummaryTypes.TRANSACTIONS:
                    return UserTransactionsTemplate;
            }

            // Not ideal but will work for now.
            return UserGoalsTemplate;
        }


        public DataTemplate UserGoalsTemplate { get; set; }
        public DataTemplate UserTransactionsTemplate { get; set; }
    }
}
