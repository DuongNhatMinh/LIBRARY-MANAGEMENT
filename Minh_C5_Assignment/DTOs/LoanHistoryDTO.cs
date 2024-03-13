using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Minh_C5_Assignment
{
    class LoanHistoryDTO : INotifyPropertyChanged
    {
        public string _Id;
        public string _User;
        public string _Reader;
        public int _Quantity;
        public decimal _LoanPaid;
        public decimal _Deposit;
        public DateTime _LoanDate;
        public DateTime _ExpDate;

        public string Id
        {
            get { return _Id; }
            set
            {
                _Id = value;
                OnPropertyChanged();
            }
        }

        public string User
        {
            get { return _User; }
            set
            {
                _User = value;
                OnPropertyChanged();
            }
        }

        public string Reader
        {
            get { return _Reader; }
            set
            {
                _Reader = value;
                OnPropertyChanged();
            }
        }

        public DateTime LoanDate
        {
            get { return _LoanDate; }
            set
            {
                _LoanDate = value;
                OnPropertyChanged();
            }
        }

        public DateTime ExpDate
        {
            get { return _ExpDate; }
            set
            {
                _ExpDate = value;
                OnPropertyChanged();
            }
        }

        public decimal LoanPaid
        {
            get { return _LoanPaid; }
            set
            {
                _LoanPaid = value;
                OnPropertyChanged();
            }
        }

        public int Quantity
        {
            get { return _Quantity; }
            set
            {
                _Quantity = value;
                OnPropertyChanged();
            }
        }

        public decimal Deposit
        {
            get { return _Deposit; }
            set
            {
                _Deposit = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public LoanHistoryDTO() { }

        public LoanHistoryDTO(string id, string user, string reader, int quantity, decimal loanpaid, decimal deposit, DateTime loandate, DateTime expdate)
        {
            this.Id = id;
            this.User = user;
            this.Reader = reader;
            this.Quantity = quantity;
            this.LoanPaid = loanpaid;
            this.Deposit = deposit;
            this.LoanDate = loandate;
            this.ExpDate = expdate;
        }
    }
}
