using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ucAddFunction.xaml
    /// </summary>
    public partial class ucEditFunction : UserControl
    {
        FunctionViewModel functionVM = new FunctionViewModel();
        Function _function { get; set; }
        public ucEditFunction(object function)
        {
            InitializeComponent();
            _function = function as Function;
            Init();
        }

        public void Init()
        {
            cbIdParent.Items.Add("Null");
            ObservableCollection<Function> lstFunction = new ObservableCollection<Function>();
            foreach(var item in functionVM.repoFunction.Items)
            {
                if (item.IdParent == "")
                    lstFunction.Add(item);
            }
            foreach (var item in lstFunction)
            {
                cbIdParent.Items.Add(item.Name);
            }
            for(int i = 0; i < cbIdParent.Items.Count; i++)
            {
                Function functiontemp = functionVM.repoFunction.getbyid(_function.IdParent);
                if(functiontemp == null)
                {
                    cbIdParent.SelectedIndex = i;
                    break;
                }
                if (cbIdParent.Items[i].ToString() == functiontemp.Name)
                {
                    cbIdParent.SelectedIndex = i;
                    break;
                }
            }
            txtName.Text = _function.Name;
            txtDescription.Text = _function.Description;
            txtUrlImage.Text = _function.UrlImage;
        }

        public void Clear()
        {
            txtName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtUrlImage.Text = string.Empty;
            cbIdParent.SelectedIndex = -1;
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
            if (cbIdParent.SelectedIndex == -1)
            {
                MessageBox.Show("IdParent is not left empty!", "Notify", MessageBoxButton.OK);
                return;
            }
            functionVM.Edit(txtName.Text, txtDescription.Text, cbIdParent.Items[cbIdParent.SelectedIndex].ToString(), txtUrlImage.Text, _function.Id);
            Clear();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }
    }
}
