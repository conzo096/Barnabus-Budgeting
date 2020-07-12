using Barnabus_Budgeting.Backend;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Barnabus_Budgeting
{
    public partial class SummaryPage : ContentPage
    {
        public SummaryPage()
        {

            fields.Add(SummaryTypes.GOAL);
            fields.Add(SummaryTypes.TRANSACTIONS);

            InitializeComponent();
        }

        public enum SummaryTypes { GOAL = 0, TRANSACTIONS = 1 };

        public static List<SummaryTypes> fields = new List<SummaryTypes>();
    }
}
