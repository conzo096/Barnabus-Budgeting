// Represents an object.

using System.ComponentModel;

namespace Barnabus_Budgeting.Backend
{
    public class UserGoal : DatabaseItem, INotifyPropertyChanged
    {
        public UserGoal()
        {
        }

        public UserGoal(string title, string description)
        {
            Title = title;
            Description = description;
        }

        private string _title;
        public string Title {
            set
            {
                _title = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Title"));
            }
            get
            {
                return _title;
            }

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
