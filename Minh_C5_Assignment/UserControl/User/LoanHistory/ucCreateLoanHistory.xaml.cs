using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ucCreateLoanHistory.xaml
    /// </summary>
    public partial class ucCreateLoanHistory : UserControl
    {
        LoanViewModel loanVM = new LoanViewModel();
        LoanDetailViewModel loandetailVM = new LoanDetailViewModel();
        LoanHistoryViewModel loanhistoryVM = new LoanHistoryViewModel();
        LoanDetailHistoryViewModel loandetailhistoryVM = new LoanDetailHistoryViewModel();
        BookViewModel bookVM = new BookViewModel();
        BookISBNViewModel bookISBNVM = new BookISBNViewModel();
        BookTitleViewModel bookTitleVM = new BookTitleViewModel();
        AuthorViewModel authorVM = new AuthorViewModel();
        CategoryViewModel categoryVM = new CategoryViewModel();
        TranslatorViewModel translatorVM = new TranslatorViewModel();
        PublisherViewModel publisherVM = new PublisherViewModel();
        ReaderViewModel readerVM = new ReaderViewModel();
        UserInforViewModel userinfoVM = new UserInforViewModel();
        ObservableCollection<BookDTO> lstbookDTO = new ObservableCollection<BookDTO>();
        BookStatusViewModel bookStatusVM = new BookStatusViewModel();
        LoanSlip Loan = new LoanSlip();
        List<LoanDetail> lstloandetail = new List<LoanDetail>();
        List<LoanDetailHistory> lstloandetailhistory = new List<LoanDetailHistory>();
        List<BookDTO> bookDTO = new List<BookDTO>();
        decimal finemoney, finemoney2, paymoney;

        public ucCreateLoanHistory()
        {
            InitializeComponent();

            foreach (var item in readerVM.repoReader.Items)
            {
                cbReaderID.Items.Add(item.Id);
            }

            foreach (var item in bookStatusVM.repoBookStatus.Items)
            {
                cbpenalty.Items.Add(item.Name);
            }
        }

        private void cbReaderID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbReaderID.SelectedIndex == -1)
                return;
            Reader reader = readerVM.repoReader.GetById(cbReaderID.Items[cbReaderID.SelectedIndex].ToString());
            string name = string.Format("Name: {0} {1}", reader.LName, reader.FName);
            lbname.Text = name;
            lbStatus.Text = "Status: Activate";
            if (reader.ReaderType == true)
                lbtype.Text = "Type: Adult";
            else
                lbtype.Text = "Type: Child";
            dtgBook.ItemsSource = null;
            DisplayLoan(reader);
        }

        private void DisplayLoan(Reader reader)
        {
            dtgloan.ItemsSource = null;
            List<LoanSlip> lstloan = loanVM.repoLoan.GetListByIDReader(reader.Id);
            dtgloan.ItemsSource = lstloan;
        }

        private void dtgloan_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            var row = e.Row;
            var detail = row.DataContext as LoanSlip;
            if (detail.ExpDate < DateTime.Now)
            {
                row.Background = new SolidColorBrush(Colors.Red);
            }
        }

        private void dtgloan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           Loan = ((DataGrid)sender).SelectedItem as LoanSlip;
            if (Loan == null)
                return;
            lstbookDTO = new ObservableCollection<BookDTO>();
            BookDTO bookDTO = null;
            lstloandetail = loandetailVM.repoLoanDetail.GetListByIdLoan(Loan.Id);
            foreach (var item2 in lstloandetail)
            {
                Book book = bookVM.repoBook.GetById(item2.IdBook);
                BookISBN bookISBN = bookISBNVM.repoBookISBN.GetByISBN(book.ISBN);
                BookTitle booktitle = bookTitleVM.repoBookTitle.GetByID(bookISBN.IdBookTitle);
                Author author = authorVM.repoAuthor.GetByID(bookISBN.IdAuthor);
                Translator translator = translatorVM.repoTranslator.GetByID(book.IdTranslator);
                Publisher publisher = publisherVM.repoPublisher.GetByID(book.IdPublisher);
                bookDTO = new BookDTO(book.Id, book.ISBN, booktitle.Name, author.Name, translator.Name,
                       bookISBN.OriginLanguage, publisher.Name, book.Price, book.PriceCurrent,
                       book.PublishDate, book.CreatedAt, book.ModifiedAt, book.Status);
                lstbookDTO.Add(bookDTO);
            }
            dtgBook.ItemsSource = lstbookDTO;
            DateTime now = DateTime.Now;
            TimeSpan ts = now - Loan.ExpDate;
            int days;
            if (ts.Days < 0)
                days = 0;
            else
                days = Math.Abs(ts.Days);
            tbldate.Text = string.Format("Date: {0}", days);
            if(days != 0)
                finemoney = days * decimal.Parse("5.000");
            tblfinemoney.Text = string.Format("FineMoneyExpDate: {0}", finemoney);
            tblloanpaid.Text = string.Format("LoanPaid: {0}", Loan.LoanPaid);
            tbldeposit.Text = string.Format("Deposit: {0}", Loan.Deposit);
            paymoney = finemoney + Loan.LoanPaid;
            tblpaymoney.Text = string.Format("PayMoney: {0}", paymoney);
            tblfinemoney2.Text = string.Format("FineMoney:");
        }

        private void Clear()
        {
            cbReaderID.SelectedIndex = -1;
            cbpenalty.SelectedIndex = -1;
            txtFineMoney.Text = string.Empty;
            dtgloan.ItemsSource = null;
            dtgBook.ItemsSource = null;
            lbname.Text = "Name:";
            lbStatus.Text = "Status:";
            lbtype.Text = "Type:";
            tbldate.Text = string.Format("Date:");
            tblfinemoney.Text = string.Format("FineMoneyExpDate:");
            tblloanpaid.Text = string.Format("LoanPaid:");
            tbldeposit.Text = string.Format("Deposit:");
            tblfinemoney2.Text = string.Format("FineMoney:");
            tblpaymoney.Text = string.Format("PayMoney:");
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            var loanhistory = new LoanHistory()
            {
                Id = RepositoryLoanHistory.GetNewID(),
                IdUser = Loan.IdUser,
                IdReader = Loan.IdReader,
                Quantity = Loan.Quantity,
                LoanDate = Loan.LoanDate,
                ExpDate = Loan.ExpDate,
                LoanPaid = Loan.LoanPaid,
                Deposit = Loan.Deposit,
                FineMoney = finemoney + finemoney2,
                Total = paymoney,
                CreateAt = DateTime.Now
            };
            int num = loandetailhistoryVM.repoLoanDetailHistory.GetLast();
            foreach (var item2 in lstloandetail)
            {
                string idldt = "LDTH";
                num += 1;
                if (num <= 9)
                    idldt += "0" + num;
                else
                    idldt += num;
                var loandetailhistory = new LoanDetailHistory()
                {
                    Id = idldt,
                    IdLoanHistory = RepositoryLoanHistory.GetNewID(),
                    IdBook = item2.IdBook,
                    ExpDate = item2.ExpDate,
                    PaidMoney = (Loan.LoanPaid / lstloandetail.Count)
                };
                lstloandetailhistory.Add(loandetailhistory);
                loandetailVM.repoLoanDetail.Delete(item2);
            }
            loanVM.repoLoan.Delete(Loan);

            loanhistoryVM.AddLoanHistory(loanhistory);
            foreach(var item in lstloandetailhistory)
            {
                loandetailhistoryVM.AddLoanDetailHistory(item);
                bookVM.repoBook.UpdateStatusByID(1, item.IdBook);
            }
            foreach(var item in bookDTO)
            {
                if(item.Note == "BS2")
                {
                    bookVM.repoBook.UpdateIdBookStatusByID(item.Note, item.Id);
                    bookVM.repoBook.UpdateStatusByID(0, item.Id);
                }
                else if(item.Note == "BS3")
                {
                    bookVM.repoBook.UpdateIdBookStatusByID(item.Note, item.Id);
                    bookVM.repoBook.UpdateStatusByID(1, item.Id);
                }
                else
                {
                    bookVM.repoBook.UpdateIdBookStatusByID(item.Note, item.Id);
                    bookVM.repoBook.UpdateStatusByID(1, item.Id);
                }
            }
            MessageBox.Show("Thanh Toán và Trả Sách Thành Công!");
            Clear();
            grid.Children.Add(new ucViewLoanHistory());
        }

        private void dtgBook_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbpenalty.SelectedIndex = -1;
            BookDTO tempItems = ((DataGrid)sender).SelectedItem as BookDTO;
            if (tempItems == null)
                return;
            foreach(var item in bookDTO)
            {
                if(tempItems.Id == item.Id)
                {
                    cbpenalty.SelectedIndex = item.Index;
                }
            }
        }

        private bool IsExist(BookDTO tempItems)
        {
            foreach (var item in bookDTO)
            {
                if (tempItems.Id == item.Id)
                {
                    return true;
                }
            }
            return false;
        }

        private void cbpenalty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbpenalty.SelectedIndex == -1)
                return;
            BookStatu penalty = bookStatusVM.repoBookStatus.GetByName(cbpenalty.Items[cbpenalty.SelectedIndex].ToString());
            BookDTO booktemp = dtgBook.Items[dtgBook.SelectedIndex] as BookDTO;
            if (penalty.Id == "BS2")
            {
                txtFineMoney.Text = booktemp.PriceCurrent.ToString();
                finemoney2 = decimal.Parse(txtFineMoney.Text);
                tblfinemoney2.Text = string.Format("FineMoney: {0}", finemoney2);
                paymoney += finemoney2;
                tblpaymoney.Text = string.Format("PayMoney: {0}", paymoney);
            }
            else
            {
                txtFineMoney.Text = "0.000";
                finemoney2 = decimal.Parse(txtFineMoney.Text);
                tblfinemoney2.Text = string.Format("FineMoney: {0}", finemoney2);
                paymoney += finemoney2;
                tblpaymoney.Text = string.Format("PayMoney: {0}", paymoney);
            }
            if (!IsExist(booktemp))
            {
                BookDTO booktemp2 = new BookDTO(booktemp.Id, penalty.Id, cbpenalty.SelectedIndex);
                bookDTO.Add(booktemp2);
            }
        }
    }
}
