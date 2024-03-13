using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for frmMenuMain.xaml
    /// </summary>
    public partial class frmMenuMain : Window
    {
        User _user { get; set; }
        UserRoleViewModel userroleVM = new UserRoleViewModel();
        RoleFunctionViewModel rolefunctionVM = new RoleFunctionViewModel();
        RoleViewModel roleVM = new RoleViewModel();
        FunctionViewModel functionVM = new FunctionViewModel();
        List<string> lstid = new List<string>();

        public frmMenuMain(object user)
        {
            InitializeComponent();
            _user = user as User;
            SetFunction();
        }

        public void Check(string id)
        {
            UserRole userrole = userroleVM.repoUserRole.GetByIdUser(_user.Id);
            Role role = roleVM.repoRole.GetByID(userrole.IdRole);
            Function function = functionVM.repoFunction.getbyid(id);
            if (function.Status == false)
            {
                lstid.Add(id);
                return;
            }
            foreach (var item in rolefunctionVM.repoRoleFunction.Items)
            {
                if (item.IdRole == role.Id)
                {
                    if (id == item.IdFunction)
                        return;
                }
            }
            lstid.Add(id);
        }

        public void SetFunction()
        {
            foreach (var item in functionVM.repoFunction.Items)
            {
                if (item.Id != "F1" && item.Id != "F12" && item.Id != "F7")
                    if (item.IdParent != "F7" && item.IdParent != "F1" && item.IdParent != "F12")
                        Check(item.Id);
            }
            foreach (var item in lstid)
            {
                switch (item)
                {
                    case "F22":
                        ViewReader.Visibility = Visibility.Hidden;
                        break;
                    case "F23":
                        ViewReader.Visibility = Visibility.Hidden;
                        ViewReader.Visibility = Visibility.Hidden;
                        break;
                    case "F30":
                        ViewBookTitle.Visibility = Visibility.Hidden;
                        break;
                    case "F31":
                        ViewBookTitle.Visibility = Visibility.Hidden;
                        break;
                    case "F33":
                        ViewBookISBN.Visibility = Visibility.Hidden;
                        break;
                    case "F34":
                        ViewBookISBN.Visibility = Visibility.Hidden;
                        break;
                    case "F37":
                        Viewbook.Visibility = Visibility.Hidden;
                        break;
                    case "F38":
                        Viewbook.Visibility = Visibility.Hidden;
                        break;
                }
            }
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
                    //ucviewbookisbn = new ucViewBookISBN();
                    grid.Children.Add(new ucViewBookISBN());
                    break;
                case 3:
                    //ucAddAdult = new ucAddAdult();
                    grid.Children.Add(new ucAddAdult());
                    break;
                case 4:
                    //ucaddChild = new ucAddChild();
                    grid.Children.Add(new ucAddChild());
                    break;
                case 5:
                    //ucsearchReader = new ucSearchReader();
                    grid.Children.Add(new ucSearchReader());
                    break;
                case 6:
                    //ucviewBookTitle = new ucViewBookTitle();
                    grid.Children.Add(new ucViewBookTitle());
                    break;
                case 7:
                    //ucdisplay = new ucViewLoan(_user);
                    grid.Children.Add(new ucViewLoan(_user));
                    break;
                case 8:
                    //ucAddbookTitle = new ucAddBookTitle();
                    grid.Children.Add(new ucAddBookTitle());
                    break;
                case 9:
                    //ucaddBookISBN = new ucAddBookISBN();
                    grid.Children.Add(new ucAddBookISBN());
                    break;
                case 10:
                    //ucaddBook = new ucAddBook();
                    grid.Children.Add(new ucAddBook());
                    break;
                case 11:
                    //ucsearchBook = new ucSearchBook();
                    grid.Children.Add(new ucSearchBook());
                    break;
                case 12:
                    //ucloanhistory = new ucViewLoanHistory();
                    grid.Children.Add(new ucViewLoanHistory());
                    break;
                case 13:
                    grid.Children.Add(new ucStatictical());
                    break;
            }
        }

        private void ViewReader_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(5);
        }

        private void AddAdult_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(3);
        }

        private void AddChild_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(4);
        }

        private void ViewBook_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(2);
        }

        private void AddBookTitle_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(8);
        }

        private void AddBook_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(10);
        }

        private void SearchReader_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(5);
        }

        private void ViewBookTitle_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(6);
        }

        private void AddBookISBN_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(9);
        }

        private void Viewbook_Selected_1(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(11);
        }

        private void SearchBook_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(11);
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(1);
        }

        private void CreateLoanslip_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(7);
        }

        private void CreateLoanhistory_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(12);
        }

        private void TreeViewItem_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(13);
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            var content = (((sender as RadioButton).Content as Grid).Children[1] as TextBlock).Text;

            switch (content)
            {
                case "Statistical":
                    SelectedUserControl(13);
                    break;
                case "Reader Management":
                    SelectedUserControl(5);
                    break;
                case "BookISBN Management":
                    SelectedUserControl(2);
                    break;
                case "BookTitle Management":
                    SelectedUserControl(6);
                    break;
                case "Book Management":
                    SelectedUserControl(11);
                    break;
                case "Loan Management":
                    SelectedUserControl(7);
                    break;
                case "Loan History Management":
                    SelectedUserControl(12);
                    break;
            }
        }
    }
}
