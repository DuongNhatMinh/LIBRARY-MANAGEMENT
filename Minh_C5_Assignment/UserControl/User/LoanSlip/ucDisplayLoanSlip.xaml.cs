using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ucDisplayLoanSlip.xaml
    /// </summary>
    public partial class ucDisplayLoanSlip : UserControl
    {
        LoanViewModel loanVM = new LoanViewModel();
        LoanDetailViewModel loandetailVM = new LoanDetailViewModel();
        BookViewModel bookVM = new BookViewModel();
        BookISBNViewModel bookISBNVM = new BookISBNViewModel();
        BookTitleViewModel bookTitleVM = new BookTitleViewModel();
        AuthorViewModel authorVM = new AuthorViewModel();
        CategoryViewModel categoryVM = new CategoryViewModel();
        TranslatorViewModel translatorVM = new TranslatorViewModel();
        PublisherViewModel publisherVM = new PublisherViewModel();
        ReaderViewModel readerVM = new ReaderViewModel();
        UserInforViewModel userinfoVM = new UserInforViewModel();
        ObservableCollection<BookISBNDTO> bookDTOs = new ObservableCollection<BookISBNDTO>();
        ObservableCollection<BookISBNDTO> bookDTOstemp = new ObservableCollection<BookISBNDTO>();
        ObservableCollection<BookDTO> lstbookDTO = new ObservableCollection<BookDTO>();
        ObservableCollection<BookDTO> lstookDTOtemp = new ObservableCollection<BookDTO>();
        ObservableCollection<Book> lstbook = new ObservableCollection<Book>();
        List<LoanDetailDTO> lstloandetailDTO = new List<LoanDetailDTO>();
        BookISBNDTO bookDTO = null;
        Reader ReaderTemp { get; set; }
        User user { get; set; }
        int count = 0, quantity = 0;

        public ucDisplayLoanSlip(object value)
        {
            InitializeComponent();
            ReaderTemp = new Reader();
            user = value as User;

            foreach (var item in readerVM.repoReader.Items)
            {
                cbReaderID.Items.Add(item.Id);
            }
            foreach (var item in categoryVM.repoCat.Items)
            {
                cbcategory.Items.Add(item.Name);
            }
            foreach (var item in authorVM.repoAuthor.Items)
            {
                cbAuthor.Items.Add(item.Name);
            }
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            count = 0;
            stackpanel.Children.Clear();
            ucCreateNewLoan uccreateloan = new ucCreateNewLoan(ReaderTemp, lstookDTOtemp, user);
            stackpanel.Children.Add(uccreateloan);
        }

        private bool IsCheck(Reader reader)
        {
            List<LoanSlip> lstloan = loanVM.repoLoan.GetListByIDReader(reader.Id);
            foreach (var item in lstloan)
            {
                if (item.ExpDate < DateTime.Now)
                {
                    return true;
                }
            }
            return false;
        }

        private void cbReaderID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Reader reader = readerVM.repoReader.GetById(cbReaderID.Items[cbReaderID.SelectedIndex].ToString());
            string name = string.Format("Name: {0} {1}", reader.LName, reader.FName);
            lbname.Text = name;
            if (reader.ReaderType == true)
                lbtype.Text = "Type: Adult";
            else
                lbtype.Text = "Type: Child";
            lbStatus.Text = "Status: Activate";
            ReaderTemp = reader;
            dtgBookOrder.Items.Clear();
            DisplayDetail(reader);
            if (IsCheck(reader))
            {
                stackpanelSearch.IsEnabled = false;
            }
            else
            {
                stackpanelSearch.IsEnabled = true;
                Init();
            }  
        }

        private void DisplayDetail(Reader reader)
        {
            lstloandetailDTO = new List<LoanDetailDTO>();
            dtgloandetail.ItemsSource = null;
            List<LoanSlip> lstloan = loanVM.repoLoan.GetListByIDReader(reader.Id);
            foreach (var item in lstloan)
            {
                quantity = item.Quantity;
                List<LoanDetail> lstloandetail = loandetailVM.repoLoanDetail.GetListByIdLoan(item.Id);
                foreach (var item2 in lstloandetail)
                {
                    Book book = bookVM.repoBook.GetById(item2.IdBook);
                    BookISBN bookISBN = bookISBNVM.repoBookISBN.GetByISBN(book.ISBN);
                    BookTitle booktitle = bookTitleVM.repoBookTitle.GetByID(bookISBN.IdBookTitle);
                    string nameBook = string.Format("{0} <{1}>", booktitle.Name, book.Language);
                    LoanDetailDTO loandetailDTO = new LoanDetailDTO(item.Id, nameBook, item.LoanDate, item2.ExpDate);
                    lstloandetailDTO.Add(loandetailDTO);
                }
            }
            dtgloandetail.ItemsSource = lstloandetailDTO;
        }

        private void Init()
        {
            bookDTOs = new ObservableCollection<BookISBNDTO>();
            BookISBNDTO bookISBNDTO = null;
            for (int i = 0; i < bookISBNVM.repoBookISBN.Items.Count; i++)
            {
                BookTitle booktitle = bookTitleVM.repoBookTitle.GetByID(bookISBNVM.repoBookISBN.Items[i].IdBookTitle);
                Author author = authorVM.repoAuthor.GetByID(bookISBNVM.repoBookISBN.Items[i].IdAuthor);
                int quantity = bookVM.repoBook.GetQuantity(bookISBNVM.repoBookISBN.Items[i].ISBN);
                bookISBNDTO = new BookISBNDTO(bookISBNVM.repoBookISBN.Items[i].ISBN, booktitle.Name, author.Name, bookISBNVM.repoBookISBN.Items[i].OriginLanguage,
                    quantity, bookISBNVM.repoBookISBN.Items[i].Status);
                bookDTOs.Add(bookISBNDTO);
            }
            dtgBook.ItemsSource = bookDTOs;
        }

        private void btnSaerch_Click(object sender, RoutedEventArgs e)
        {
            Category category = null;
            string NameBook = string.Empty;
            Author author = null;
            if (cbcategory.SelectedIndex != -1)
            {
                category = categoryVM.repoCat.GetByName(cbcategory.Items[cbcategory.SelectedIndex].ToString());
            }
            if (cbAuthor.SelectedIndex != -1)
            {
                author = authorVM.repoAuthor.GetByName(cbAuthor.Items[cbAuthor.SelectedIndex].ToString());
            }
            if (txtBook.Text != string.Empty)
            {
                NameBook = txtBook.Text;
            }

            bookDTOs = new ObservableCollection<BookISBNDTO>();
            BookISBNDTO bookDTO = null;
            for (int i = 0; i < bookISBNVM.repoBookISBN.Items.Count; i++)
            {
                //if (bookISBNVM.unit.bookISBN.Items[i].Status == false)
                //    continue;
                if (category != null && txtBook.Text != string.Empty && author != null)
                {
                    if (author.Id == bookVM.repoBook.Items[i].IdTranslator)
                    {
                        BookISBN bookISBN = bookISBNVM.repoBookISBN.GetByISBN(bookVM.repoBook.Items[i].ISBN);
                        BookTitle booktitle = bookTitleVM.repoBookTitle.GetByNameandIdCategory(category.Id, txtBook.Text);
                        if (bookISBN.IdBookTitle == booktitle.Id)
                        {
                            int quantity = bookVM.repoBook.GetQuantity(bookISBNVM.repoBookISBN.Items[i].ISBN);
                            bookDTO = new BookISBNDTO(bookISBNVM.repoBookISBN.Items[i].ISBN, booktitle.Name, author.Name, bookISBNVM.repoBookISBN.Items[i].OriginLanguage,
                                quantity, bookISBNVM.repoBookISBN.Items[i].Status);
                            bookDTOs.Add(bookDTO);

                        }
                    }
                    continue;
                }
                if (category != null && txtBook.Text != string.Empty)
                {
                    BookTitle booktitle = bookTitleVM.repoBookTitle.GetByNameandIdCategory(category.Id, txtBook.Text);
                    if (bookISBNVM.repoBookISBN.Items[i].IdBookTitle == booktitle.Id)
                    {
                        int quantity = bookVM.repoBook.GetQuantity(bookISBNVM.repoBookISBN.Items[i].ISBN);
                        bookDTO = new BookISBNDTO(bookISBNVM.repoBookISBN.Items[i].ISBN, booktitle.Name, author.Name, bookISBNVM.repoBookISBN.Items[i].OriginLanguage,
                            quantity, bookISBNVM.repoBookISBN.Items[i].Status);
                        bookDTOs.Add(bookDTO);

                    }
                    continue;
                }
                if (txtBook.Text != string.Empty && author != null)
                {
                    if (author.Id == bookISBNVM.repoBookISBN.Items[i].IdAuthor)
                    {
                        BookTitle booktitle = bookTitleVM.repoBookTitle.GetByName(txtBook.Text);
                        if (bookISBNVM.repoBookISBN.Items[i].IdBookTitle == booktitle.Id)
                        {
                            int quantity = bookVM.repoBook.GetQuantity(bookISBNVM.repoBookISBN.Items[i].ISBN);
                            bookDTO = new BookISBNDTO(bookISBNVM.repoBookISBN.Items[i].ISBN, booktitle.Name, author.Name, bookISBNVM.repoBookISBN.Items[i].OriginLanguage,
                                quantity, bookISBNVM.repoBookISBN.Items[i].Status);
                            bookDTOs.Add(bookDTO);

                        }
                    }
                    continue;
                }
                if (category != null && author != null)
                {
                    if (author.Id == bookISBNVM.repoBookISBN.Items[i].IdAuthor)
                    {
                        BookTitle booktitle = bookTitleVM.repoBookTitle.GetByIDCategory(category.Id);
                        if (bookISBNVM.repoBookISBN.Items[i].IdBookTitle == booktitle.Id)
                        {
                            Translator translator = translatorVM.repoTranslator.GetByID(bookVM.repoBook.Items[i].IdTranslator);
                            Publisher publisher = publisherVM.repoPublisher.GetByID(bookVM.repoBook.Items[i].IdPublisher);
                            int quantity = bookVM.repoBook.GetQuantity(bookISBNVM.repoBookISBN.Items[i].ISBN);
                            bookDTO = new BookISBNDTO(bookISBNVM.repoBookISBN.Items[i].ISBN, booktitle.Name, author.Name, bookISBNVM.repoBookISBN.Items[i].OriginLanguage,
                                quantity, bookISBNVM.repoBookISBN.Items[i].Status);
                            bookDTOs.Add(bookDTO);

                        }
                    }
                    continue;
                }
                if (category != null)
                {
                    BookTitle booktitle = bookTitleVM.repoBookTitle.GetByIDCategory(category.Id);
                    Author author2 = authorVM.repoAuthor.GetByID(bookISBNVM.repoBookISBN.Items[i].IdAuthor);
                    if (bookISBNVM.repoBookISBN.Items[i].IdBookTitle == booktitle.Id)
                    {
                        int quantity = bookVM.repoBook.GetQuantity(bookISBNVM.repoBookISBN.Items[i].ISBN);
                        bookDTO = new BookISBNDTO(bookISBNVM.repoBookISBN.Items[i].ISBN, booktitle.Name, author2.Name, bookISBNVM.repoBookISBN.Items[i].OriginLanguage,
                            quantity, bookISBNVM.repoBookISBN.Items[i].Status);
                        bookDTOs.Add(bookDTO);
                    }
                }
                if (author != null)
                {
                    if (author.Id == bookISBNVM.repoBookISBN.Items[i].IdAuthor)
                    {
                        BookTitle booktitle = bookTitleVM.repoBookTitle.GetByID(bookISBNVM.repoBookISBN.Items[i].IdBookTitle);
                        int quantity = bookVM.repoBook.GetQuantity(bookISBNVM.repoBookISBN.Items[i].ISBN);
                        bookDTO = new BookISBNDTO(bookISBNVM.repoBookISBN.Items[i].ISBN, booktitle.Name, author.Name, bookISBNVM.repoBookISBN.Items[i].OriginLanguage,
                            quantity, bookISBNVM.repoBookISBN.Items[i].Status);
                        bookDTOs.Add(bookDTO);
                    }
                }
                if (txtBook.Text != string.Empty)
                {
                    BookTitle booktitle = bookTitleVM.repoBookTitle.GetByName(txtBook.Text);
                    if (bookISBNVM.repoBookISBN.Items[i].IdBookTitle == booktitle.Id)
                    {
                        int quantity = bookVM.repoBook.GetQuantity(bookISBNVM.repoBookISBN.Items[i].ISBN);
                        bookDTO = new BookISBNDTO(bookISBNVM.repoBookISBN.Items[i].ISBN, booktitle.Name, author.Name, bookISBNVM.repoBookISBN.Items[i].OriginLanguage,
                            quantity, bookISBNVM.repoBookISBN.Items[i].Status);
                        bookDTOs.Add(bookDTO);
                    }
                }
            }
            dtgBook.ItemsSource = bookDTOs;
        }

        private bool IsExist(string ISBN)
        {
            List<LoanSlip> loan = loanVM.repoLoan.GetListByIDReader(ReaderTemp.Id);
            foreach (var item in loan)
            {
                List<LoanDetail> lstloandetail = loandetailVM.repoLoanDetail.GetListByIdLoan(item.Id);
                foreach (var item2 in lstloandetail)
                {
                    Book book = bookVM.repoBook.GetById(item2.IdBook);
                    if (book.ISBN == ISBN)
                        return true;
                }
            }
            if (lstookDTOtemp.Count != 0)
            {
                foreach (var item in lstookDTOtemp)
                {
                    if (item.ISBN == ISBN)
                        return true;
                }
            }
            return false;
        }

        private bool IsExist2(int id)
        {
            foreach (var item in lstookDTOtemp)
            {
                if (item.Id == id)
                    return true;
            }
            return false;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as Button).DataContext as BookISBNDTO;
            lstbook = bookVM.repoBook.GetListByISBN(item.ISBN);
            lstbookDTO = new ObservableCollection<BookDTO>();
            BookDTO bookDTO = null;
            for (int i = 0; i < lstbook.Count; i++)
            {
                if (!IsExist2(lstbook[i].Id))
                {
                    BookISBN bookISBN = bookISBNVM.repoBookISBN.GetByISBN(lstbook[i].ISBN);
                    BookTitle booktitle = bookTitleVM.repoBookTitle.GetByID(bookISBN.IdBookTitle);
                    Author author = authorVM.repoAuthor.GetByID(bookISBN.IdAuthor);
                    Translator translator = translatorVM.repoTranslator.GetByID(lstbook[i].IdTranslator);
                    Publisher publisher = publisherVM.repoPublisher.GetByID(bookVM.repoBook.Items[i].IdPublisher);
                    bookDTO = new BookDTO(lstbook[i].Id, lstbook[i].ISBN, booktitle.Name, author.Name, translator.Name,
                        bookISBN.OriginLanguage, publisher.Name, lstbook[i].Price, lstbook[i].PriceCurrent,
                        lstbook[i].PublishDate, lstbook[i].CreatedAt, lstbook[i].ModifiedAt, lstbook[i].Status);
                    lstbookDTO.Add(bookDTO);
                }

            }
            frmSelectBook selectbook = new frmSelectBook(lstbookDTO);
            selectbook.ShowDialog();
            if (selectbook.dtgBook.SelectedIndex == -1)
                return;
            if (!IsExist(lstbookDTO[selectbook.dtgBook.SelectedIndex].ISBN))
            {
                if (!CountQuantityBook())
                {
                    bookDTOs[dtgBook.SelectedIndex].Quantity -= 1;
                    dtgBook.ItemsSource = bookDTOs;
                    dtgBookOrder.Items.Add(lstbookDTO[selectbook.dtgBook.SelectedIndex]);
                    lstookDTOtemp.Add(lstbookDTO[selectbook.dtgBook.SelectedIndex]);
                    count++;
                    quantity += count;
                    btnOk.IsEnabled = true;
                }
            }
            else
            {
                MessageBox.Show("The Book is Exist, Please choose another book!");
            }
        }

        public bool CountQuantityBook()
        {
            if (ReaderTemp.ReaderType == true)
            {
                if (quantity == 5)
                    return true;
            }
            else
            {
                if (quantity == 1)
                    return true;
            }
            return false;
        }

        private void dtgloandetail_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            var row = e.Row;
            var person = row.DataContext as LoanDetailDTO;
            if (person.ExpDate < DateTime.Now)
            {
                row.Background = new SolidColorBrush(Colors.Red);
            }
        }

        private void cbcategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bookDTOs = new ObservableCollection<BookISBNDTO>();
            Category category = categoryVM.repoCat.GetByName(cbcategory.Items[cbcategory.SelectedIndex].ToString());
            BookTitle booktitle = bookTitleVM.repoBookTitle.GetByIDCategory(category.Id);
            for (int i = 0; i < bookISBNVM.repoBookISBN.Items.Count; i++)
            {

                Author author2 = authorVM.repoAuthor.GetByID(bookISBNVM.repoBookISBN.Items[i].IdAuthor);
                if (bookISBNVM.repoBookISBN.Items[i].IdBookTitle == booktitle.Id)
                {
                    int quantity = bookVM.repoBook.GetQuantity(bookISBNVM.repoBookISBN.Items[i].ISBN);
                    bookDTO = new BookISBNDTO(bookISBNVM.repoBookISBN.Items[i].ISBN, booktitle.Name, author2.Name, bookISBNVM.repoBookISBN.Items[i].OriginLanguage,
                        quantity, bookISBNVM.repoBookISBN.Items[i].Status);
                    bookDTOs.Add(bookDTO);
                }
            }
            dtgBook.ItemsSource = null;
            dtgBook.ItemsSource = bookDTOs;
        }

        private void cbAuthor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bookDTOs = new ObservableCollection<BookISBNDTO>();
            Author author = authorVM.repoAuthor.GetByName(cbAuthor.Items[cbAuthor.SelectedIndex].ToString());
            for (int i = 0; i < bookISBNVM.repoBookISBN.Items.Count; i++)
            {

                if (author.Id == bookISBNVM.repoBookISBN.Items[i].IdAuthor)
                {
                    BookTitle booktitle = bookTitleVM.repoBookTitle.GetByID(bookISBNVM.repoBookISBN.Items[i].IdBookTitle);
                    int quantity = bookVM.repoBook.GetQuantity(bookISBNVM.repoBookISBN.Items[i].ISBN);
                    bookDTO = new BookISBNDTO(bookISBNVM.repoBookISBN.Items[i].ISBN, booktitle.Name, author.Name, bookISBNVM.repoBookISBN.Items[i].OriginLanguage,
                        quantity, bookISBNVM.repoBookISBN.Items[i].Status);
                    bookDTOs.Add(bookDTO);
                }
            }
            dtgBook.ItemsSource = null;
            dtgBook.ItemsSource = bookDTOs;
        }

        private void txtBook_TextChanged(object sender, TextChangedEventArgs e)
        {
            string txtOrig = txtBook.Text;
            string upper = txtOrig.ToUpper();
            string lower = txtOrig.ToLower();

            var empFiltered = from Emp in bookDTOs
                              let ename = Emp.BookTitleDTO
                              where
                               ename.StartsWith(lower)
                               || ename.StartsWith(upper)
                               || ename.Contains(txtOrig)
                              select Emp;

            dtgBook.ItemsSource = empFiltered;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as Button).DataContext as BookDTO;
            foreach (var item2 in bookDTOs)
            {
                if (item2.ISBN == item.ISBN)
                    bookDTOs[dtgBook.SelectedIndex].Quantity += 1;
            }
            dtgBook.ItemsSource = bookDTOs;
            dtgBookOrder.Items.Remove(item);
            lstookDTOtemp.Remove(item);
            count = 0;
            quantity--;
            btnOk.IsEnabled = false;
        }
    }
}