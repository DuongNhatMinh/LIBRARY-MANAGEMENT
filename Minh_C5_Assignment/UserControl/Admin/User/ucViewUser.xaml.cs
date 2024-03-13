using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ucViewUser.xaml
    /// </summary>
    public partial class ucViewUser : UserControl
    {
        UserViewModel userVM = new UserViewModel();
        UserInforViewModel userinforVM = new UserInforViewModel();
        RoleViewModel roleVM = new RoleViewModel();
        UserRoleViewModel userroleVM = new UserRoleViewModel();

        private PaginationViewModel<User> _PaginationVM;

        public ucViewUser()
        {
            InitializeComponent();
            _PaginationVM = new PaginationViewModel<User>(userVM.repoUser.Items);
            DataContext = _PaginationVM;
            _PaginationVM.SelectedButton = pagination.btnOne;
        }

        private void btnDetail_Click(object sender, RoutedEventArgs e)
        {
            var infor = userinforVM.repoUserInfo.GetByID(userVM.repoUser.Items[dtgUser.SelectedIndex].Id);
            ucUserInfor ucuserInfor = new ucUserInfor(infor);
            WindowMessege window = new WindowMessege();
            window.grid.Children.Add(ucuserInfor);
            window.ShowDialog();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as Button).DataContext as User;
            UserRole userrole = userroleVM.repoUserRole.GetByIdUser(item.Id);
            Role role = roleVM.repoRole.GetByID(userrole.IdRole);
            if (role.Group == "administration")
                return;
            if (item.Status == false)
            {
                userVM.UnLock(dtgUser.SelectedIndex);
                userVM.repoUser.Items[dtgUser.SelectedIndex].Status = true;
                _PaginationVM.GotoFirstPage(userVM.repoUser.Items);
            }
            else
            {
                userVM.Lock(item, dtgUser.SelectedIndex);
                userVM.repoUser.Items[dtgUser.SelectedIndex].Status = false;
                _PaginationVM.GotoFirstPage(userVM.repoUser.Items);
            }
        }
        
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as Button).DataContext as User;
            UserInfo userInfo = userinforVM.repoUserInfo.GetByID(item.Id);
            ucEditUser ucEdit = new ucEditUser(item, userInfo, dtgUser.SelectedIndex);
            WindowMessege window = new WindowMessege();
            window.grid.Children.Add(ucEdit);
            window.ShowDialog();
            item.Username = ucEdit.txtUserName.Text;
            item.Password = ucEdit.txtPassword.Text;
            item.ModifiedAt = DateTime.Now;
            userInfo.LName = ucEdit.txtLName.Text;
            userInfo.FName = ucEdit.txtFName.Text;
            userInfo.Phone = ucEdit.txtPhone.Text;
            userInfo.Address = ucEdit.txtAddress.Text;
            _PaginationVM.GotoFirstPage(userVM.repoUser.Items);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowMessege mess = new WindowMessege();
            mess.grid.Children.Add(new ucAddUser());
            mess.Show();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(txtSearch.Text == string.Empty)
            {
                _PaginationVM.GotoFirstPage(userVM.repoUser.Items);
                return;
            }
            _PaginationVM.LstItem.Clear();

            foreach(var item in userVM.repoUser.Items)
            {
                if(item.Id.ToLower().Contains(txtSearch.Text.ToLower()))
                {
                    _PaginationVM.LstItem.Add(item);
                }
                else if(item.Username.ToLower().Contains(txtSearch.Text.ToLower()))
                {
                    _PaginationVM.LstItem.Add(item);
                }
                else if (item.Password.ToLower().Contains(txtSearch.Text.ToLower()))
                {
                    _PaginationVM.LstItem.Add(item);
                }
                else if (item.CreatedAt.ToString("dd/MM/yyyy").Contains(txtSearch.Text))
                {
                    _PaginationVM.LstItem.Add(item);
                }
                else if (item.ModifiedAt.ToString("dd/MM/yyyy").Contains(txtSearch.Text))
                {
                    _PaginationVM.LstItem.Add(item);
                }
            }
        }

        private void dtgUser_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            var row = e.Row;
            var person = row.DataContext as User;
            if (person.Status == false)
            {
                row.Background = new SolidColorBrush(Colors.Red);
            }
        }
    }
}
