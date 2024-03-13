﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ucViewLoanDetail.xaml
    /// </summary>
    public partial class ucViewLoanDetail : UserControl
    {
        LoanDTO loandto = new LoanDTO();
        ObservableCollection<BookDTO> lstbookDTO = new ObservableCollection<BookDTO>();
        List<LoanDetail> lstloandetail = new List<LoanDetail>();

        LoanViewModel loanVM = new LoanViewModel();
        LoanDetailViewModel loanDetailVM = new LoanDetailViewModel();
        UserInforViewModel userInfoVM = new UserInforViewModel();
        ReaderViewModel readerVM = new ReaderViewModel();
        BookViewModel bookVM = new BookViewModel();
        BookTitleViewModel bookTitleVM = new BookTitleViewModel();
        BookISBNViewModel bookISBNVM = new BookISBNViewModel();
        AuthorViewModel authorVM = new AuthorViewModel();
        TranslatorViewModel translatorVM = new TranslatorViewModel();
        PublisherViewModel publisherVM = new PublisherViewModel();

        public ucViewLoanDetail(object value)
        {
            InitializeComponent();
            loandto = value as LoanDTO;
            Init();
        }

        private void Init()
        {
            LoanSlip loan = loanVM.repoLoan.GetByID(loandto.Id);
            UserInfo user = userInfoVM.repoUserInfo.GetByID(loan.IdUser);
            tbluser.Text = string.Format("User Name: {0}", user.LName + user.FName);

            Reader reader = readerVM.repoReader.GetById(loan.IdReader);
            tblreader.Text = string.Format("User Name: {0}", reader.LName + reader.FName);

            tbldeposit.Text = string.Format("Deposit: {0}", loan.Deposit);
            tblexpdate.Text = string.Format("ExpDate: {0}", loan.ExpDate);
            tblloandate.Text = string.Format("LoanDate: {0}", loan.LoanDate);
            tblloanpaid.Text = string.Format("Loan Paid: {0}", loan.LoanPaid);
            tblquantity.Text = string.Format("Quantity: {0}", loan.Quantity);
            lstbookDTO = new ObservableCollection<BookDTO>();
            BookDTO bookDTO = null;
            lstloandetail = loanDetailVM.repoLoanDetail.GetListByIdLoan(loan.Id);
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
        }
    }
}
