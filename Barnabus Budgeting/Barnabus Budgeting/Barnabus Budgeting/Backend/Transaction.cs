using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Barnabus_Budgeting.Backend
{
    public class Transaction
    {
        public enum TransactionType
        {
            Income,
            Expense
        }

        [PrimaryKey, AutoIncrement]
        public int ID { set; get; }
        public string Description { set; get; }
        public float Amount { set; get; }
        public TransactionType Type { set; get; }
    }
}
