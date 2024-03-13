using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ucViewBook.xaml
    /// </summary>
    public partial class ucViewBookISBN : UserControl
    {
        BookISBNViewModel bookISBNVM = new BookISBNViewModel();
        BookTitleViewModel bookTitleVM = new BookTitleViewModel();
        AuthorViewModel authorVM = new AuthorViewModel();
        CategoryViewModel categoryVM = new CategoryViewModel();
        BookViewModel bookVM = new BookViewModel();
        private PaginationViewModel<BookISBNDTO> _PaginationVM;

        public ucViewBookISBN()
        {
            InitializeComponent();
            Init();
        }

        private List<BookISBNDTO> GetListBookISBNDTO()
        {
            List<BookISBNDTO> bookISBNDTOs = new List<BookISBNDTO>();
            BookISBNDTO bookISBNDTO = null;
            for (int i = 0; i < bookISBNVM.repoBookISBN.Items.Count; i++)
            {
                BookTitle booktitle = bookTitleVM.repoBookTitle.GetByID(bookISBNVM.repoBookISBN.Items[i].IdBookTitle);
                Author author = authorVM.repoAuthor.GetByID(bookISBNVM.repoBookISBN.Items[i].IdAuthor);
                int quantity = bookVM.repoBook.GetQuantity(bookISBNVM.repoBookISBN.Items[i].ISBN);
                bookISBNDTO = new BookISBNDTO(bookISBNVM.repoBookISBN.Items[i].ISBN, booktitle.Name, author.Name, bookISBNVM.repoBookISBN.Items[i].OriginLanguage, quantity, bookISBNVM.repoBookISBN.Items[i].Status);
                bookISBNDTOs.Add(bookISBNDTO);
            }
            return bookISBNDTOs;
        }

        private void Init()
        {
            _PaginationVM = new PaginationViewModel<BookISBNDTO>(GetListBookISBNDTO());
            DataContext = _PaginationVM;
            _PaginationVM.SelectedButton = pagination.btnOne;
        }

        private void btnAdd_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            WindowMessege mess = new WindowMessege();
            mess.grid.Children.Add(new ucAddBookISBN());
            mess.Show();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSearch.Text == string.Empty)
            {
                _PaginationVM.GotoFirstPage(GetListBookISBNDTO());
                return;
            }
            _PaginationVM.LstItem.Clear();

            foreach (var item in GetListBookISBNDTO())
            {
                if (item.ISBN.ToLower().Contains(txtSearch.Text.ToLower()))
                {
                    _PaginationVM.LstItem.Add(item);
                }
                else if (item.BookTitleDTO.ToLower().Contains(txtSearch.Text.ToLower()))
                {
                    _PaginationVM.LstItem.Add(item);
                }
                else if (item.AuthorDTO.ToLower().Contains(txtSearch.Text.ToLower()))
                {
                    _PaginationVM.LstItem.Add(item);
                }
                else if (item.Language.ToLower().Contains(txtSearch.Text.ToLower()))
                {
                    _PaginationVM.LstItem.Add(item);
                }
                else if (item.Quantity.ToString().Contains(txtSearch.Text))
                {
                    _PaginationVM.LstItem.Add(item);
                }
            }
        }
    }
}
