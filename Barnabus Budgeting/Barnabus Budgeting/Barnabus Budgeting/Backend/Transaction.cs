﻿using System.ComponentModel;

namespace Barnabus_Budgeting.Backend
{
    public class Transaction : DatabaseItem, INotifyPropertyChanged
    {
        public enum TransactionType
        {
            Income,
            Expense
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

        private TransactionType _type;
        public TransactionType Type
        {
            set
            {
                _type = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Type"));
            }
            get
            {
                return _type;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
