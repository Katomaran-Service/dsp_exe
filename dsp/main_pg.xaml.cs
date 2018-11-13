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
    /// Interaction logic for main_pg.xaml
    /// </summary>
    public partial class main_pg : Page
    {
        public main_pg()
        {
            InitializeComponent();
            date.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            tb1.Text = dbhandler.name;
            home_list.Background = new SolidColorBrush(Colors.Wheat);
            sub_frame.Content = new home();
        }
        

        private void home_Click(object sender, RoutedEventArgs e)
        {
            home_list.Background = new SolidColorBrush(Colors.Wheat);
            fb_list.Background = new SolidColorBrush(Colors.Transparent);
            fd_list.Background = new SolidColorBrush(Colors.Transparent);
            hk_list.Background= new SolidColorBrush(Colors.Transparent);
            store_list.Background = new SolidColorBrush(Colors.Transparent);
            report_list.Background = new SolidColorBrush(Colors.Transparent);
            admin_list.Background = new SolidColorBrush(Colors.Transparent);
            sub_frame.Content = new home();
        }

        private void fd_Click(object sender, RoutedEventArgs e)
        {
            home_list.Background = new SolidColorBrush(Colors.Transparent);
            fb_list.Background = new SolidColorBrush(Colors.Transparent);
            fd_list.Background = new SolidColorBrush(Colors.Wheat);
            hk_list.Background = new SolidColorBrush(Colors.Transparent);
            store_list.Background = new SolidColorBrush(Colors.Transparent);
            report_list.Background = new SolidColorBrush(Colors.Transparent);
            admin_list.Background = new SolidColorBrush(Colors.Transparent);
            sub_frame.Content = new front_desk();
        }

        private void fb_Click(object sender, RoutedEventArgs e)
        {
            home_list.Background = new SolidColorBrush(Colors.Transparent);
            fb_list.Background = new SolidColorBrush(Colors.Wheat);
            fd_list.Background = new SolidColorBrush(Colors.Transparent);
            hk_list.Background = new SolidColorBrush(Colors.Transparent);
            store_list.Background = new SolidColorBrush(Colors.Transparent);
            report_list.Background = new SolidColorBrush(Colors.Transparent);
            admin_list.Background = new SolidColorBrush(Colors.Transparent);
            
        }

        private void hk_Click(object sender, RoutedEventArgs e)
        {
            home_list.Background = new SolidColorBrush(Colors.Transparent);
            fb_list.Background = new SolidColorBrush(Colors.Transparent);
            fd_list.Background = new SolidColorBrush(Colors.Transparent);
            hk_list.Background = new SolidColorBrush(Colors.Wheat);
            store_list.Background = new SolidColorBrush(Colors.Transparent);
            report_list.Background = new SolidColorBrush(Colors.Transparent);
            admin_list.Background = new SolidColorBrush(Colors.Transparent);
            sub_frame.Content = new hk();
        }

        private void store_Click(object sender, RoutedEventArgs e)
        {
            home_list.Background = new SolidColorBrush(Colors.Transparent);
            fb_list.Background = new SolidColorBrush(Colors.Transparent);
            fd_list.Background = new SolidColorBrush(Colors.Transparent);
            hk_list.Background = new SolidColorBrush(Colors.Transparent);
            store_list.Background = new SolidColorBrush(Colors.Wheat);
            report_list.Background = new SolidColorBrush(Colors.Transparent);
            admin_list.Background = new SolidColorBrush(Colors.Transparent);
            sub_frame.Content = new store();
        }

        private void report_Click(object sender, RoutedEventArgs e)
        {
            home_list.Background = new SolidColorBrush(Colors.Transparent);
            fb_list.Background = new SolidColorBrush(Colors.Transparent);
            fd_list.Background = new SolidColorBrush(Colors.Transparent);
            hk_list.Background = new SolidColorBrush(Colors.Transparent);
            store_list.Background = new SolidColorBrush(Colors.Transparent);
            report_list.Background = new SolidColorBrush(Colors.Wheat);
            admin_list.Background = new SolidColorBrush(Colors.Transparent);
        }

        private void b_Click(object sender, RoutedEventArgs e)
        {
            home_list.Background = new SolidColorBrush(Colors.Transparent);
            fb_list.Background = new SolidColorBrush(Colors.Transparent);
            fd_list.Background = new SolidColorBrush(Colors.Transparent);
            hk_list.Background = new SolidColorBrush(Colors.Transparent);
            store_list.Background = new SolidColorBrush(Colors.Transparent);
            report_list.Background = new SolidColorBrush(Colors.Transparent);
            admin_list.Background = new SolidColorBrush(Colors.Wheat);
        }

        private void Gridmenu_MouseEnter(object sender, MouseEventArgs e)
        {
            Gridmenu.Width = 200;
        }

        private void Gridmenu_MouseLeave(object sender, MouseEventArgs e)
        {
            Gridmenu.Width = 60;
        }
    }
}
