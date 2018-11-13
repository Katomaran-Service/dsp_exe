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
    /// Interaction logic for store.xaml
    /// </summary>
    public partial class store : Page
    {
        public store()
        {
            InitializeComponent();
        }

        private void inventory_but_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/inventory_pg.xaml", UriKind.RelativeOrAbsolute));
        }

        private void issue_but_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/issue_pg.xaml", UriKind.RelativeOrAbsolute));
        }

        private void slog_but_Click(object sender, RoutedEventArgs e)
        {
            hlog.url = "store";
            NavigationService.Navigate(new Uri("/hlog.xaml", UriKind.RelativeOrAbsolute));
        }

      
        private void entry_but_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/entry_store_pg.xaml", UriKind.RelativeOrAbsolute));
        }

        private void purchase_but_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/store_purchase.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
