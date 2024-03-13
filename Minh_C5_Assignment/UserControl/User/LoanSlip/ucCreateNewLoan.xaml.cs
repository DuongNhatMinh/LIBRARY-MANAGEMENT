using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ucCreateNewLoan.xaml
    /// </summary>
    public partial class ucCreateNewLoan : UserControl
    {
        ReaderViewModel readerVM = new ReaderViewModel();
        BookViewModel bookVM = new BookViewModel();
        BookISBNViewModel bookISBNVM = new BookISBNViewModel();
        BookTitleViewModel bookTitleVM = new BookTitleViewModel();
        TranslatorViewModel translatorVM = new TranslatorViewModel();
        PublisherViewModel publisherVM = new PublisherViewModel();
        UserInforViewModel userinfoVM = new UserInforViewModel();
        ObservableCollection<BookDTO> bookDTOs = new ObservableCollection<BookDTO>();
        List<LoanDetail> lstLoanDetail = new List<LoanDetail>();
        LoanViewModel loanVM = new LoanViewModel();
        LoanDetailViewModel loandetailVM = new LoanDetailViewModel();
        List<LoanDetailDTO> lstLoanDetaildto = new List<LoanDetailDTO>();
        ParameterViewModel paramenterVM = new ParameterViewModel();
        Reader reader { get; set; }
        User user { get; set; }
        decimal loanpaid = 0, Deposit = 0;

        public ucCreateNewLoan(object value, object value2, object value3)
        {
            InitializeComponent();
            reader = value as Reader;
            bookDTOs = value2 as ObservableCollection<BookDTO>;
            user = value3 as User;
            Init();
        }

        public void Init()
        {
            string id = string.Format("ID: {0}", reader.Id);
            string name = string.Format("Name: {0} {1}", reader.LName, reader.FName);

            lbid.Text = id;
            lbname.Text = name;
            if (reader.ReaderType == true)
                lbtype.Text = "Type: Adult";
            else
                lbtype.Text = "Type: Child";

            int num = loandetailVM.repoLoanDetail.GetLast();
            foreach (var item in bookDTOs)
            {
                Book book = bookVM.repoBook.GetById(item.Id);
                Parameter paramenter = paramenterVM.repoParameter.GetByID("QD10");
                loanpaid += decimal.Parse(paramenter.Value);
                paramenter = paramenterVM.repoParameter.GetByID("QD11");
                    //var value = decimal.Parse(paramenter.Value);
                Deposit += item.PriceCurrent * decimal.Parse("0.5");
                string idldt = "LDT";
                num += 1;
                if (num <= 9)
                    idldt += "0" + num;
                else
                    idldt += num;
                var loandetail = new LoanDetail()
                {
                    Id = idldt,
                    IdLoan = RepositoryLoan.GetNewID(),
                    IdBook = item.Id,
                    ExpDate = DateTime.Now.AddDays(7)
                };
                LoanDetailDTO loandetaildto = new LoanDetailDTO(idldt, RepositoryLoan.GetNewID(),
                            item.NameDTO, item.AuthorDTO, item.TranlatorDTO, item.PriceCurrent);
                lstLoanDetail.Add(loandetail);
                lstLoanDetaildto.Add(loandetaildto);
            }
            dtgDetailOrder.ItemsSource = lstLoanDetaildto;

            string idloan = string.Format("ID: {0}", RepositoryLoan.GetNewID());
            lbidloan.Text = idloan;
            string loandate = string.Format("LoanDate: {0}", DateTime.Now);
            lbloandate.Text = loandate;
            string expdate = string.Format("ExpDate: {0}", DateTime.Now.AddDays(7));
            lbexpdate.Text = expdate;
            string loanPaid = string.Format("LoanPaid: {0}", loanpaid);
            lbloanpaid.Text = loanPaid;
            string deposit = string.Format("Deposit: {0}", Deposit);
            lbdeposit.Text = deposit;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var loan = new LoanSlip()
            {
                Id = RepositoryLoan.GetNewID(),
                IdUser = user.Id,
                IdReader = reader.Id,
                Quantity = bookDTOs.Count,
                LoanDate = DateTime.Now,
                ExpDate = DateTime.Now.AddDays(7),
                LoanPaid = loanpaid,
                Deposit = Deposit
            };
            loanVM.repoLoan.Add(loan);

            foreach (var item in lstLoanDetail)
            {
                loandetailVM.repoLoanDetail.Add(item);
                bookVM.repoBook.UpdateStatusByID(0, item.IdBook);
            }

            MessageBox.Show("Order Book Successfully");
            grid.Children.Add(new ucViewLoan(user));
        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            grid.Children.Add(new ucDisplayLoanSlip(user));
        }
    }
}
