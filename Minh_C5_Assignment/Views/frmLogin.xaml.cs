using System.Windows;
using System.Windows.Input;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for frmLogin.xaml
    /// </summary>
    public partial class frmLogin : Window
    {
        UserViewModel userVM { get; set; }
        RoleViewModel roleVM { get; set; }
        UserRoleViewModel userroleVM { get; set; }
        public frmLogin()
        {
            InitializeComponent();
            userVM = new UserViewModel();
            roleVM = new RoleViewModel();
            userroleVM = new UserRoleViewModel();
        }

        private void Login()
        {
            User user = userVM.repoUser.GetByUserPass(txtUsername.Text, pwbPassword.Password);
            if(user == null)
            {
                MessageBox.Show("Account does not exist");
                return;
            }
            UserRole userrole = userroleVM.repoUserRole.GetByIdUser(user.Id);
            if(userrole == null)
            {
                MessageBox.Show("Account does not Role");
                return;
            }
            Role role = roleVM.repoRole.GetByID(userrole.IdRole);
            if(role.Group == "administration")
            {
                frmMenuAdmin menuAdmin = new frmMenuAdmin();
                menuAdmin.Show();
                this.Close();
            } 
            else if(role.Group == "librarian")
            {
                frmMenuMain menumain = new frmMenuMain(user);
                menumain.Show();
                this.Close();
            }
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Login();
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Login();
        }
    }
}
