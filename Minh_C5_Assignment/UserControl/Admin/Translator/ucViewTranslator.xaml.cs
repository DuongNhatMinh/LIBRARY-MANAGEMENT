using System.Windows;
using System.Windows.Controls;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ucViewTranslator.xaml
    /// </summary>
    public partial class ucViewTranslator : UserControl
    {
        private PaginationViewModel<Translator> _PaginationVM;
        TranslatorViewModel translatorVM = new TranslatorViewModel();
        public ucViewTranslator()
        {
            InitializeComponent();
            dtgAuthor.ItemsSource = translatorVM.repoTranslator.Items;
            _PaginationVM = new PaginationViewModel<Translator>(translatorVM.repoTranslator.Items);
            DataContext = _PaginationVM;
            _PaginationVM.SelectedButton = pagination.btnOne;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as Button).DataContext as Translator;
            if (item.Status == false)
            {
                translatorVM.UnLock(item, dtgAuthor.SelectedIndex);
                translatorVM.repoTranslator.Items[dtgAuthor.SelectedIndex].Status = true;
                _PaginationVM.GotoFirstPage(translatorVM.repoTranslator.Items);
            }
            else
            {
                translatorVM.Lock(item, dtgAuthor.SelectedIndex);
                translatorVM.repoTranslator.Items[dtgAuthor.SelectedIndex].Status = false;
                dtgAuthor.ItemsSource = null;
                _PaginationVM.GotoFirstPage(translatorVM.repoTranslator.Items);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as Button).DataContext as Translator;
            ucEditTranslator ucEdit = new ucEditTranslator(item);
            WindowMessege window = new WindowMessege();
            window.grid.Children.Add(ucEdit);
            window.ShowDialog();
            _PaginationVM.GotoFirstPage(translatorVM.repoTranslator.Items);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowMessege mess = new WindowMessege();
            mess.grid.Children.Add(new ucAddTranslator());
            mess.Show();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSearch.Text == string.Empty)
            {
                _PaginationVM.GotoFirstPage(translatorVM.repoTranslator.Items);
                return;
            }
            _PaginationVM.LstItem.Clear();

            foreach (var item in translatorVM.repoTranslator.Items)
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
