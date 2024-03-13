using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ucViewPublisher.xaml
    /// </summary>
    public partial class ucViewPublisher : UserControl
    {
        private PaginationViewModel<Publisher> _PaginationVM;
        PublisherViewModel publisherVM = new PublisherViewModel();
        public ucViewPublisher()
        {
            InitializeComponent();
            _PaginationVM = new PaginationViewModel<Publisher>(publisherVM.GetItem());
            DataContext = _PaginationVM;
            _PaginationVM.SelectedButton = pagination.btnOne;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            ucEditPublisher edit = new ucEditPublisher(publisherVM.repoPublisher.Items[dtgpublisher.SelectedIndex]);
            WindowMessege window = new WindowMessege();
            window.grid.Children.Add(edit);
            window.ShowDialog();
            _PaginationVM.GotoFirstPage(publisherVM.GetItem());
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowMessege mess = new WindowMessege();
            mess.grid.Children.Add(new ucAddPublisher());
            mess.Show();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSearch.Text == string.Empty)
            {
                _PaginationVM.GotoFirstPage(publisherVM.GetItem());
                return;
            }
            _PaginationVM.LstItem.Clear();

            foreach (var item in publisherVM.GetItem())
            {
                if (item.Id.ToLower().Contains(txtSearch.Text.ToLower()))
                {
                    _PaginationVM.LstItem.Add(item);
                }
                else if (item.Name.ToLower().Contains(txtSearch.Text.ToLower()))
                {
                    _PaginationVM.LstItem.Add(item);
                }
                else if (item.Phone.ToLower().Contains(txtSearch.Text.ToLower()))
                {
                    _PaginationVM.LstItem.Add(item);
                }
                else if (item.Address.ToLower().Contains(txtSearch.Text.ToLower()))
                {
                    _PaginationVM.LstItem.Add(item);
                }
            }
        }
    }
}
