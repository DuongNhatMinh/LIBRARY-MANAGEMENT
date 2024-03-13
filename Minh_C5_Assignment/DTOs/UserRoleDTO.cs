using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Minh_C5_Assignment
{
    class UserRoleDTO : INotifyPropertyChanged
    {
        private string _Id;
        public string Id
        {
            get { return _Id; }
            set
            {
                _Id = value;
                OnPropertyChanged();
            }
        }
        private string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set
            {
                _UserName = value;
                OnPropertyChanged();
            }
        }
        private string _Password;
        public string Password
        {
            get { return _Password; }
            set
            {
                _Password = value;
                OnPropertyChanged();
            }
        }

        private string _RoleName;
        public string RoleName
        {
            get { return _RoleName; }
            set
            {
                _RoleName = value;
                OnPropertyChanged();
            }
        }

        private bool _Status;
        public bool Status
        {
            get { return _Status; }
            set
            {
                _Status = value;
                OnPropertyChanged();
            }
        }
        private DateTime _CreatedAt;
        public DateTime CreatedAt
        {
            get { return _CreatedAt; }
            set
            {
                _CreatedAt = value;
                OnPropertyChanged();
            }
        }
        private DateTime _ModifitedAt;
        public DateTime ModifitedAt
        {
            get { return _ModifitedAt; }
            set
            {
                _ModifitedAt = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public UserRoleDTO() { }

        public UserRoleDTO(string id, string username, string password, string rolename, bool status, DateTime createdAt, DateTime modifitedAt)
        {
            this.Id = id;
            this.UserName = username;
            this.Password = password;
            this.RoleName = rolename;
            this.Status = status;
            this.CreatedAt = createdAt;
            this.ModifitedAt = modifitedAt;
        }
    }
}
