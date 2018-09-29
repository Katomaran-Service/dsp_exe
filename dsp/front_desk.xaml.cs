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
    /// Interaction logic for front_desk.xaml
    /// </summary>
    public partial class front_desk : Page
    {
        public front_desk()
        {
            InitializeComponent();
        }

        private void checkin_but_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/checkin.xaml", UriKind.RelativeOrAbsolute));
        }

        private void occupancy_but_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/occupancy.xaml", UriKind.RelativeOrAbsolute));
        }

        private void update_but_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/update_customer.xaml", UriKind.RelativeOrAbsolute));
        }

        private void checkout_but_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/checkout.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
