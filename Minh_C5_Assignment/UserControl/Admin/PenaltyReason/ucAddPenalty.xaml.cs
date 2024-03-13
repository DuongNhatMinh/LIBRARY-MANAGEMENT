using System;
using System.Windows;
using System.Windows.Controls;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ucAddPenalty.xaml
    /// </summary>
    public partial class ucAddPenalty : UserControl
    {
        PenaltyReasonViewModel penaltyVM = new PenaltyReasonViewModel();
        public ucAddPenalty()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            txtName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtPrice.Text = string.Empty;
        }

        private bool isEmpty()
        {
            if (txtName.Text == string.Empty && txtPrice.Text == string.Empty && txtDescription.Text == string.Empty)
                return true;
            return false;
        }

        private bool IsExist()
        {
            foreach (var item in penaltyVM.repoPenalty.Items)
            {
                if (txtName.Text == item.Name)
                    return true;
            }
            return false;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (isEmpty())
            {
                MessageBox.Show("Text box is not left empty!", "Notify", MessageBoxButton.OK);
                return;
            }
            if (IsExist())
            {
                MessageBox.Show("Penalty is Exist!", "Notify", MessageBoxButton.OK);
                return;
            }
            var penalty = new PenaltyReason()
            {
                Id = RepositoryPenaltyReason.GetNewID(),
                Name = txtName.Text,
                Description = txtDescription.Text,
                Price = decimal.Parse(txtPrice.Text),
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            };
            penaltyVM.repoPenalty.Add(penalty);
            Clear();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }
    }
}
