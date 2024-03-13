using System;
using System.Windows;
using System.Windows.Controls;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ucAddParameter.xaml
    /// </summary>
    public partial class ucAddParameter : UserControl
    {
        ParameterViewModel paramenterVM = new ParameterViewModel();
        public ucAddParameter()
        {
            InitializeComponent();
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

        private bool IsExist()
        {
            foreach (var item in paramenterVM.repoParameter.Items)
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
                MessageBox.Show("Parameter is Exist!", "Notify", MessageBoxButton.OK);
                return;
            }
            var parameter = new Parameter()
            {
                Id = RepositoryParameter.GetNewID(),
                Name = txtName.Text,
                Description = txtDescription.Text,
                Value = txtValue.Text,
                Status = true,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            };
            paramenterVM.repoParameter.Add(parameter);
            Clear();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }
    }
}
