using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Minh_C5_Assignment
{
    class LoanDetailDTO : INotifyPropertyChanged
    {
        public string _Id;
        public string _IdLoan;
        public string _NameDTO;
        public string _AuthorDTO;
        public string _TranlatorDTO;
        public string _LanguageDTO;
        public decimal _Price;
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

        public string IdLoan
        {
            get { return _IdLoan; }
            set
            {
                _IdLoan = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get { return _NameDTO; }
            set
            {
                _NameDTO = value;
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

        public string AuthorDTO
        {
            get { return _AuthorDTO; }
            set
            {
                _AuthorDTO = value;
                OnPropertyChanged();
            }
        }

        public string TranlatorDTO
        {
            get { return _TranlatorDTO; }
            set
            {
                _TranlatorDTO = value;
                OnPropertyChanged();
            }
        }

        public string LanguageDTO
        {
            get { return _LanguageDTO; }
            set
            {
                _LanguageDTO = value;
                OnPropertyChanged();
            }
        }

        public decimal Price
        {
            get { return _Price; }
            set
            {
                _Price = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public LoanDetailDTO() { }

        public LoanDetailDTO(string id, string idloan, string name, string author, string tranlator, decimal price)
        {
            this.Id = id;
            this.IdLoan = idloan;
            this.Name = name;
            this.AuthorDTO = author;
            this.TranlatorDTO = tranlator;
            this.Price = price;
        }

        public LoanDetailDTO(string idloan, string name, DateTime loandate, DateTime expdate)
        {
            this.IdLoan = idloan;
            this.Name = name;
            this.LoanDate = loandate;
            this.ExpDate = expdate;
        }
    }
}
