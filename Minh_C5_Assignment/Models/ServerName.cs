using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Minh_C5_Assignment
{
    class ServerName
    {
        public string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged();
            }
        }

        public string _Catalog;
        public string Catalog
        {
            get { return _Catalog; }
            set
            {
                _Catalog = value;
                OnPropertyChanged();
            }
        }

        public bool _Status;
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

        public ServerName() { }
        public ServerName( string name, string catalog, bool status)
        {
            this.Name = name;
            this.Catalog = catalog;
            this.Status = status;
        }
    }
}
