using System.ComponentModel;

namespace Barnabus_Budgeting.Backend
{
    public class ExpenseTransaction : Transaction
    {
    }

    public class IncomeTransaction : Transaction
    {
    }

    public class Transaction : DatabaseItem, INotifyPropertyChanged
    {
        public Transaction()
        {
        }

        private string _description;
        public string Description
        {
            set
            {
                _description = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Description"));
            }
            get
            {
                return _description;
            }
        }

        private float _amount;
        public float Amount
        {
            set
            {
                _amount = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Amount"));
            }
            get
            {
                return _amount;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
