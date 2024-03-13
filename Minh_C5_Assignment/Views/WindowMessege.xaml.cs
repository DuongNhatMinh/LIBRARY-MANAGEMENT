using System.Windows;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for WindowMessege.xaml
    /// </summary>
    public partial class WindowMessege : Window
    {
        public WindowMessege()
        {
            InitializeComponent();
        }

        public void Shutdown()
        {
            this.Close();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
                this.WindowState = WindowState.Normal;
            else
                this.WindowState = WindowState.Maximized;
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
