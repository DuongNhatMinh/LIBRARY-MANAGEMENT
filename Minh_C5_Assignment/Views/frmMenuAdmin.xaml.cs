using System.Windows;
using System.Windows.Controls;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for frmMenuAdmin.xaml
    /// </summary>
    public partial class frmMenuAdmin : Window
    {
        public frmMenuAdmin()
        {
            InitializeComponent();
        }

        public void SelectedUserControl(int option)
        {
            switch (option)
            {
                case 1:
                    this.Visibility = Visibility.Hidden;
                    frmLogin frmlogin = new frmLogin();
                    frmlogin.Show();
                    break;
                case 2:
                    grid.Children.Add(new ucViewUser());
                    break;
                case 3:
                    grid.Children.Add(new ucViewFunction());
                    break;
                case 4:
                    grid.Children.Add(new ucAddUser());
                    break;
                case 5:
                    grid.Children.Add(new ucSwitchRole());
                    break;
                case 6:
                    grid.Children.Add(new ucAddRole());
                    break;
                case 7:
                    grid.Children.Add(new ucSetFunctionForRole());
                    break;
                case 8:
                    grid.Children.Add(new ucViewParamenter());
                    break;
                case 9:
                    grid.Children.Add(new ucAddParameter());
                    break;
                case 10:
                    grid.Children.Add(new ucViewPenalty());
                    break;
                case 11:
                    grid.Children.Add(new ucAddPenalty());
                    break;
                case 12:
                    grid.Children.Add(new ucViewCategory());
                    break;
                case 13:
                    grid.Children.Add(new ucAddCategory());
                    break;
                case 14:
                    grid.Children.Add(new ucViewAuthor());
                    break;
                case 15:
                    grid.Children.Add(new ucAddAuthor());
                    break;
                case 16:
                    grid.Children.Add(new ucViewTranslator());
                    break;
                case 17:
                    grid.Children.Add(new ucAddTranslator());
                    break;
                case 18:
                    grid.Children.Add(new ucViewPublisher());
                    break;
                case 19:
                    grid.Children.Add(new ucAddPublisher());
                    break;
            }
        }

        private void ViewUser_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(2);
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(1);
        }

        private void ViewFunction_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(3);
        }

        private void AddUser_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(4);
        }

        private void RoleByFunction_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(7);
        }

        private void AddRole_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(6);
        }

        private void SwitchUserByRole_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(5);
        }

        private void AddPenslty_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(11);
        }

        private void viewPenalty_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(10);
        }

        private void viewParamenter_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(8);
        }

        private void AddParsmenter_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(9);
        }

        private void viewcategory_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(12);
        }

        private void addCategory_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(13);
        }

        private void viewauthor_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(14);
        }

        private void adđauthor_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(15);
        }

        private void viewtrans_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(16);
        }

        private void addtrans_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(17);
        }

        private void viewpublisher_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(18);
        }

        private void addpublisher_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(19);
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            var content = (((sender as RadioButton).Content as Grid).Children[1] as TextBlock).Text;

            switch (content)
            {
                case "User Management":
                    SelectedUserControl(2);
                    break;
                case "Function Management":
                    SelectedUserControl(3);
                    break;
                case "Set Function For Role":
                    SelectedUserControl(7);
                    break;
                case "Publisher Management":
                    SelectedUserControl(18);
                    break;
                case "Translator Management":
                    SelectedUserControl(16);
                    break;
                case "Author Management":
                    SelectedUserControl(14);
                    break;
                case "Category Management":
                    SelectedUserControl(12);
                    break;
                case "Parameter Management":
                    SelectedUserControl(8);
                    break;
                case "Penalty Reason Management":
                    SelectedUserControl(10);
                    break;
                case "Role Management":
                    SelectedUserControl(5);
                    break;
            }
        }
    }
}
