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

namespace dsp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            username_txt.Text += dbhandler.name;
            main_frame.Content = new main_pg();
        }

        private void logout(object sender, RoutedEventArgs e)
        {
            this.Hide();
            login l1 = new login();
            l1.Show();
            this.Close();
            
        }

        private void close_window(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void minimize_but_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void maxi_but_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
            maxi_but.Visibility = Visibility.Collapsed;
            restore_but.Visibility = Visibility.Visible;
        }

        private void restore_but_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Normal;
            maxi_but.Visibility = Visibility.Visible;
            restore_but.Visibility = Visibility.Collapsed;
        }
    }
}
