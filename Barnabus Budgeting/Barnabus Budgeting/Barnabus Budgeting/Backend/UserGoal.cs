// Represents an object.

using SQLite;
using System;

namespace Barnabus_Budgeting.Backend
{
    public class UserGoal
    {
        public UserGoal()
        {
        }

        public UserGoal(string title, string description)
        {
            Title = title;
            Description = description;
        }

        [PrimaryKey, AutoIncrement]
        public int ID { set; get; }
        public string Title { set; get; }
        public string Description { set; get; }
        public float Amount { set; get; }      
    }
}
