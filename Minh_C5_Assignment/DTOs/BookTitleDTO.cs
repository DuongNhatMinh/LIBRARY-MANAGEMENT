using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Minh_C5_Assignment
{
    class BookTitleDTO : INotifyPropertyChanged
    {
        public string _Id;
        public string _CategoryDTO;
        public string _Name;
        public string _Summary;

        public string Id
        {
            get { return _Id; }
            set
            {
                _Id = value;
                OnPropertyChanged();
            }
        }
        public string CategoryDTO
        {
            get { return _CategoryDTO; }
            set
            {
                _CategoryDTO = value;
                OnPropertyChanged();
            }
        }
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged();
            }
        }
        public string Summary
        {
            get { return _Summary; }
            set
            {
                _Summary = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public BookTitleDTO() { }

        public BookTitleDTO(string id, string category, string name, string summary)
        {
            this.Id = id;
            this.CategoryDTO = category;
            this.Name = name;
            this.Summary = summary;
        }
    }
}
