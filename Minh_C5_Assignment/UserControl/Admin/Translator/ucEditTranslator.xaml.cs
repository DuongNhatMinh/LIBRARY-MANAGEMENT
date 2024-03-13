using System.Windows;
using System.Windows.Controls;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ucEditTranslator.xaml
    /// </summary>
    public partial class ucEditTranslator : UserControl
    {
        TranslatorViewModel translatorVM = new TranslatorViewModel();
        Translator translator = new Translator();
        public ucEditTranslator(object value)
        {
            InitializeComponent();
            translator = value as Translator;
        }

        public void Init()
        {
            txtName.Text = translator.Name;
            dpBoF.SelectedDate = translator.boF;
            txtDesciption.Text = translator.Description;
            txtSummary.Text = translator.Summary;
        }

        public void Clear()
        {
            txtName.Text = string.Empty;
        }

        private bool isEmpty()
        {
            if (txtName.Text == string.Empty && txtDesciption.Text == string.Empty && dpBoF.Text == string.Empty)
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
            translatorVM.Edit(txtName.Text, txtDesciption.Text, dpBoF.SelectedDate.Value, txtSummary.Text, translator.Id);
            Clear();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }
    }
}
