using System.Windows.Controls;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ucChildInfor.xaml
    /// </summary>
    public partial class ucChildInfor : UserControl
    {
        Reader AdultReader { get; set; }
        Adult Adult { get; set; }

        Reader ChildReader { get; set; }
        Child Child { get; set; }

        public ucChildInfor(object adultReader, object adult, object childReader, object child)
        {
            InitializeComponent();
            this.AdultReader = adultReader as Reader;
            this.Adult = adult as Adult;
            this.ChildReader = childReader as Reader;
            this.Child = child as Child;

            tblNameC.Text = string.Format("Full Name: {0} {1}", ChildReader.LName, ChildReader.FName);
            tblBOFC.Text = string.Format("BOF: {0:dd/MM/yyyy}", ChildReader.boF);
            tblTypeC.Text = string.Format("Reader Type: {0}", ChildReader.ReaderType);
            tblCreatedC.Text = string.Format("CreatedAt: {0:dd/MM/yyyy}", ChildReader.CreatedAt);
            tblModifiedC.Text = string.Format("ModifitedAt: {0:dd/MM/yyyy}", ChildReader.ModifiedAt);
            tblStatusC.Text = string.Format("Status: {0}", ChildReader.Status);

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
        }
    }
}
