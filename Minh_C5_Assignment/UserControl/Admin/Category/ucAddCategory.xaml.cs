using System;
using System.Windows;
using System.Windows.Controls;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ucAddCategory.xaml
    /// </summary>
    public partial class ucAddCategory : UserControl
    {
        CategoryViewModel categoryVM = new CategoryViewModel();
        public ucAddCategory()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            txtName.Text = string.Empty;
        }

        private bool isEmpty()
        {
            if (txtName.Text == string.Empty)
                return true;
            return false;
        }

        private bool IsExist()
        {
            foreach (var item in categoryVM.repoCat.Items)
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
                MessageBox.Show("Category is Exist!", "Notify", MessageBoxButton.OK);
                return;
            }
            var category = new Category()
            {
                Id = RepositoryCategory.GetNewID(),
                Name = txtName.Text,
                Status = true,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            };
            categoryVM.repoCat.Add(category);
            Clear();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }
    }
}
