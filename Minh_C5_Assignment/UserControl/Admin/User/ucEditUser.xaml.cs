using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ucEditUser.xaml
    /// </summary>
    public partial class ucEditUser : UserControl
    {
        User uSer = new User();
        UserInfo userInfo { get; set; }
        UserViewModel userVM = new UserViewModel();
        UserInforViewModel userInfoVM = new UserInforViewModel();
        bool check = true;
        int length = 0, Index = 0;
        public ucEditUser(object user, object userinfo, int index)
        {
            InitializeComponent();
            uSer = user as User;
            userInfo = userinfo as UserInfo;
            Index = index;
            SetData();
        }

        public void SetData()
        {
            txtUserName.Text = uSer.Username;
            txtPassword.Text = uSer.Password;
            txtLName.Text = userInfo.LName;
            txtFName.Text = userInfo.FName;
            txtAddress.Text = userInfo.Address;
            txtPhone.Text = userInfo.Phone;
        }

        public void ClearData()
        {
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtLName.Text = string.Empty;
            txtFName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPhone.Text = string.Empty;
        }

        private void txtPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (txtPhone.Text.Length == 10)
                return;
            if (e.Text != null && !char.IsDigit(e.Text[0]))
            {
                e.Handled = true;
            }
            else if (txtPhone.LineCount < 10)
            {
                if (check)
                {
                    lbPhone.Content += " - Not enough Phone 10 number!";
                    check = false;
                }
                length++;
            }
            if (length == 10)
            {
                lbPhone.Content = "Phone:";
                length = 0;
                check = true;
            }
        }

        private bool isEmpty()
        {
            if (txtLName.Text == string.Empty)
                return true;
            if (txtFName.Text == string.Empty)
                return true;
            if (txtAddress.Text == string.Empty)
                return true;
            if (txtPhone.Text == string.Empty)
                return true;
            if (txtUserName.Text == string.Empty)
                return true;
            if (txtPassword.Text == string.Empty)
                return true;
            return false;
        }

        private bool isExist()
        {
            foreach (var item in userVM.repoUser.Items)
            {
                if (txtUserName.Text == item.Username)
                    return true;
            }
            return false;
        }

        private void txtLName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text != null && char.IsDigit(e.Text[0]))
            {
                e.Handled = true;
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (isEmpty())
            {
                MessageBox.Show("Text box is not left empty!", "Notify", MessageBoxButton.OK);
                return;
            }
            //if (isExist())
            //{
            //    MessageBox.Show("Account is Exist!", "Notify", MessageBoxButton.OK);
            //    return;
            //}
            userVM.Edit(uSer, txtUserName.Text, txtPassword.Text, Index);
            userInfoVM.Edit(uSer, txtLName.Text, txtFName.Text, txtAddress.Text, txtPhone.Text, Index);
            MessageBox.Show("Edit User successfully!", "Notify", MessageBoxButton.OK);
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearData();
        }
    }
}
