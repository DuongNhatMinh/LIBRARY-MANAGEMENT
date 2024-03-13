using System.Windows;
using System.Windows.Controls;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ucViewAuthot.xaml
    /// </summary>
    public partial class ucViewAuthor : UserControl
    {
        AuthorViewModel authorVM = new AuthorViewModel();
        private PaginationViewModel<Author> _PaginationVM;

        public ucViewAuthor()
        {
            InitializeComponent();
            _PaginationVM = new PaginationViewModel<Author>(authorVM.repoAuthor.Items);
            DataContext = _PaginationVM;
            _PaginationVM.SelectedButton = pagination.btnOne;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as Button).DataContext as Author;
            if (item.Status == false)
            {
                authorVM.UnLock(item, dtgAuthor.SelectedIndex);
                authorVM.repoAuthor.Items[dtgAuthor.SelectedIndex].Status = true;
                _PaginationVM.GotoFirstPage(authorVM.repoAuthor.Items);
            }
            else
            {
                authorVM.Lock(item, dtgAuthor.SelectedIndex);
                authorVM.repoAuthor.Items[dtgAuthor.SelectedIndex].Status = false;
                _PaginationVM.GotoFirstPage(authorVM.repoAuthor.Items);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as Button).DataContext as Author;
            ucEditAuthor ucEdit = new ucEditAuthor(item);
            WindowMessege window = new WindowMessege();
            window.grid.Children.Add(ucEdit);
            window.ShowDialog();
            _PaginationVM.GotoFirstPage(authorVM.repoAuthor.Items);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowMessege mess = new WindowMessege();
            mess.grid.Children.Add(new ucAddAuthor());
            mess.Show();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSearch.Text == string.Empty)
            {
                _PaginationVM.GotoFirstPage(authorVM.repoAuthor.Items);
                return;
            }
            _PaginationVM.LstItem.Clear();

            foreach (var item in authorVM.repoAuthor.Items)
            {
                if (item.Id.ToLower().Contains(txtSearch.Text.ToLower()))
                {
                    _PaginationVM.LstItem.Add(item);
                }
                else if (item.Name.ToLower().Contains(txtSearch.Text.ToLower()))
                {
                    _PaginationVM.LstItem.Add(item);
                }
                else if (item.Description.ToLower().Contains(txtSearch.Text.ToLower()))
                {
                    _PaginationVM.LstItem.Add(item);
                }
                else if (item.boF.ToString("dd/MM/yyyy").Contains(txtSearch.Text))
                {
                    _PaginationVM.LstItem.Add(item);
                }
                else if (item.CreatedAt.ToString("dd/MM/yyyy").Contains(txtSearch.Text))
                {
                    _PaginationVM.LstItem.Add(item);
                }
                else if (item.ModifiedAt.ToString("dd/MM/yyyy").Contains(txtSearch.Text))
                {
                    _PaginationVM.LstItem.Add(item);
                }
            }
        }
    }
}
