using System.Windows;
using System.Windows.Controls;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ucEditPenalty.xaml
    /// </summary>
    public partial class ucEditPenalty : UserControl
    {
        PenaltyReasonViewModel penaltyVM = new PenaltyReasonViewModel();
        PenaltyReason penalty = new PenaltyReason();
        public ucEditPenalty(object value)
        {
            InitializeComponent();
            penalty = value as PenaltyReason;
            Init();
        }

        public void Init()
        {
            txtName.Text = penalty.Name;
            txtDescription.Text = penalty.Description;
            txtPrice.Text = penalty.Price.ToString();
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

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (isEmpty())
            {
                MessageBox.Show("Text box is not left empty!", "Notify", MessageBoxButton.OK);
                return;
            }
            penaltyVM.Edit(txtName.Text, txtDescription.Text, decimal.Parse(txtPrice.Text), penalty.Id);
            Clear();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }
    }
}
