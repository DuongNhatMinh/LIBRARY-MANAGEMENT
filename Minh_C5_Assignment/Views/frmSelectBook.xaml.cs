using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for frmSelectBook.xaml
    /// </summary>
    public partial class frmSelectBook : Window
    {
        ObservableCollection<BookDTO> bookDTOs { get; set; }
        BookDTO bookdto { get; set; }
        public frmSelectBook(object value)
        {
            InitializeComponent();
            bookDTOs = value as ObservableCollection<BookDTO>;
            bookdto = new BookDTO();
            dtgBook.ItemsSource = bookDTOs;
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as Button).DataContext as BookDTO;
            bookdto = item;
            this.Close();
        }
    }
}
