using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ucViewPenalty.xaml
    /// </summary>
    public partial class ucViewPenalty : UserControl
    {
        PenaltyReasonViewModel penaltyVM = new PenaltyReasonViewModel();
        private PaginationViewModel<PenaltyReason> _PaginationVM;

        public ucViewPenalty()
        {
            InitializeComponent();
            _PaginationVM = new PaginationViewModel<PenaltyReason>(penaltyVM.repoPenalty.Items);
            DataContext = _PaginationVM;
            _PaginationVM.SelectedButton = pagination.btnOne;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            ucEditPenalty edit = new ucEditPenalty(penaltyVM.repoPenalty.Items[dtgpenalty.SelectedIndex]);
            WindowMessege window = new WindowMessege();
            window.grid.Children.Add(edit);
            window.ShowDialog();
            _PaginationVM.GotoFirstPage(penaltyVM.repoPenalty.Items);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as Button).DataContext as PenaltyReason;
            string message = string.Format("You want Update {0}?", item.Name);
            string caption = "Confirmation";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Question;
            if (MessageBox.Show(message, caption, buttons, icon) == MessageBoxResult.Yes)
            {
                penaltyVM.repoPenalty.Delete(item);
                _PaginationVM.GotoFirstPage(penaltyVM.repoPenalty.Items);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowMessege mess = new WindowMessege();
            mess.grid.Children.Add(new ucAddPenalty());
            mess.Show();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSearch.Text == string.Empty)
            {
                _PaginationVM.GotoFirstPage(penaltyVM.repoPenalty.Items);
                return;
            }
            _PaginationVM.LstItem.Clear();

            foreach (var item in penaltyVM.repoPenalty.Items)
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
            }
        }
    }
}
