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
    /// Interaction logic for hk.xaml
    /// </summary>
    public partial class hk : Page
    {
        public hk()
        {
            InitializeComponent();
        }

        private void room_block_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/room_block_pg.xaml", UriKind.RelativeOrAbsolute));
        }

        private void room_clean_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/clean_room.xaml", UriKind.RelativeOrAbsolute));
        }

        private void room_release_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/room_release.xaml", UriKind.RelativeOrAbsolute));
        }

        private void occupancy_but_Click(object sender, RoutedEventArgs e)
        {
            occupancy.url = "/hk.xaml";
            NavigationService.Navigate(new Uri("/occupancy.xaml", UriKind.RelativeOrAbsolute));
        }

        private void laundry_but_Click(object sender, RoutedEventArgs e)
        {

        }

        private void hlog_but_Click(object sender, RoutedEventArgs e)
        {
            hlog.url = "hk";
            NavigationService.Navigate(new Uri("/hlog.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
