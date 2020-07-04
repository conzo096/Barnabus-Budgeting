using Barnabus_Budgeting.Backend;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Barnabus_Budgeting
{
    public static class Extensions
    {
        public static T Next<T>(this T src) where T : struct
        {
            if (!typeof(T).IsEnum) throw new ArgumentException(String.Format("Argument {0} is not an Enum", typeof(T).FullName));

            T[] Arr = (T[])Enum.GetValues(src.GetType());
            int j = Array.IndexOf<T>(Arr, src) + 1;
            return (Arr.Length == j) ? Arr[0] : Arr[j];
        }
    }

    public enum SwipeOrder { GOAL = 0, TRANSACTIONS = 1};

    public partial class SummaryPage : ContentPage
    {
        public SummaryPage()
        {
            InitializeComponent();
            CurrentSwipe = SwipeOrder.GOAL;

            mainLayout.Children.Add(new UserGoalsView());
        }

        private void OnSwipeLeft(object sender, EventArgs e)
        {
            mainLayout.Children.RemoveAt(mainLayout.Children.Count - 1);

            CurrentSwipe = CurrentSwipe.Next();
            switch (CurrentSwipe)
            {
                case SwipeOrder.GOAL:
                    mainLayout.Children.Add(new UserGoalsView());
                    break;
                case SwipeOrder.TRANSACTIONS:
                    mainLayout.Children.Add(new UserTransactionsView());
                    break;
            };
        }

        public SwipeOrder CurrentSwipe { set; get; }
    }
}
