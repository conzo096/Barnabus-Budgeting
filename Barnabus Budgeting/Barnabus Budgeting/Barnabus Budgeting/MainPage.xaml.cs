using Barnabus_Budgeting.Backend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Barnabus_Budgeting
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            // Define some data.
            List<MoneyItem> data = new List<MoneyItem>
            {
                new MoneyItem("Monday","A"),
                new MoneyItem("Tuesday","A"),
                new MoneyItem("Wednesday","A"),
                new MoneyItem("Thursday","A"),
                new MoneyItem("Friday","A"),
                new MoneyItem("Saturday","A"),
                new MoneyItem("Sunday","A")
            };

            weekView.ItemsSource = data;
        }
    }
}
