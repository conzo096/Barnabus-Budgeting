using System;
using System.Collections.Generic;
using System.Text;

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

        public static T Previous<T>(this T src) where T : struct
        {
            if (!typeof(T).IsEnum) throw new ArgumentException(String.Format("Argument {0} is not an Enum", typeof(T).FullName));

            T[] Arr = (T[])Enum.GetValues(src.GetType());
            int j = Array.IndexOf<T>(Arr, src) - 1;
            return (j < 0) ? Arr[Arr.Length-1] : Arr[j];
        }
    }

    static public class SummaryPageSwipeManagement
    {
        public enum SwipeOrder { GOAL = 0, TRANSACTIONS = 1 };

        static public SwipeOrder CurrentSwipe { set; get; } = SwipeOrder.GOAL;
    }
}
