
using System;
using System.Windows;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;
using System.Runtime.CompilerServices;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ucAddAdult.xaml
    /// </summary>
    public partial class ucAddAdult : UserControl, INotifyPropertyChanged
    {
        AdultViewModel adultVM = new AdultViewModel();
        ReaderViewModel readerVM = new ReaderViewModel();
        ParameterViewModel parameterVM = new ParameterViewModel();
        ProvinceViewModel provinceVM = new ProvinceViewModel();

        private string _LName;

        public string LName
        {
            get { return _LName; }
            set
            {
                _LName = value;
                OnPropertyChanged();
            }
        }
        private string _FName;

        public string FName
        {
            get { return _FName; }
            set
            {
                _FName = value;
                OnPropertyChanged();
            }
        }

        public string this[string columnName]
        {
            get
            {
                string res = null;
                switch (columnName)
                {
                    case "LName":
                        if (string.IsNullOrEmpty(LName))
                        {
                            lbLName.Content = "Last Name: ";
                            res = "Last Name cannot be empty";
                            lbLName.Content += res;
                        }
                        else
                            lbLName.Content = "Last Name: ";
                        break;
                    case "FName":
                        if (string.IsNullOrEmpty(FName))
                        {
                            lbFName.Content = "First Name: ";
                            res = "First Name cannot be empty";
                            lbFName.Content += res;
                        }
                        else
                            lbFName.Content = "First Name: ";
                        break;
                }
                return res;
            }
        }

        bool check = true;
        int length = 0;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ucAddAdult()
        {
            InitializeComponent();
            txtExpDate.Text = DateTime.Now.AddYears(1).ToString();
            DataContext = this;
            Init();
        }

        public void Init()
        {
            foreach(var item in provinceVM.repoProvince.Items)
            {
                cbCity.Items.Add(item.Name);
            }
        }

        private bool isEmpty()
        {
            if (txtLName.Text == string.Empty)
                return true;
            if (txtFName.Text == string.Empty)
                return true;
            if (txtAddress.Text == string.Empty)
                return true;
            if (txtPhone.Text == string.Empty)
                return true;
            if(txtIdentify.Text == string.Empty)
                return true;
            return false;
        }

        private void ClearTextBox()
        {
            txtLName.Clear();
            txtFName.Clear();
            txtAddress.Clear();
            cbCity.SelectedIndex = -1;
            txtPhone.Clear();
            txtIdentify.Clear();
            dpBoF.SelectedDate = null;
            lbBoF.Content = null;
            txtExpDate.Text = DateTime.Now.AddYears(1).ToString();
            lbPhone.Content = "Phone:";
            lbIdentify.Content = "Identify:";
            txtLName.Focus();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearTextBox();
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

        private void dpBoF_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime currentDate = DateTime.Now;
            if ((sender as DatePicker).SelectedDate != null)
            {
                DateTime selectedDate = (sender as DatePicker).SelectedDate.Value;

                lbBoF.Content = (sender as DatePicker).SelectedDate.Value.ToString().Split(' ')[0];

                int age = currentDate.Year - selectedDate.Year;
                Parameter parameter = parameterVM.repoParameter.GetByID("QD7");
                int adultAge = int.Parse(parameter.Value);

                if (age < adultAge)
                {
                    lbBoF.Content += " - Not old enough!";
                }
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (isEmpty())
            {
                MessageBox.Show("Text box is not left empty!", "Notify", MessageBoxButton.OK);
                return;
            }
            if (lbBoF.Content == null)
            {
                MessageBox.Show("Selected Date Of Birth!", "Notify", MessageBoxButton.OK);
                return;
            }
            if (lbBoF.Content.ToString().Contains(" - Not old enough!"))
            {
                MessageBox.Show("Not old enough to create an adult reader", "Notify", MessageBoxButton.OK);
                return;
            }
            readerVM.AddReader(txtLName.Text, txtFName.Text, dpBoF.SelectedDate.Value, true);
            adultVM.Add(txtIdentify.Text, txtAddress.Text, cbCity.Items[cbCity.SelectedIndex].ToString(), txtPhone.Text, txtExpDate.Text);
            MessageBox.Show("Add Adult reader successfully!", "Notify", MessageBoxButton.OK);
            ClearTextBox();
        }

        private void txtLName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text != null && char.IsDigit(e.Text[0]))
            {
                e.Handled = true;
            }
        }

        private void txtIdentify_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (txtIdentify.Text.Length == 12)
                return;
            if (e.Text != null && !char.IsDigit(e.Text[0]))
            {
                e.Handled = true;
            }
            else if(txtIdentify.LineCount < 12)
            {
                if (check)
                {
                    lbIdentify.Content += " - Not enough Identify 12 number!";
                    check = false;
                }
                length++;
            }
            if (length == 12)
            {
                lbIdentify.Content = "Identify:";
                length = 0;
                check = true;
            }
        }
    }
}
