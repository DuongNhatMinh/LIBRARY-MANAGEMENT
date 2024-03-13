using System.Windows;
using System.Windows.Controls;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ucEditParamenter.xaml
    /// </summary>
    public partial class ucEditParamenter : UserControl
    {
        ParameterViewModel paramenterVM = new ParameterViewModel();
        Parameter _paramenter = new Parameter();
        public ucEditParamenter(object value)
        {
            InitializeComponent();
            _paramenter = value as Parameter;
            Init();
        }

        public void Init()
        {
            txtName.Text = _paramenter.Name;
            txtDescription.Text = _paramenter.Description;
            txtValue.Text = _paramenter.Value;
        }

        public void Clear()
        {
            txtName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtValue.Text = string.Empty;
        }

        private bool isEmpty()
        {
            if (txtName.Text == string.Empty && txtValue.Text == string.Empty && txtDescription.Text == string.Empty)
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
            paramenterVM.Edit(txtName.Text, txtDescription.Text, txtValue.Text, _paramenter.Id);
            Clear();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }
    }
}
