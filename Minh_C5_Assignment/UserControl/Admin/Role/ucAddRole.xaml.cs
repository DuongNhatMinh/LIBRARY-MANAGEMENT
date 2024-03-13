using System.Windows;
using System.Windows.Controls;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ucAddRole.xaml
    /// </summary>
    public partial class ucAddRole : UserControl
    {
        RoleViewModel roleVM = new RoleViewModel();
        int flag = 0;
        public ucAddRole()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            foreach(var item in roleVM.repoRole.Items)
            {
                if(item.Group == "librarian")
                {
                    if(flag == 0)
                    {
                        cbGroup.Items.Add(item.Group);
                        flag = 1;
                    }
                }
            }
        }

        public void Clear()
        {
            txtName.Text = string.Empty;
            cbGroup.SelectedIndex = -1;
        }

        public bool isEmpty()
        {
            if (txtName.Text == string.Empty)
                return true;
            if (cbGroup.SelectedIndex == -1)
                return true;
            return false;
        }

        public bool isExist()
        {
            foreach(var item in roleVM.repoRole.Items)
            {
                if (item.Name == txtName.Text)
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
            if (isExist())
            {
                MessageBox.Show("Name IsExist!", "Notify", MessageBoxButton.OK);
                return;
            }

            roleVM.Add(txtName.Text, cbGroup.Items[cbGroup.SelectedIndex].ToString());
            Clear();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }
    }
}
