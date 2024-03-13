using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ucViewBookTitle.xaml
    /// </summary>
    public partial class ucViewBookTitle : UserControl
    {
        private PaginationViewModel<BookTitleDTO> _PaginationVM;
        BookTitleViewModel bookTitleVM = new BookTitleViewModel();
        CategoryViewModel categoryVM = new CategoryViewModel();
        BookViewModel bookVM = new BookViewModel();
        BookISBNViewModel bookISBNVM = new BookISBNViewModel();

        public ucViewBookTitle()
        {
            InitializeComponent();
            Init();
        }

        private List<BookTitleDTO> GetListBookTitleDTO()
        {
            List<BookTitleDTO> bookTitleDTOs = new List<BookTitleDTO>();
            BookTitleDTO bookTitleDTO = null;
            for (int i = 0; i < bookTitleVM.repoBookTitle.Items.Count; i++)
            {
                Category category = categoryVM.repoCat.GetByID(bookTitleVM.repoBookTitle.Items[i].IdCategory);
                BookISBN bookISBN = bookISBNVM.repoBookISBN.GetByIdTitle(bookTitleVM.repoBookTitle.Items[i].Id);
                bookTitleDTO = new BookTitleDTO(bookTitleVM.repoBookTitle.Items[i].Id, category.Name, bookTitleVM.repoBookTitle.Items[i].Name,
                    bookTitleVM.repoBookTitle.Items[i].Summary);
                bookTitleDTOs.Add(bookTitleDTO);
            }
            return bookTitleDTOs;
        }

        private void Init()
        {
            _PaginationVM = new PaginationViewModel<BookTitleDTO>(GetListBookTitleDTO());
            DataContext = _PaginationVM;
            _PaginationVM.SelectedButton = pagination.btnOne;
        }

        private void btnAdd_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            WindowMessege mess = new WindowMessege();
            mess.grid.Children.Add(new ucAddBookTitle());
            mess.Show();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSearch.Text == string.Empty)
            {
                _PaginationVM.GotoFirstPage(GetListBookTitleDTO());
                return;
            }
            _PaginationVM.LstItem.Clear();

            foreach (var item in GetListBookTitleDTO())
            {
                if (item.Id.ToLower().Contains(txtSearch.Text.ToLower()))
                {
                    _PaginationVM.LstItem.Add(item);
                }
                else if (item.CategoryDTO.ToLower().Contains(txtSearch.Text.ToLower()))
                {
                    _PaginationVM.LstItem.Add(item);
                }
                else if (item.Name.ToLower().Contains(txtSearch.Text.ToLower()))
                {
                    _PaginationVM.LstItem.Add(item);
                }
                else if (item.Summary.ToLower().Contains(txtSearch.Text))
                {
                    _PaginationVM.LstItem.Add(item);
                }
            }
        }
    }
}
