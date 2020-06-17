// Represents an object.

using System;
using System.Collections.Generic;
using System.Text;

namespace Barnabus_Budgeting.Backend
{
    public class MoneyItem
    {
        public MoneyItem()
        {
        }

        public MoneyItem(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public string Title { set; get; }
        public string Description { set; get; }
        public DateTime Start { set; get; }
        public DateTime End { set; get; }
        public float Amount { set; get; }      
    }
}
