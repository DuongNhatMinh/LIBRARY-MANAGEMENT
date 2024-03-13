using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Minh_C5_Assignment
{
    class BookDTO : INotifyPropertyChanged
    {
        public int _Id;
        public string _ISBN;
        public string _NameDTO;
        public string _AuthorDTO;
        public string _TranlatorDTO;
        public string _LanguageDTO;
        public string _Publisher;
        public decimal _Price;
        public decimal _PriceCurrent;
        public DateTime _PublishDate;
        public DateTime _CreatedAt;
        public DateTime _ModifitedAt;
        public bool _Status;
        public string _Note;
        public int _Index;

        public int Id
        {
            get { return _Id; }
            set
            {
                _Id = value;
                OnPropertyChanged();
            }
        }

        public string ISBN
        {
            get { return _ISBN; }
            set
            {
                _ISBN = value;
                OnPropertyChanged();
            }
        }

        public string NameDTO
        {
            get { return _NameDTO; }
            set
            {
                _NameDTO = value;
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
        public DateTime CreatedAt
        {
            get { return _CreatedAt; }
            set
            {
                _CreatedAt = value;
                OnPropertyChanged();
            }
        }
        public DateTime ModifitedAt
        {
            get { return _ModifitedAt; }
            set
            {
                _ModifitedAt = value;
                OnPropertyChanged();
            }
        }
        public bool Status
        {
            get { return _Status; }
            set
            {
                _Status = value;
                OnPropertyChanged();
            }
        }

        public string Publisher
        {
            get { return _Publisher; }
            set
            {
                _Publisher = value;
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

        public decimal PriceCurrent
        {
            get { return _PriceCurrent; }
            set
            {
                _PriceCurrent = value;
                OnPropertyChanged();
            }
        }

        public DateTime PublishDate
        {
            get { return _PublishDate; }
            set
            {
                _PublishDate = value;
                OnPropertyChanged();
            }
        }

        public string Note
        {
            get { return _Note; }
            set
            {
                _Note = value;
                OnPropertyChanged();
            }
        }

        public int Index
        {
            get { return _Index; }
            set
            {
                _Index = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public BookDTO() { }

        public BookDTO(int id, string isbn, string name, string author, string language, string publisher, decimal price, decimal pricecurrent, DateTime publishdate, DateTime createdAt, DateTime modifitedAt, bool status)
        {
            this.Id = id;
            this.ISBN = isbn;
            this.NameDTO = name;
            this.AuthorDTO = author;
            this.LanguageDTO = language;
            this.Publisher = publisher;
            this.PublishDate = publishdate;
            this.Price = price;
            this.PriceCurrent = pricecurrent;
            this.CreatedAt = createdAt;
            this.ModifitedAt = modifitedAt;
            this.Status = status;
        }

        public BookDTO(int id, string isbn, string name, string author, string tranlator, string language, string publisher, decimal price, decimal pricecurrent, DateTime publishdate, DateTime createdAt, DateTime modifitedAt, bool status)
        {
            this.Id = id;
            this.ISBN = isbn;
            this.NameDTO = name;
            this.AuthorDTO = author;
            this.TranlatorDTO = tranlator;
            this.LanguageDTO = language;
            this.Publisher = publisher;
            this.PublishDate = publishdate;
            this.Price = price;
            this.PriceCurrent = pricecurrent;
            this.CreatedAt = createdAt;
            this.ModifitedAt = modifitedAt;
            this.Status = status;
        }

        public BookDTO(int id, string note, int index)
        {
            this.Id = id;
            this.Note = note;
            this.Index = index;
        }
    }
}
