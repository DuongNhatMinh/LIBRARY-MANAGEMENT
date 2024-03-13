using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ucViewParamenter.xaml
    /// </summary>
    public partial class ucViewParamenter : UserControl
    {
        ParameterViewModel paramenterVM = new ParameterViewModel();
        private PaginationViewModel<Parameter> _PaginationVM;

        public ucViewParamenter()
        {
            InitializeComponent();
            _PaginationVM = new PaginationViewModel<Parameter>(paramenterVM.repoParameter.Items);
            DataContext = _PaginationVM;
            _PaginationVM.SelectedButton = pagination.btnOne;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as Button).DataContext as Parameter;
            if (item.Status == false)
            {
                paramenterVM.UnLock(item, dtgparamenter.SelectedIndex);
                paramenterVM.repoParameter.Items[dtgparamenter.SelectedIndex].Status = true;
                _PaginationVM.GotoFirstPage(paramenterVM.repoParameter.Items);
            }
            else
            {
                paramenterVM.Lock(item, dtgparamenter.SelectedIndex);
                paramenterVM.repoParameter.Items[dtgparamenter.SelectedIndex].Status = false;
                _PaginationVM.GotoFirstPage(paramenterVM.repoParameter.Items);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            ucEditParamenter edit = new ucEditParamenter(paramenterVM.repoParameter.Items[dtgparamenter.SelectedIndex]);
            WindowMessege window = new WindowMessege();
            window.grid.Children.Add(edit);
            window.ShowDialog();
            _PaginationVM.GotoFirstPage(paramenterVM.repoParameter.Items);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowMessege mess = new WindowMessege();
            mess.grid.Children.Add(new ucAddParameter());
            mess.Show();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSearch.Text == string.Empty)
            {
                _PaginationVM.GotoFirstPage(paramenterVM.repoParameter.Items);
                return;
            }
            _PaginationVM.LstItem.Clear();

            foreach (var item in paramenterVM.repoParameter.Items)
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
                else if (item.Value.ToLower().Contains(txtSearch.Text.ToLower()))
                {
                    _PaginationVM.LstItem.Add(item);
                }

            }
        }
    }
}
