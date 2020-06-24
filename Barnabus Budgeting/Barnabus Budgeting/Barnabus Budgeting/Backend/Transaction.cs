namespace Barnabus_Budgeting.Backend
{
    public class Transaction : DatabaseItem
    {
        public enum TransactionType
        {
            Income,
            Expense
        }

        public string Description { set; get; }
        public float Amount { set; get; }
        public TransactionType Type { set; get; }
    }
}
