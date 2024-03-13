using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ucAddChild.xaml
    /// </summary>
    public partial class ucAddChild : UserControl, INotifyPropertyChanged
    {
        ReaderViewModel readerVM = new ReaderViewModel();
        AdultViewModel adultVM = new AdultViewModel();
        ChildViewModel childVM = new ChildViewModel();
        ParameterViewModel parameterVM = new ParameterViewModel();
        string idAdult = string.Empty;
        Utility ult = new Utility();
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

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public ucAddChild()
        {
            InitializeComponent();
            DataContext = this;
            init();
        }

        private void init()
        {
            cbAdult.Items.Clear();
            Parameter parameter = parameterVM.repoParameter.GetByID("QD1");
            int value = int.Parse(parameter.Value);
            int Quantity = 0;

            for (int i = 0; i < adultVM.repoAdult.Items.Count; i++)
            {
                for (int j = 0; j < childVM.repoChild.Items.Count; j++)
                {
                    if (adultVM.repoAdult.Items[i].IdReader == childVM.repoChild.Items[j].IdAdult && childVM.repoChild.Items[j].Status == true)
                    {
                        Quantity++;
                    }  
                }
                if (Quantity != value)
                {
                    cbAdult.Items.Add(adultVM.repoAdult.Items[i].Identify);
                    cbAdult.SelectionChanged += CbAdult_SelectionChanged; 
                }
                Quantity = 0;
            }
        }

        private void CbAdult_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbAdult.SelectedIndex == -1)
                return;
            for (int i = 0; i < adultVM.repoAdult.Items.Count; i++)
            {
                if (adultVM.repoAdult.Items[i].Identify == cbAdult.Items[cbAdult.SelectedIndex].ToString())
                {
                    for(int j = 0; j < readerVM.repoReader.Items.Count; j++)
                    {
                        if (adultVM.repoAdult.Items[i].IdReader == readerVM.repoReader.Items[j].Id)
                        {
                            string lName = readerVM.repoReader.Items[j].LName.ToString();
                            string fName = readerVM.repoReader.Items[j].FName.ToString();
                            string fullName = lName + " " + fName;
                            txtFNameAdult.Text = fullName;
                            idAdult = readerVM.repoReader.Items[j].Id;
                        }
                    } 
                }
            }
        }

        private bool isEmpty()
        {
            if (txtLName.Text == string.Empty)
                return true;
            if (txtFName.Text == string.Empty)
                return true;
            return false;
        }

        private void ClearTextBox()
        {
            txtLName.Clear();
            txtFName.Clear();
            dpBoF.SelectedDate = null;
            lbBoF.Content = null;
            cbAdult.SelectedIndex = -1;
            txtFNameAdult.Clear();
            txtLName.Focus();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearTextBox();
        }

        private void dpBoF_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime currentDate = DateTime.Now;
            if ((sender as DatePicker).SelectedDate != null)
            {
                DateTime selectedDate = (sender as DatePicker).SelectedDate.Value;
                lbBoF.Content = (sender as DatePicker).SelectedDate.Value.ToString().Split(' ')[0];

                if(selectedDate > currentDate)
                {
                    lbBoF.Content = "Selected Date is greater than Current Date!";
                    return;
                }
                int age = currentDate.Year - selectedDate.Year;
                Parameter parameter = parameterVM.repoParameter.GetByID("QD7");
                int adultAge = int.Parse(parameter.Value);

                if (age > adultAge)
                {
                    lbBoF.Content = "Over the prescribed Age!";
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
                MessageBox.Show("Slected Date Of Birth!", "Notify", MessageBoxButton.OK);
                return;
            }
            if (lbBoF.Content.ToString().Contains("Over the prescribed Age!"))
            {
                MessageBox.Show("Too old age to create an child reader", "Notify", MessageBoxButton.OK);
                return;
            }
            if (lbBoF.Content.ToString().Contains("Selected Date is greater than Current Date!"))
            {
                MessageBox.Show("Date is greater than Current Date", "Notify", MessageBoxButton.OK);
                return;
            }
            if (cbAdult.SelectedIndex == -1)
            {
                MessageBox.Show("Please Selected Guardian!", "Notify", MessageBoxButton.OK);
                return;
            }
            readerVM.AddReader(txtLName.Text, txtFName.Text, dpBoF.SelectedDate.Value, false);
            childVM.AddChild(idAdult);
            ClearTextBox();
            init();
        }

        private void txtLName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text != null && char.IsDigit(e.Text[0]))
            {
                e.Handled = true;
            }
        }
    }
}