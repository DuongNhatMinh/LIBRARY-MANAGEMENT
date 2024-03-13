using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ucViewFunction.xaml
    /// </summary>
    public partial class ucViewFunction : UserControl
    {
        FunctionViewModel functionVM = new FunctionViewModel();
        RoleFunctionViewModel rolefunctionVM = new RoleFunctionViewModel();
        List<string> lstidRole = new List<string>();
        private PaginationViewModel<Function> _PaginationVM;

        public ucViewFunction()
        {
            InitializeComponent();
            Init();
            _PaginationVM = new PaginationViewModel<Function>(functionVM.repoFunction.Items);
            DataContext = _PaginationVM;
            _PaginationVM.SelectedButton = pagination.btnOne;
        }

        private void Init()
        {
            //dtgFunction.ItemsSource = functionVM.unit.function.Items;
            string strtemp = string.Empty;
            foreach(var item in rolefunctionVM.repoRoleFunction.Items)
            {
                Function function = functionVM.repoFunction.getbyid(item.IdFunction);
                if(function.IsAdmin == false)
                {
                    if(function.Id != strtemp)
                    {
                        strtemp = function.Id;
                        lstidRole.Add(strtemp);
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as Button).DataContext as Function;
            if (item.IsAdmin == true)
                return;
            if (item.Status == false)
            {
                if (item.IdParent != "")
                {
                    Function functionParent = functionVM.repoFunction.getbyid(item.IdParent);
                    if (functionParent.Status == false)
                        MessageBox.Show("Function Parent is Lock. Please Unlock Function Parent!");
                    else
                    {
                        functionVM.UnLock(dtgFunction.SelectedIndex);
                        functionVM.repoFunction.Items[dtgFunction.SelectedIndex].Status = true;
                        _PaginationVM.GotoFirstPage(functionVM.repoFunction.Items);
                    }
                }
                else
                {
                    functionVM.UnLock(dtgFunction.SelectedIndex);
                    functionVM.repoFunction.Items[dtgFunction.SelectedIndex].Status = true;
                    _PaginationVM.GotoFirstPage(functionVM.repoFunction.Items);
                }
            }
            else
            {
                if (!Check(item.Id))
                {
                    functionVM.Lock(item, dtgFunction.SelectedIndex);
                    functionVM.repoFunction.Items[dtgFunction.SelectedIndex].Status = false;
                    _PaginationVM.GotoFirstPage(functionVM.repoFunction.Items);
                }
            }
        }

        public bool Check(string idrole)
        {
            foreach (var item2 in lstidRole)
            {
                if (item2 == idrole)
                {
                    MessageBox.Show("Feature is being used!");
                    return true;
                }
            }
            return false;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            ucEditFunction edit = new ucEditFunction(functionVM.repoFunction.Items[dtgFunction.SelectedIndex]);
            WindowMessege window = new WindowMessege();
            window.grid.Children.Add(edit);
            window.ShowDialog();
            Init();
            _PaginationVM.GotoFirstPage(functionVM.repoFunction.Items);
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSearch.Text == string.Empty)
            {
                _PaginationVM.GotoFirstPage(functionVM.repoFunction.Items);
                return;
            }
            _PaginationVM.LstItem.Clear();

            foreach (var item in functionVM.repoFunction.Items)
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
                else if (item.IdParent != null && item.IdParent.ToLower().Contains(txtSearch.Text.ToLower()))
                {
                    _PaginationVM.LstItem.Add(item);
                }
            }
        }
    }
}
