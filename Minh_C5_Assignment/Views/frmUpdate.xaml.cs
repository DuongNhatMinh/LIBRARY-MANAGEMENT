using System.Collections.ObjectModel;
using System.Windows;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for frmUpdate.xaml
    /// </summary>
    public partial class frmUpdate : Window
    {
        Reader AdultReader { get; set; }
        Adult Adult { get; set; }
        ObservableCollection<Reader> ChildReaders { get; set; }
        public string value = string.Empty;

        public frmUpdate(object adultReader, object adult, object childReaders, int op)
        {
            InitializeComponent(); this.AdultReader = adultReader as Reader;
            this.Adult = adult as Adult;
            this.ChildReaders = childReaders as ObservableCollection<Reader>;

            if (op == 0)
                btnOK.Content = "Lock";
            else
                btnOK.Content = "UnLock";
            tblName.Text = string.Format("Full Name: {0} {1}", AdultReader.LName, AdultReader.FName);
            tblBOF.Text = string.Format("BOF: {0:dd/MM/yyyy}", AdultReader.boF);
            tblType.Text = string.Format("Reader Type: {0}", AdultReader.ReaderType);
            tblCreatedAt.Text = string.Format("CreatedAt: {0:dd/MM/yyyy}", AdultReader.CreatedAt);
            tblModifiedAt.Text = string.Format("ModifitedAt: {0:dd/MM/yyyy}", AdultReader.ModifiedAt);
            tblStatus.Text = string.Format("Status: {0}", AdultReader.Status);

            tblAddress.Text = string.Format("Address: {0}", Adult.Address);
            tblIdentify.Text = string.Format("Identify: {0}", Adult.Identify);
            tblCity.Text = string.Format("City: {0}", Adult.City);
            tblPhone.Text = string.Format("Phone: {0}", Adult.Phone);
            tblExpDate.Text = string.Format("ExpDate: {0:dd/MM/yyyy}", Adult.ExpireDate);
            tblCreated.Text = string.Format("CreatedAt: {0:dd/MM/yyyy}", Adult.CreatedAt);
            tblModifited.Text = string.Format("ModifitedAt: {0:dd/MM/yyyy}", Adult.ModifiedAt);
            tblStatusA.Text = string.Format("Status: {0}", Adult.Status);
            dtgChilds.ItemsSource = ChildReaders;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            value = "No";
            this.Close();

        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            value = "Yes";
            this.Close();
        }
    }
}
