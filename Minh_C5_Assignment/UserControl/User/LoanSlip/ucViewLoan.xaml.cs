using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ucViewLoan.xaml
    /// </summary>
    public partial class ucViewLoan : UserControl
    {
        private PaginationViewModel<LoanDTO> _PaginationVM;
        LoanViewModel loanVM = new LoanViewModel();
        UserInforViewModel userinfoVM = new UserInforViewModel();
        ReaderViewModel readerVM = new ReaderViewModel();
        User user { get; set; }

        public ucViewLoan(object value)
        {
            InitializeComponent();
            user = value as User;
            Init();
        }

        private List<LoanDTO> GetListLoanDTO()
        {
            List<LoanSlip> lstloan = loanVM.repoLoan.Items;
            List<LoanDTO> lstloanDTO = new List<LoanDTO>();
            LoanDTO loandto;
            foreach (var item in lstloan)
            {
                UserInfo user = userinfoVM.repoUserInfo.GetByID(item.IdUser);
                Reader reader = readerVM.repoReader.GetById(item.IdReader);

                string usertemp = string.Format("{0} {1}", user.LName, user.FName);
                string readertemp = string.Format("{0} {1}", reader.LName, reader.FName);
                loandto = new LoanDTO(item.Id, usertemp, readertemp, item.Quantity, item.LoanPaid, item.Deposit, item.LoanDate, item.ExpDate);
                lstloanDTO.Add(loandto);
            }
            return lstloanDTO;
        }

        private void Init()
        {
            _PaginationVM = new PaginationViewModel<LoanDTO>(GetListLoanDTO());
            DataContext = _PaginationVM;
            _PaginationVM.SelectedButton = pagination.btnOne;
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as Button).DataContext as LoanDTO;
            WindowMessege mess = new WindowMessege();
            mess.grid.Children.Add(new ucViewLoanDetail(item));
            mess.Show();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            grid.Children.Add(new ucDisplayLoanSlip(user));
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSearch.Text == string.Empty)
            {
                _PaginationVM.GotoFirstPage(GetListLoanDTO());
                return;
            }
            _PaginationVM.LstItem.Clear();

            foreach (var item in GetListLoanDTO())
            {
                if (item.Id.ToLower().Contains(txtSearch.Text.ToLower()))
                {
                    _PaginationVM.LstItem.Add(item);
                }
                else if (item.User.ToLower().Contains(txtSearch.Text.ToLower()))
                {
                    _PaginationVM.LstItem.Add(item);
                }
                else if (item.Reader.ToLower().Contains(txtSearch.Text.ToLower()))
                {
                    _PaginationVM.LstItem.Add(item);
                }
                else if (item.Quantity.ToString().Contains(txtSearch.Text))
                {
                    _PaginationVM.LstItem.Add(item);
                }
                else if (item.LoanDate.ToString("dd/MM/yyyy").Contains(txtSearch.Text))
                {
                    _PaginationVM.LstItem.Add(item);
                }
                else if (item.ExpDate.ToString("dd/MM/yyyy").Contains(txtSearch.Text))
                {
                    _PaginationVM.LstItem.Add(item);
                }
            }
        }
    }
}
