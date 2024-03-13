using System.Windows;
using System.Windows.Controls;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ucEditAuthor.xaml
    /// </summary>
    public partial class ucEditAuthor : UserControl
    {
        AuthorViewModel authorVM = new AuthorViewModel();
        Author author = new Author();
        public ucEditAuthor(object value)
        {
            InitializeComponent();
            author = value as Author;
            Init();
        }

        public void Init()
        {
            txtName.Text = author.Name;
            dpBoF.SelectedDate = author.boF;
            txtDesciption.Text = author.Description;
            txtSummary.Text = author.Summary;
        }

        public void Clear()
        {
            txtName.Text = string.Empty;
        }

        private bool isEmpty()
        {
            if (txtName.Text == string.Empty && txtDesciption.Text == string.Empty && dpBoF.Text == string.Empty)
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
            authorVM.Edit(txtName.Text, txtDesciption.Text, dpBoF.SelectedDate.Value, txtSummary.Text, author.Id);
            Clear();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }
    }
}
