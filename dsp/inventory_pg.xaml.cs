using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for inventory_pg.xaml
    /// </summary>
    public partial class inventory_pg : Page
    {
        public static DataTable dt;
        public class Item
        {
            public string SNO { get; set; }
            public string ITEM { get; set; }
            public string CURRENT { get; set; }
            public string THRESHOLD { get; set; }
            public string STATUS { get; set; }
        }
        public List<Item> _items = new List<Item>();
        public List<Item> Items
        {
            get { return _items; }
            set { _items = value; }
        }
        public inventory_pg()
        {
            InitializeComponent();
            dt = dbhandler.inventory_table();
            String status = String.Empty;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                _items.Add(new Item { SNO = (i+1).ToString(), ITEM = dr["items"].ToString(), CURRENT = dr["current_unit"].ToString(), THRESHOLD = dr["threshold_unit"].ToString(), STATUS = dr["status"].ToString() });
                inventory_table.ItemsSource = Items;
            }
            
        }

        private void backbut_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/store.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
