using System.Windows;
using System.Windows.Controls;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ucEditPublisher.xaml
    /// </summary>
    public partial class ucEditPublisher : UserControl
    {
        PublisherViewModel publisherVM = new PublisherViewModel();
        Publisher publisher = new Publisher();
        public ucEditPublisher(object value)
        {
            InitializeComponent();
            publisher = value as Publisher;
            Init();
        }

        public void Init()
        {
            txtName.Text = publisher.Name;
            txtPhone.Text = publisher.Phone;
            txtAddress.Text = publisher.Address;
        }

        public void Clear()
        {
            txtName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPhone.Text = string.Empty;
        }

        private bool isEmpty()
        {
            if (txtName.Text == string.Empty && txtAddress.Text == string.Empty && txtPhone.Text == string.Empty)
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
            publisherVM.Edit(txtName.Text, txtPhone.Text, txtAddress.Text, publisher.Id);
            Clear();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }
    }
}
