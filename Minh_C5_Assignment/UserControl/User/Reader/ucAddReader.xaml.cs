using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ucAddReader.xaml
    /// </summary>
    public partial class ucAddReader : UserControl
    {
        public ucAddReader()
        {
            InitializeComponent();
            grid.Children.Add(new ucAddAdult());
        }

        private void btnAdult_Click(object sender, RoutedEventArgs e)
        {
            grid.Children.Add(new ucAddAdult());
        }

        private void btnChild_Click(object sender, RoutedEventArgs e)
        {
            grid.Children.Add(new ucAddChild());
        }
    }
}
