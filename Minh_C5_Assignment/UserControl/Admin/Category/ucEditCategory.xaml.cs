using System.Windows;
using System.Windows.Controls;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ucEditCategory.xaml
    /// </summary>
    public partial class ucEditCategory : UserControl
    {
        CategoryViewModel categoryVM = new CategoryViewModel();
        Category category = new Category();
        public ucEditCategory(object value)
        {
            InitializeComponent();
            category = value as Category;
            Init();
        }

        public void Init()
        {
            txtName.Text = category.Name;
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

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (isEmpty())
            {
                MessageBox.Show("Text box is not left empty!", "Notify", MessageBoxButton.OK);
                return;
            }
            categoryVM.Edit(txtName.Text, category.Id);
            Clear();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }
    }
}
