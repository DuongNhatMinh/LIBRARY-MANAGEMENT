using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Minh_C5_Assignment
{
    class BookISBNDTO : INotifyPropertyChanged
    {
        public string _ISBN;
        public string _BookTitleDTO;
        public string _AuthorDTO;
        public string _Language;
        public int _Quantity;
        public bool _Status;


        public string ISBN
        {
            get { return _ISBN; }
            set
            {
                _ISBN = value;
                OnPropertyChanged();
            }
        }
        public string BookTitleDTO
        {
            get { return _BookTitleDTO; }
            set
            {
                _BookTitleDTO = value;
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
        public string Language
        {
            get { return _Language; }
            set
            {
                _Language = value;
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
        public bool Status
        {
            get { return _Status; }
            set
            {
                _Status = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public BookISBNDTO() { }

        public BookISBNDTO(string isbn, string BookTitle, string Author, string language, int quantity, bool status)
        {
            this.ISBN = isbn;
            this.BookTitleDTO = BookTitle;
            this.AuthorDTO = Author;
            this.Language = language;
            this.Quantity = quantity;
            this.Status = status;
        }
    }
}
