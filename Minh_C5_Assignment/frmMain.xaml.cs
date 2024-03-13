using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Xml;
using System.Configuration;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for frmMain.xaml
    /// </summary>
    public partial class frmMain : Window
    {
        public string connectionString = string.Empty;
        private string defaultConnectionString;
        private bool flag = false;

        public frmMain()
        {
            InitializeComponent();
            this.Loaded += FrmMain_Loaded; ;
        }

        private void FrmMain_Loaded(object sender, RoutedEventArgs e)
        {
            string xmlFilePath = "data/ServerName.xml";
            string status = null;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);

            XmlNode serverNode = xmlDoc.SelectSingleNode("/Server");

            if (serverNode != null)
            {
                status = serverNode.Attributes["Status"].Value;
                cbDataSource.Items.Add(serverNode.Attributes["Catalog"].Value.Split('=')[1]);
                cbDataSource.SelectedIndex = 0;
                cbServer.Items.Add(serverNode.Attributes["Datasource"].Value.Split('=')[1]);
                cbServer.SelectedIndex = 0;
            }
            else
            {
                Console.WriteLine("Không tìm thấy phần tử Server trong tập tin XML.");
            }
            if (status == "true")
            {
                btnConnect_Click(new object(), new RoutedEventArgs());
            }
        }

        private void Login()
        {
            if (!flag)
            {
                defaultConnectionString = ConfigurationManager.ConnectionStrings["QuanLyThuVienEntities"].ConnectionString;
                flag = true;
            }

            var connectionTemp = (string)defaultConnectionString.Clone();

            var newConnectionString = connectionTemp.Replace("initial catalog=QuanLyThuVien", $"initial catalog={cbDataSource.Text}").Replace("data source=DESKTOP-80UHT85", $"data source={cbServer.Text}");

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            ConnectionStringSettings connectionStringSetting = config.ConnectionStrings.ConnectionStrings["QuanLyThuVienEntities"];

            connectionStringSetting.ConnectionString = newConnectionString;

            config.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection("connectionStrings");

            connectionString = string.Format("Data Source={0};Initial Catalog={1};Trusted_Connection=True", cbServer.Text, cbDataSource.Text);
            
            DataProvider.Instance.connStr = connectionString;

            try
            {
                using (QuanLyThuVienEntities db = new QuanLyThuVienEntities())
                {
                    var items = db.Parameters.ToList();
                }
            }
            catch (System.Data.Entity.Core.EntityException)
            {
                MessageBox.Show("Connection Error!", "Notify", MessageBoxButton.OK, MessageBoxImage.Error);
                WriterFile("false");
                //flag = false;
                return;
            }

            WriterFile("true");

            frmLogin login = new frmLogin();
            login.Show();
            login.Focus();
            this.Close();
        }

        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            Login();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Login();
            }
        }

        private void WriterFile(string status = null)
        {
            string xmlFilePath = "Data/ServerName.xml";

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);

            XmlNode serverNode = xmlDoc.SelectSingleNode("/Server");

            if (serverNode != null)
            {
                serverNode.Attributes["Status"].Value = status;
                serverNode.Attributes["Catalog"].Value = $"initial catalog={cbDataSource.Text}";
                serverNode.Attributes["Datasource"].Value = $"data source={cbServer.Text}";

                xmlDoc.Save(xmlFilePath);
            }
        }
    }
}
