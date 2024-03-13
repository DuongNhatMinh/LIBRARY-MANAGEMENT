using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ucAddBookTitle.xaml
    /// </summary>
    public partial class ucAddBookTitle : UserControl
    {
        CategoryViewModel categoryVM = new CategoryViewModel();
        BookTitleViewModel bookTitleVM = new BookTitleViewModel();

        public ucAddBookTitle()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            foreach (var item in categoryVM.repoCat.Items)
            {
                cbCategory.Items.Add(item.Name);
            }
        }

        public bool IsEmpty()
        {
            if (txtName.Text == string.Empty)
                return true;
            if (txtSummary.Text == string.Empty)
                return true;
            return false;
        }

        private void Clear()
        {
            txtName.Text = string.Empty;
            txtSummary.Text = string.Empty;
            cbCategory.SelectedIndex = -1;
        }

        private void txtName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text != null && char.IsDigit(e.Text[0]))
            {
                e.Handled = true;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (IsEmpty())
            {
                MessageBox.Show("Text box is not left empty!", "Notify", MessageBoxButton.OK);
                return;
            }
            if(cbCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose Category!", "Notify", MessageBoxButton.OK);
                return;
            }
            Category category = categoryVM.repoCat.GetByName(cbCategory.Items[cbCategory.SelectedIndex].ToString());
            bookTitleVM.AddBookTitle(category.Id, txtName.Text, txtSummary.Text);
            Clear();
        }
    }
}
