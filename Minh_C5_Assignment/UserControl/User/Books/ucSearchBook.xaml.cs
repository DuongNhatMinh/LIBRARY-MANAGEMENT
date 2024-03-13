using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ucSearchBook.xaml
    /// </summary>
    public partial class ucSearchBook : UserControl, INotifyPropertyChanged
    {
        private PaginationViewModel<BookDTO> _PaginationVM;
        BookViewModel bookVM = new BookViewModel();
        BookTitleViewModel bookTitleVM = new BookTitleViewModel();
        BookISBNViewModel bookISBNVM = new BookISBNViewModel();
        TranslatorViewModel translatorVM = new TranslatorViewModel();
        PublisherViewModel publisherVM = new PublisherViewModel();
        private string _find;

        public string Find
        {
            get { return _find; }
            set
            {
                _find = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ucSearchBook()
        {
            InitializeComponent();
            DataContext = this;
            Init();
        }

        private List<BookDTO> GetListBookDTO()
        {
            var bookDTOs = new List<BookDTO>();
            BookDTO bookDTO = null;
            for (int i = 0; i < bookVM.repoBook.Items.Count; i++)
            {
                BookISBN bookISBN = bookISBNVM.repoBookISBN.GetByISBN(bookVM.repoBook.Items[i].ISBN);
                BookTitle booktitle = bookTitleVM.repoBookTitle.GetByID(bookISBN.IdBookTitle);
                Translator translator = translatorVM.repoTranslator.GetByID(bookVM.repoBook.Items[i].IdTranslator);
                Publisher publisher = publisherVM.repoPublisher.GetByID(bookVM.repoBook.Items[i].IdPublisher);
                bookDTO = new BookDTO(bookVM.repoBook.Items[i].Id, bookVM.repoBook.Items[i].ISBN, booktitle.Name, translator.Name,
                    bookISBN.OriginLanguage, publisher.Name, bookVM.repoBook.Items[i].Price, bookVM.repoBook.Items[i].PriceCurrent,
                    bookVM.repoBook.Items[i].PublishDate, bookVM.repoBook.Items[i].CreatedAt, bookVM.repoBook.Items[i].ModifiedAt, bookVM.repoBook.Items[i].Status);
                bookDTOs.Add(bookDTO);
            }
            return bookDTOs;
        }

        private void Init()
        {
            _PaginationVM = new PaginationViewModel<BookDTO>(GetListBookDTO());
            DataContext = _PaginationVM;
            _PaginationVM.SelectedButton = pagination.btnOne;
        }

        private void btnAdd_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            WindowMessege mess = new WindowMessege();
            mess.grid.Children.Add(new ucAddBook());
            mess.Show();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSearch.Text == string.Empty)
            {
                _PaginationVM.GotoFirstPage(GetListBookDTO());
                return;
            }
            _PaginationVM.LstItem.Clear();

            foreach (var item in GetListBookDTO())
            {
                if (item.Id.ToString().Contains(txtSearch.Text))
                {
                    _PaginationVM.LstItem.Add(item);
                }
                else if (item.ISBN.ToLower().Contains(txtSearch.Text.ToLower()))
                {
                    _PaginationVM.LstItem.Add(item);
                }
                else if (item.NameDTO.ToLower().Contains(txtSearch.Text.ToLower()))
                {
                    _PaginationVM.LstItem.Add(item);
                }
                else if (item.TranlatorDTO.ToLower().Contains(txtSearch.Text.ToLower()))
                {
                    _PaginationVM.LstItem.Add(item);
                }
                else if (item.LanguageDTO.ToLower().Contains(txtSearch.Text.ToLower()))
                {
                    _PaginationVM.LstItem.Add(item);
                }
                else if (item.Publisher.ToLower().Contains(txtSearch.Text.ToLower()))
                {
                    _PaginationVM.LstItem.Add(item);
                }
                else if (item.PublishDate.ToString("dd/MM/yyyy").Contains(txtSearch.Text))
                {
                    _PaginationVM.LstItem.Add(item);
                }
                else if (item.CreatedAt.ToString("dd/MM/yyyy").Contains(txtSearch.Text))
                {
                    _PaginationVM.LstItem.Add(item);
                }
                else if (item.ModifitedAt.ToString("dd/MM/yyyy").Contains(txtSearch.Text))
                {
                    _PaginationVM.LstItem.Add(item);
                }
            }
        }
    }
}
