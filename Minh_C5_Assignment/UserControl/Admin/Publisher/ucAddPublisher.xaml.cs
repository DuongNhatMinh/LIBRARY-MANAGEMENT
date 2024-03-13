using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ucAddPublisher.xaml
    /// </summary>
    public partial class ucAddPublisher : UserControl
    {
        PublisherViewModel publisherVM = new PublisherViewModel();
        bool check = true;
        int length = 0;
        public ucAddPublisher()
        {
            InitializeComponent();
        }
        public void Clear()
        {
            txtName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPhone.Text = string.Empty;
        }

        private bool isEmpty()
        {
            if (txtName.Text == string.Empty && txtPhone.Text == string.Empty && txtAddress.Text == string.Empty)
                return true;
            return false;
        }

        private bool IsExist()
        {
            foreach (var item in publisherVM.repoPublisher.Items)
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
                MessageBox.Show("Publisher is Exist!", "Notify", MessageBoxButton.OK);
                return;
            }
            var publisher = new Publisher()
            {
                Id = RepositoryPublisher.GetNewID(),
                Name = txtName.Text,
                Phone = txtPhone.Text,
                Address = txtAddress.Text
            };
            publisherVM.repoPublisher.Add(publisher);
            Clear();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void txtPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (txtPhone.Text.Length == 10)
                return;
            if (e.Text != null && !char.IsDigit(e.Text[0]))
            {
                e.Handled = true;
            }
            else if (txtPhone.LineCount < 10)
            {
                if (check)
                {
                    lbPhone.Content += " - Not enough Phone 10 number!";
                    check = false;
                }
                length++;
            }
            if (length == 10)
            {
                lbPhone.Content = "Phone:";
                length = 0;
                check = true;
            }
        }
    }
}
