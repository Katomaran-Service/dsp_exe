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
using static dsp.structdata;

namespace dsp
{
    /// <summary>
    /// Interaction logic for hlog.xaml
    /// </summary>
    public partial class hlog : Page
    {
        public static string url = String.Empty;
        public class Item
        {
            public string SNO { get; set; }
            public string UNAME { get; set; }
            public string TIME { get; set; }
            public string CATEGORY { get; set; }
            public string REMARK { get; set; }
        }

        public List<Item> _items = new List<Item>();
        public List<Item> Items
        {
            get { return _items; }
            set { _items = value; }
        }
        public hlog()
        {
            InitializeComponent();
            log_switch();
        }

        private void backbut_Click(object sender, RoutedEventArgs e)
        {
            switch (url)
            {
                case "fd":
                    NavigationService.Navigate(new Uri("/front_desk.xaml", UriKind.RelativeOrAbsolute));
                    break;
                case "hk":
                    NavigationService.Navigate(new Uri("/hk.xaml", UriKind.RelativeOrAbsolute));
                    break;
                case "store":
                    NavigationService.Navigate(new Uri("/store.xaml", UriKind.RelativeOrAbsolute));
                    break;
                case "fb":
                    NavigationService.Navigate(new Uri("/hk.xaml", UriKind.RelativeOrAbsolute));
                    break;
            }
            
        }
        public void log_switch()
        {
            log_avail log = new log_avail();
            log = dbhandler.logdetails(url,DateTime.Now.Date.ToString("MM/dd/yyyy"));
            switch (url)
            {
                case "fd":
                    textBlock123.Text = "FRONT DESK LOG";
                    break;
                case "hk":
                    textBlock123.Text = "HOUSE KEEPING LOG";
                    break;
                case "store":
                    textBlock123.Text = "STORE LOG";
                    break;
                case "fb":
                    textBlock123.Text = "F&B LOG";
                    break;
            }
            if (log.avail)
            {
                string[] uname = log.detail.uname.Split(',');
                string[] time = log.detail.time.Split(',');
                string[] cate = log.detail.category.Split(',');
                string[] remark = log.detail.remark.Split(',');
                for(int i = 0; i < uname.Length - 1; i++)
                {
                    _items.Add(new Item {SNO=(i+1).ToString(),UNAME=uname[i],TIME=time[i],CATEGORY=cate[i],REMARK=remark[i] });
                }
                log_grid.ItemsSource = Items;
            }
    
            
        }
    }
}
