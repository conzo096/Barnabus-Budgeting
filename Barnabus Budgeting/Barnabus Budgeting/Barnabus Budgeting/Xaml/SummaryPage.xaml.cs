using Barnabus_Budgeting.Backend;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Barnabus_Budgeting
{
    using SwipeManager = SummaryPageSwipeManagement;

    public partial class SummaryPage : ContentPage
    {
        public SummaryPage()
        {
            InitializeComponent();

            mainLayout.Children.Add(new UserGoalsView());
        }

        private void OnSwipeLeft(object sender, EventArgs e)
        {
            SwipeManager.CurrentSwipe = SwipeManager.CurrentSwipe.Next();
            ChangeView();
        }

        private void OnSwipeRight(object sender, EventArgs e)
        {
            SwipeManager.CurrentSwipe = SwipeManager.CurrentSwipe.Previous();
            ChangeView();
        }

        private void ChangeView()
        {
            mainLayout.Children.RemoveAt(mainLayout.Children.Count - 1);
            switch (SwipeManager.CurrentSwipe)
            {
                case SwipeManager.SwipeOrder.GOAL:
                    mainLayout.Children.Add(new UserGoalsView());
                    break;
                case SwipeManager.SwipeOrder.TRANSACTIONS:
                    mainLayout.Children.Add(new UserTransactionsView());
                    break;
            };
        }
    }
}
