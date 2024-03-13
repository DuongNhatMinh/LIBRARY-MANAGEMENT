using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ucAddBook.xaml
    /// </summary>
    public partial class ucAddBook : UserControl
    {
        BookViewModel bookVM = new BookViewModel();
        BookISBNViewModel bookISBNVM = new BookISBNViewModel();
        PublisherViewModel publisherVM = new PublisherViewModel();
        BookTitleViewModel bookTitleVM = new BookTitleViewModel();
        TranslatorViewModel translatorVM = new TranslatorViewModel();
        BookStatusViewModel bookstatusVM = new BookStatusViewModel();

        public ucAddBook()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            foreach(var item in publisherVM.repoPublisher.Items)
            {
                cbPublisher.Items.Add(item.Name);
            }

            foreach(var item in translatorVM.repoTranslator.Items)
            {
                cbTranlator.Items.Add(item.Name);
            }

            foreach(var item in bookISBNVM.repoBookISBN.Items)
            {
                BookTitle bookTitle = bookTitleVM.repoBookTitle.GetByID(item.IdBookTitle);
                string Title = string.Format("{0} <{1}>", bookTitle.Name, item.OriginLanguage);
                cbBookISBN.Items.Add(Title);
            }

            cbLanguage.Items.Clear();
            foreach (CultureInfo culture in
                     CultureInfo.GetCultures(CultureTypes.AllCultures))
            {
                if (culture.LCID == 127) { continue; }
                cbLanguage.Items.Add(culture.DisplayName);
            }
            if (cbLanguage.Items.Count > 0)
            {
                cbLanguage.SelectedItem = CultureInfo.CurrentCulture;
            }
        }

        private void Clear()
        {
            cbBookISBN.SelectedIndex = -1;
            cbLanguage.SelectedIndex = -1;
            cbPublisher.SelectedIndex = -1;
            cbTranlator.SelectedIndex = -1;
            txtPrice.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            dpPD.SelectedDate = null;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtQuantity.Text == string.Empty)
            {
                MessageBox.Show("Please input Quantity of Book!", "Notify", MessageBoxButton.OK);
                return;
            }
            if (cbBookISBN.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose BookISBN!", "Notify", MessageBoxButton.OK);
                return;
            }
            if (dpPD.SelectedDate == null)
            {
                MessageBox.Show("Please choose PublishDate!", "Notify", MessageBoxButton.OK);
                return;
            }
            if (cbTranlator.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose Translator!", "Notify", MessageBoxButton.OK);
                return;
            }
            if (cbPublisher.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose Publisher!", "Notify", MessageBoxButton.OK);
                return;
            }
            BookISBN bookISBN = bookISBNVM.repoBookISBN.Items[cbBookISBN.SelectedIndex];
            Publisher publisher = publisherVM.repoPublisher.Items[cbPublisher.SelectedIndex];
            Translator translator = translatorVM.repoTranslator.Items[cbTranlator.SelectedIndex];
            if(bookISBN.Status == false)
            {
                bookISBNVM.Update(bookISBN, cbBookISBN.SelectedIndex);
            }
            int quantity = Int32.Parse(txtQuantity.Text);
            for(int i = 0; i < quantity; i++)
                bookVM.AddBook(bookISBN.ISBN, publisher.Id, translator.Id, cbLanguage.Items[cbLanguage.SelectedIndex].ToString(), dpPD.SelectedDate.Value, quantity, Decimal.Parse(txtPrice.Text), bookstatusVM.repoBookStatus.Items[0].Id);
            Clear();
        }

        private void dpPD_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime currentDate = DateTime.Now;
            if ((sender as DatePicker).SelectedDate != null)
            {
                DateTime selectedDate = (sender as DatePicker).SelectedDate.Value;
                lbPD.Content = (sender as DatePicker).SelectedDate.Value.ToString().Split(' ')[0];

                if (selectedDate > currentDate)
                {
                    lbPD.Content = "Selected Date is greater than Current Date!";
                    return;
                }
            }
        }

        private void txtQuantity_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text != null && !char.IsDigit(e.Text[0]))
            {
                e.Handled = true;
            }
        }

        private void txtPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text != null && !char.IsDigit(e.Text[0]))
            {
                e.Handled = true;
            }
        }
    }
}
