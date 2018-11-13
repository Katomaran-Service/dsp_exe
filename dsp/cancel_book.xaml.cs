using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for cancel_book.xaml
    /// </summary>
    public partial class cancel_book : Page
    {
        public class Item
        {
            public string STATUS { get; set; }
            public string ROOMTYPE { get; set; }
            public string ROOMNO { get; set; }
            public string CHECKIN1 { get; set; }
            public string CHECKOUT1 { get; set; }
        }
        public List<Item> _items = new List<Item>();
        public List<Item> Items
        {
            get { return _items; }
            set { _items = value; }
        }
        public cancel_book()
        {
            InitializeComponent();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (phonetxt.Text != "PHONE NUMBER" && phonetxt.Text != "" && Regex.Match(cctxt.Text + phonetxt.Text, @"^([+91]\d[0-9]{11})$").Success)
            {
                check phoneav = dbhandler.checkifPhonenumberavailable(cctxt.Text, phonetxt.Text);
                if (phoneav.available)
                {
                    book_avail avail = new book_avail();
                    avail = dbhandler.book_retrieve(cctxt.Text+ phonetxt.Text);
                    if (avail.available == "true")
                    {
                        string[] roomtypet = avail.room_type.Split(',');
                        string[] bokkedtt = avail.book_time.Split(',');
                        string[] checkoutd = avail.checkout_date.Split(',');
                        string[] checkoutt = avail.checkout_time.Split(',');
                        string[] countt = avail.count.Split(',');
                        string[] advancet = avail.advance_paid.Split(',');
                        string[] ramountt = avail.amount.Split(',');
                        for (int i = 0; i < (roomtypet.Length - 1); i++)
                        {
//                            _items.Add(new Item { ROOMNO = "book", ROOMTYPE = roomtypet[i], COUNT = countt[i], AMOUNT = ramountt[i], CHECKIN1 = (avail.book_date + " " + bokkedtt[i] + ":00 HR"), CHECKOUT1 = (checkoutd[i] + " " + checkoutt[i] + ":00 HR"), STATUS = "booked", butname = "EDIT", but_color = "Blue", but_stat = "1" });

//                            ramttotal += Convert.ToInt32(ramountt[i]);
 //                           info_ramount.Text = ramttotal.ToString();
  //                          info_ramount.Foreground = new SolidColorBrush(Colors.Black);
                            //room_list_con.Items.Add(new roomlist() { ROOMNO = "", ROOMTYPE = roomtypet[i], COUNT = countt[i], AMOUNT = ramountt[i], CHECKIN1 = (avail.book_date + " " + bokkedtt[i] + ":00 HR"), CHECKOUT1 = (checkoutd[i] + " " + checkoutt[i] + ":00 HR"), STATUS = "booked" });
                        }
   //                     roomgrid.ItemsSource = Items;



                    }
                }
            }
        }

        private void backbut_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
