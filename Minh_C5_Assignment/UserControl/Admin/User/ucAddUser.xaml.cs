using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ucAddUser.xaml
    /// </summary>
    public partial class ucAddUser : UserControl
    {
        UserViewModel userVM = new UserViewModel();
        UserInforViewModel userinfoVM = new UserInforViewModel();
        bool check = true;
        int length = 0;
        public ucAddUser()
        {
            InitializeComponent();
        }

        private void ClearTextBox()
        {
            txtUserName.Clear();
            txtPassword.Clear();
            txtLName.Clear();
            txtFName.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            lbPhone.Content = "Phone:";
            txtLName.Focus();
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
            foreach(var item in userVM.repoUser.Items)
            {
                if (txtUserName.Text == item.Username)
                    return true;
            }
            return false;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearTextBox();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (isEmpty())
            {
                MessageBox.Show("Text box is not left empty!", "Notify", MessageBoxButton.OK);
                return;
            }
            if (isExist())
            {
                MessageBox.Show("Account is Exist!", "Notify", MessageBoxButton.OK);
                return;
            }
            userVM.Add(txtUserName.Text, txtPassword.Text);
            userinfoVM.Add(txtLName.Text, txtFName.Text, txtAddress.Text, txtPhone.Text);
            ClearTextBox();
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

        private void txtLName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text != null && char.IsDigit(e.Text[0]))
            {
                e.Handled = true;
            }
        }
    }
}
