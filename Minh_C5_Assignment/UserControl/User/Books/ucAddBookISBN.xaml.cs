using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ucAddBookISBN.xaml
    /// </summary>
    public partial class ucAddBookISBN : UserControl
    {
        AuthorViewModel authorVM = new AuthorViewModel();
        BookTitleViewModel bookTitleVM = new BookTitleViewModel();
        BookISBNViewModel bookISBNVM = new BookISBNViewModel();
        public ucAddBookISBN()
        {
            InitializeComponent();
            Init();
        }

        public enum DisplayValues
        {
            DisplayName = 0,
            Name = 1,
            NativeName = 2,
            EnglishName = 3
        }

        private DisplayValues DisplayValueValue;
        [DefaultValue(0)]
        public DisplayValues DisplayValue
        {
            get { return DisplayValueValue; }
            set { DisplayValueValue = value; }
        }

        public void Init()
        {
            foreach (var item in authorVM.repoAuthor.Items)
            {
                cbAuthor.Items.Add(item.Name);
            }
            foreach (var item in bookTitleVM.repoBookTitle.Items)
            {
                cbBookTitle.Items.Add(item.Name);
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
            cbAuthor.SelectedIndex = -1;
            cbBookTitle.SelectedIndex = -1;
            cbLanguage.SelectedIndex = -1;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (cbBookTitle.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose BookTitle!", "Notify", MessageBoxButton.OK);
                return;
            }
            if (cbAuthor.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose Author!", "Notify", MessageBoxButton.OK);
                return;
            }
            if (cbLanguage.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose Language!", "Notify", MessageBoxButton.OK);
                return;
            }
            BookTitle bookTitle = bookTitleVM.repoBookTitle.GetByName(cbBookTitle.Items[cbBookTitle.SelectedIndex].ToString());
            Author author = authorVM.repoAuthor.GetByName(cbAuthor.Items[cbAuthor.SelectedIndex].ToString());
            bookISBNVM.AddBookISBN(bookTitle.Id, author.Id, cbLanguage.Items[cbLanguage.SelectedIndex].ToString());
            Clear();
        }
    }
}
