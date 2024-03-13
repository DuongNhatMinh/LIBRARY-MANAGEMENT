using System;
using System.Windows;
using System.Windows.Controls;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ucAddTranslator.xaml
    /// </summary>
    public partial class ucAddTranslator : UserControl
    {
        TranslatorViewModel translatorVM = new TranslatorViewModel();
        public ucAddTranslator()
        {
            InitializeComponent();
        }

        private void dpBoF_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime currentDate = DateTime.Now;
            if ((sender as DatePicker).SelectedDate != null)
            {
                DateTime selectedDate = (sender as DatePicker).SelectedDate.Value;

                lbbof.Content = (sender as DatePicker).SelectedDate.Value.ToString().Split(' ')[0];
            }
        }

        private bool isEmpty()
        {
            if (txtName.Text == string.Empty)
                return true;
            if (txtDesciption.Text == string.Empty)
                return true;
            if (txtSummary.Text == string.Empty)
                return true;
            return false;
        }

        private void Clear()
        {
            txtName.Clear();
            txtSummary.Clear();
            txtDesciption.Clear();
            dpBoF.SelectedDate = null;
        }

        private bool IsExist()
        {
            foreach (var item in translatorVM.repoTranslator.Items)
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
                MessageBox.Show("Translator is Exist!", "Notify", MessageBoxButton.OK);
                return;
            }
            var translator = new Translator()
            {
                Id = RepositoryAuthor.GetNewID(),
                Name = txtName.Text,
                Description = txtDesciption.Text,
                boF = dpBoF.SelectedDate.Value,
                Summary = txtSummary.Text,
                Status = true,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            };
            translatorVM.repoTranslator.Add(translator);
            Clear();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }
    }
}
