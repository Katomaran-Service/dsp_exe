using BespokeFusion;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
    /// Interaction logic for store_purchase.xaml
    /// </summary>
    public partial class store_purchase : Page
    {
        public static DataTable dt;
        public class Item
        {
            public string SNO { get; set; }
            public string ITEM { get; set; }
            public string CURRENT { get; set; }
            public string THRESHOLD { get; set; }
            public string PURCHASE { get; set; }
            public string STATUS { get; set; }
            public string QUANTITY { get; set; }
        }

        public List<Item> _items = new List<Item>();
        public List<Item> Items
        {
            get { return _items; }
            set { _items = value; }
        }
        public store_purchase()
        {
            InitializeComponent();
            table_update();
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
        private void backbut_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/store.xaml", UriKind.RelativeOrAbsolute));
        }
        public void table_update()
        {
            dt = dbhandler.inventory_table();
            String status = String.Empty;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                _items.Add(new Item { SNO = (i + 1).ToString(), ITEM = dr["items"].ToString(), CURRENT = dr["current_unit"].ToString(), THRESHOLD = dr["threshold_unit"].ToString(),PURCHASE=dr["order_amount"].ToString(), STATUS = dr["status"].ToString(), QUANTITY = "0" });

            }
            inventory_table.ItemsSource = Items;
            inventory_table.Items.Refresh();
            inventory_table.SelectedIndex = 0;
        }

        private void print_but_Click(object sender, RoutedEventArgs e)
        {
            var msg = new CustomMaterialMessageBox
            {
                TxtMessage = { Text = "are you sure ? ", Foreground = Brushes.Black },
                TxtTitle = { Text = "PURCHASE ORDER", Foreground = Brushes.Black },
                BtnOk = { Content = "Yes" },
                BtnCancel = { Content = "No" },
                // MainContentControl = { Background = Brushes.MediumVioletRed },
                TitleBackgroundPanel = { Background = Brushes.Yellow },

                BorderBrush = Brushes.Yellow
            };

            msg.Show();
            var results = msg.Result;
            if (results == MessageBoxResult.OK)
            {
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.FileName = "purchase order"; // Default file name
                dlg.DefaultExt = ".pdf"; // Default file extension
                dlg.Filter = "PDF document (.pdf)|*.pdf"; // Filter files by extension
                // Show save file dialog box
                Nullable<bool> result = dlg.ShowDialog();

                // Process save file dialog box results
                if (result == true)
                {
                    string filename = dlg.FileName;
                    Document document = new Document(PageSize.A4, 10, 10, 10, 10);
                    PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filename, FileMode.Create));
                    File.SetAttributes(filename, FileAttributes.Normal);
                    document.Open();
                    string h1 = "\n\n\n\n\n\n\n\n\n\nPURCHASE ORDER\n\n\n";
                    iTextSharp.text.Paragraph p1 = new iTextSharp.text.Paragraph();
                    p1.Alignment = Element.ALIGN_CENTER;
                    p1.Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20f, BaseColor.BLACK);
                    p1.Add(h1);
                    document.Add(p1);
                    iTextSharp.text.Paragraph p3 = new iTextSharp.text.Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                    document.Add(p3);
                    iTextSharp.text.Paragraph p4 = new iTextSharp.text.Paragraph("\n\n\n");
                    document.Add(p4);
                    PdfPTable table1 = new PdfPTable(2);
                    table1.AddCell("ITEM");
                    table1.AddCell("QUANTITY");
                    try
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
                            string a = o.ToString();
                            if (o != DBNull.Value)
                            {
                                if (ds.Rows[i][6].ToString() != "0")
                                {
                                    double quantity = Convert.ToDouble(ds.Rows[i][4]) + Convert.ToDouble(ds.Rows[i][6]);
                                    if (quantity >= 0)
                                    {
                                        bool success = dbhandler.purchase_update(ds.Rows[i][1].ToString(), quantity.ToString());
                                        if (success)
                                        {

                                            //log += "ITEM:" + ds.Rows[i][0].ToString() + " PREVIOUS ORDER:" + ds.Rows[i][3].ToString() + " RECENT ORDER:" + ds.Rows[i][5].ToString() + " STATUS: ordered" + " ENTRY :" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                                            table1.AddCell(ds.Rows[i][1].ToString());
                                            table1.AddCell(ds.Rows[i][6].ToString());

                                        }

                                        else
                                            MessageBox.Show("FAIL");
                                    }

                                    else
                                    {
                                        MessageBox.Show(ds.Rows[i][0].ToString() + ": VALUE CAN'T BE LESS THAN ZERO", "WARNING");
                                    }
                                }
                                

                            }
                        }



                        document.Add(table1);
                        document.Close();
                    }
                    catch (Exception m)
                    {
                        MessageBox.Show(m.Message);
                    }

                    MaterialMessageBox.Show(@"Purchase order generated in "+filename);
                    // dbhandler.log_update(dbhandler.Storelog, log);
                    Items.Clear();
                    table_update();
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
    }
    }
