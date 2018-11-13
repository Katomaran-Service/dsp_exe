using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for issue_pg.xaml
    /// </summary>
    public partial class issue_pg : Page
    {
        public static DataTable dt;
        public class Item
        {
            public string SNO { get; set; }
            public string ITEM { get; set; }
            public string CURRENT { get; set; }
            public string THRESHOLD { get; set; }
            public string STATUS { get; set; }
            public string QUANTITY { get; set; }
        }
       
        public List<Item> _items = new List<Item>();
        public List<Item> Items
        {
            get { return _items; }
            set { _items = value; }
        }
       
        public issue_pg()
        {
            InitializeComponent();
            table_update();
        }

        private void backbut_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/store.xaml", UriKind.RelativeOrAbsolute));
        }

        private void qtxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            double parsedvalue;
            if (Items != null)
            {
                string val = (sender as TextBox).Text;
                if ((double.TryParse(val, out parsedvalue)))
                {
                    int pos = inventory_table.SelectedIndex;
                    dynamic a = inventory_table.SelectedItems[0];
                    Items[pos].QUANTITY = val;
                }
                   
            }
            
        }

        private void searchbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i;
            if (Items.Count != 0)
            {
                foreach (var aitems in Items)
                {
                    if (searchbox.Text == "" || searchbox.Text == "Search")
                    {
                        i = 1;
                        inventory_table.ItemsSource = Items;
                    }
                    else
                    {
                        if (aitems.ITEM.StartsWith(searchbox.Text, StringComparison.InvariantCultureIgnoreCase))
                        {
                            inventory_table.SelectedItem = aitems;
                        }
                    }

                }
            }
        }

        private void searchbox_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (searchbox.Text == "Search")
            {
                searchbox.Text = "";
            }
            else if (searchbox.Text == "")
            {
                searchbox.Text = "Search";
            }
        }

        private void issue_but_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure?", "CONFIRMATION", MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Yes)
            {
                DataTable ds = new DataTable(typeof(Item).Name);

                //Get all the properties
                PropertyInfo[] Props = typeof(Item).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo prop in Props)
                {
                    //Defining type of data column gives proper data table 
                    var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                    //Setting column names as Property names
                    ds.Columns.Add(prop.Name, type);
                }
                foreach (Item item in inventory_table.ItemsSource)
                {
                    var values = new object[Props.Length];
                    for (int i = 0; i < Props.Length; i++)
                    {
                        //inserting property values to datatable rows
                        values[i] = Props[i].GetValue(item, null);
                    }
                    ds.Rows.Add(values);
                }
                for (int i = 0; i < ds.Rows.Count; i++)
                {
                    object o = ds.Rows[i][5];
                    if (o != DBNull.Value)
                    {
                        MessageBox.Show(ds.Rows[i][2].ToString()+ ds.Rows[i][5].ToString());
                        double balance = Convert.ToDouble(ds.Rows[i][2]) - (Convert.ToDouble(ds.Rows[i][5]));
                        string status = String.Empty;
                        if (balance >= 0)
                        {
                            if (balance > Convert.ToDouble(ds.Rows[i][3]))
                            {
                                ds.Rows[i][2] = balance;
                                status = "safe";
                            }
                            else if (balance == Convert.ToDouble(ds.Rows[i][3]))
                            {
                                ds.Rows[i][2] = balance;
                                status = "limit";
                            }
                            else
                            {
                                ds.Rows[i][2] = balance;
                                status = "low";
                            }
                            dbhandler.inventory_update(ds.Rows[i][1].ToString(), status, balance.ToString());
                            //log += "ITEM:" + ds.Rows[i][0].ToString() + " BALANCE:" + balance.ToString() + " STATUS: " + status + " ENTRY :" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"); ;
                        }

                        else
                        {
                            MessageBox.Show(ds.Rows[i][1].ToString() + ": VALUE CAN'T BE LESS THAN ZERO", "WARNING");
                        }

                    }
                }

                MessageBox.Show("DONE", "ISSUE");
                // dbhandler.log_update(dbhandler.Storelog, log);
                Items.Clear();
                table_update();
            }
        }
        public void table_update()
        {
            dt = dbhandler.inventory_table();
            String status = String.Empty;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                _items.Add(new Item { SNO = (i + 1).ToString(), ITEM = dr["items"].ToString(), CURRENT = dr["current_unit"].ToString(), THRESHOLD = dr["threshold_unit"].ToString(), STATUS = dr["status"].ToString(), QUANTITY = "0" });
                
            }
            inventory_table.ItemsSource = Items;
            inventory_table.Items.Refresh();
            inventory_table.SelectedIndex = 0;
        }
    }
}
