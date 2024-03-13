using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ucViewCategory.xaml
    /// </summary>
    public partial class ucViewCategory : UserControl
    {
        CategoryViewModel categoryVM = new CategoryViewModel();
        List<Category> lstCategory = new List<Category>();
        private PaginationViewModel<Category> _PaginationVM;
        public ucViewCategory()
        {
            InitializeComponent();
            lstCategory = categoryVM.GetItem();
            _PaginationVM = new PaginationViewModel<Category>(lstCategory);
            DataContext = _PaginationVM;
            _PaginationVM.SelectedButton = pagination.btnOne;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            
            var item = (sender as Button).DataContext as Category;
            if (item.Status == false)
            {
                categoryVM.UnLock(item, dtgcategory.SelectedIndex);
                lstCategory[dtgcategory.SelectedIndex].Status = true;
                _PaginationVM.GotoFirstPage(lstCategory);
            }
            else
            {
                categoryVM.Lock(item, dtgcategory.SelectedIndex);
                lstCategory[dtgcategory.SelectedIndex].Status = false;
                _PaginationVM.GotoFirstPage(lstCategory);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            ucEditCategory edit = new ucEditCategory(lstCategory[dtgcategory.SelectedIndex]);
            WindowMessege window = new WindowMessege();
            window.grid.Children.Add(edit);
            window.ShowDialog();

            _PaginationVM.GotoFirstPage(lstCategory);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowMessege mess = new WindowMessege();
            mess.grid.Children.Add(new ucAddCategory());
            mess.Show();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSearch.Text == string.Empty)
            {
                _PaginationVM.GotoFirstPage(lstCategory);
                return;
            }
            _PaginationVM.LstItem.Clear();

            foreach (var item in lstCategory)
            {
                if (item.Id.ToLower().Contains(txtSearch.Text.ToLower()))
                {
                    _PaginationVM.LstItem.Add(item);
                }
                else if (item.Name.ToLower().Contains(txtSearch.Text.ToLower()))
                {
                    _PaginationVM.LstItem.Add(item);
                }
            }
        }
    }
}
