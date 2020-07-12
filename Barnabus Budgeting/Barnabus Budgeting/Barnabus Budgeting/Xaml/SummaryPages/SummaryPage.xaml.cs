using Barnabus_Budgeting.Backend;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Barnabus_Budgeting
{
    using SummaryDataSelector = SummaryCarouselDataTemplateSelector;

    public partial class SummaryPage : ContentPage
    {
        public SummaryPage()
        {
            fields.Add(SummaryDataSelector.SummaryType.GOAL);
            fields.Add(SummaryDataSelector.SummaryType.INCOME);
            fields.Add(SummaryDataSelector.SummaryType.EXPENSE);

            InitializeComponent();
        }

        public static List<SummaryDataSelector.SummaryType> fields = new List<SummaryDataSelector.SummaryType>();
    }
}
