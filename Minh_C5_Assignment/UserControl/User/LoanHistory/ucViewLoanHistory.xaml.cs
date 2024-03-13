using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ucViewLoanHistory.xaml
    /// </summary>
    public partial class ucViewLoanHistory : UserControl
    {
        private PaginationViewModel<LoanHistoryDTO> _PaginationVM;
        LoanHistoryViewModel loanhistoryVM = new LoanHistoryViewModel();
        UserInforViewModel userinfoVM = new UserInforViewModel();
        ReaderViewModel readerVM = new ReaderViewModel();
        public ucViewLoanHistory()
        {
            InitializeComponent();
            Init();
        }

        private List<LoanHistoryDTO> GetListLoanHistoryDTO()
        {
            List<LoanHistory> lstloan = loanhistoryVM.repoLoanHistory.Items;
            List<LoanHistoryDTO> lstloanDTO = new List<LoanHistoryDTO>();
            LoanHistoryDTO loandto;
            foreach (var item in lstloan)
            {
                UserInfo user = userinfoVM.repoUserInfo.GetByID(item.IdUser);
                Reader reader = readerVM.repoReader.GetById(item.IdReader);

                string usertemp = string.Format("{0} {1}", user.LName, user.FName);
                string readertemp = string.Format("{0} {1}", reader.LName, reader.FName);
                loandto = new LoanHistoryDTO(item.Id, usertemp, readertemp, item.Quantity, item.LoanPaid, item.Deposit, item.LoanDate, item.ExpDate);
                lstloanDTO.Add(loandto);
            }
            return lstloanDTO;
        }

        private void Init()
        {
            _PaginationVM = new PaginationViewModel<LoanHistoryDTO>(GetListLoanHistoryDTO());
            DataContext = _PaginationVM;
            _PaginationVM.SelectedButton = pagination.btnOne;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            grid.Children.Add(new ucCreateLoanHistory());
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as Button).DataContext as LoanHistoryDTO;
            WindowMessege mess = new WindowMessege();
            mess.grid.Children.Add(new ucViewLoanDetailHistory(item));
            mess.Show();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSearch.Text == string.Empty)
            {
                _PaginationVM.GotoFirstPage(GetListLoanHistoryDTO());
                return;
            }
            _PaginationVM.LstItem.Clear();

            foreach (var item in GetListLoanHistoryDTO())
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
