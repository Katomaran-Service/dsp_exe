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
using System.Xml;
using static dsp.structdata;

namespace dsp
{
    /// <summary>
    /// Interaction logic for checkout.xaml
    /// </summary>
    public partial class checkout : Page
    {
        public static double amount = 0,discount=0,advance=0;
        public static bool advance_used = false,kot_used=false,room_used=false,post_used=false;
        public class Item
        {
            public string NUM { get; set; }
            public string ROOMNO { get; set; }
            public string CHECKIN { get; set; }
            public string KOT { get; set; }
            public string POST { get; set; }
            public string TARIFF { get; set; }
            public bool kot_check { get; set; }
            public bool post_check { get; set; }
            public bool room_check { get; set; }
            public bool all_check { get; set; }
            public bool all_dis { get; set; }

        }
        public List<Item> _items = new List<Item>();
        public List<Item> Items
        {
            get { return _items; }
            set { _items = value; }
        }
        public checkout()
        {
            InitializeComponent();
            string[] mod1 = dbhandler.Mode.Split(',');
            foreach (var item in mod1)
                mode_box.Items.Add(item);
        }

        private void all_select_Click(object sender, RoutedEventArgs e)
        {
            
            dynamic list = dataGrid.SelectedItems[0];
            if (checkout_amt.Text == "")
            {
                amount = 0;
            }
            if (list.kot_check == true)
            {
                Items[Convert.ToInt32(list.NUM) - 1].kot_check = false;
                amount -= Convert.ToDouble(list.KOT);
            }
            if (list.post_check == true)
            {
                Items[Convert.ToInt32(list.NUM) - 1].post_check = false;
                amount -= Convert.ToDouble(list.POST);
            }
            if (list.room_check == true)
            {
                Items[Convert.ToInt32(list.NUM) - 1].room_check = false;
                amount -= Convert.ToDouble(list.TARIFF);
            }
            if (advance_checkbox.IsChecked == true)
            {
                if(amount!=0)
                    amount -= advance;
            }
            else
            {
                amount += advance;
            }
            if (list.all_check== false)
            {
                
                Items[Convert.ToInt32(list.NUM) - 1].all_check = true;
                Items[Convert.ToInt32(list.NUM) - 1].all_dis = false;
                amount += Convert.ToDouble(list.KOT) + Convert.ToDouble(list.POST) + Convert.ToDouble(list.TARIFF);
                
            }
            else
            {
                
                Items[Convert.ToInt32(list.NUM) - 1].all_check = false;
                Items[Convert.ToInt32(list.NUM) - 1].all_dis = true;
                if(amount!=0)
                    amount -= Convert.ToDouble(list.KOT) + Convert.ToDouble(list.POST) + Convert.ToDouble(list.TARIFF);
            }   
            checkout_amt.Text = amount.ToString();
            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = Items;
        }

        private void room_select_Click(object sender, RoutedEventArgs e)
        {
            
            dynamic list = dataGrid.SelectedItems[0];
            if (list.room_check == false)
            {
                Items[Convert.ToInt32(list.NUM) - 1].room_check = true;
                amount+= Convert.ToDouble(list.TARIFF);
            }
            else
            {
                Items[Convert.ToInt32(list.NUM) - 1].room_check = false;
                amount -= Convert.ToDouble(list.TARIFF);
            }
           
            checkout_amt.Text = amount.ToString();
            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = Items;
        }

        private void post_select_Click(object sender, RoutedEventArgs e)
        {
            dynamic list = dataGrid.SelectedItems[0];
            if (list.post_check == false)
            {
                Items[Convert.ToInt32(list.NUM) - 1].post_check = true;
                amount += Convert.ToDouble(list.POST);
            }
            else
            {
                Items[Convert.ToInt32(list.NUM) - 1].post_check = false;
                amount -= Convert.ToDouble(list.POST);
            }
            checkout_amt.Text = amount.ToString();
            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = Items;
        }

        private void kot_select_Click(object sender, RoutedEventArgs e)
        {
            dynamic list = dataGrid.SelectedItems[0];
            if (list.kot_check == false)
            {
                Items[Convert.ToInt32(list.NUM) - 1].kot_check = true;
                amount += Convert.ToDouble(list.KOT);
            }
            else
            {
                Items[Convert.ToInt32(list.NUM) - 1].kot_check = false;
                amount -= Convert.ToDouble(list.KOT);
            }
            checkout_amt.Text = amount.ToString();
            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = Items;
        }

        private void advance_checkbox_Click(object sender, RoutedEventArgs e)
        {
            if (checkout_amt.Text != "")
            {
                if (advance_checkbox.IsChecked == true)
                    amount -= advance;
                else
                    amount += advance;
                checkout_amt.Text = amount.ToString();
            }
            else
            {
                advance_checkbox.IsChecked = false;
            }
           
        }

        private void checkout_but_Click(object sender, RoutedEventArgs e)
        {
            if (checkout_amt.Text != "")
            {
                if (advance_checkbox.IsChecked == false && advance_checkbox.IsEnabled==true)
                {
                    MessageBoxResult result = MessageBox.Show("Do you want to exclude advance amount", "CHECKOUT", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.No)
                    {
                        amount += advance;
                    }
                }
                checkout_update updation = new checkout_update();
                updation.checkoutdate = DateTime.Now.Date.ToString();
                updation.checkouttime = DateTime.Now.TimeOfDay.ToString();
                foreach(dynamic list in Items)
                {
                    updation.room_no = list.ROOMNO;
                   // updation.total = checkout_total.Text;
                    //updation.discount = checkout_discount.Text;
                    //updation.post_charge = checkout_post_ch.Text;
                    updation.remark = "DIRTY";
                    //updation.transaction_detail = checkout_tid1.Text;
                    updation.checkout = "1";
                }
                
            }
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (checkout_ph.Text != "PHONE NUMBER" && checkout_ph.Text != "" && Regex.Match(checkout_cc.Text+checkout_ph.Text, @"^([+91]\d[0-9]{11})$").Success)
            {
                check checkout = dbhandler.checkifPhonenumberavailable(checkout_cc.Text,checkout_ph.Text);
                {
                    if (checkout.available)
                    {
                        checkout_cust.Text = checkout.customer.name;
                        check_in_check chout = dbhandler.checkout_check(checkout_cc.Text+ checkout_ph.Text);
                        if (chout.available)
                        {
                            XmlDocument doc = new XmlDocument();
                            doc.Load("hotel_tariff.xml");
                            string[] hname= chout.customer.hotel_name.Split(',');
                            string[] roomno = chout.customer.room_no.Split(',');
                            string[] checkind = chout.customer.checkin_date.Split(',');
                            string[] checkint = chout.customer.checkin_time.Split(',');
                            string[] ckot = chout.customer.kot_amount.Split(',');
                            string[] cpost = chout.customer.post_charges.Split(',');
                            string[] ccount= chout.customer.no_of_persons.Split(',');
                            string[] rtype= chout.customer.room_type.Split(',');
                            string[] cdiscount= chout.customer.discount.Split(',');
                            string[] cadvance = chout.customer.advance_paid.Split(',');
                            string[] cadvance_use = chout.customer.advance_used.Split(',');
                            string[] ckot_use = chout.customer.kot_paid.Split(',');
                            string[] cpost_use = chout.customer.post_paid.Split(',');
                            string[] croom_use = chout.customer.room_paid.Split(',');
                            int room_count=0, room_amount=0;
                            int size = roomno.Length;
                            for(int i = 0; i < size - 1; i++)
                            {
                                string room_pcount="", room_amt="", room_xtra="", room_pxtra="";   
                                XmlNode node = doc.DocumentElement;
                                foreach (XmlNode pnode in node)
                                {
                                    if (pnode.Attributes[0].InnerText == hname[i])
                                    {
                                        XmlNodeList child = pnode.ChildNodes;
                                        foreach (XmlNode room in child)
                                        {

                                            if (room.Attributes[0].InnerText == rtype[i])
                                            {
                                                foreach (XmlNode room_ch in room.ChildNodes)
                                                {
                                                    if (room_ch.Name == "NUMBER")
                                                    {
                                                        room_pcount = room_ch.InnerText;

                                                    }
                                                    if (room_ch.Name == "NORMAL_TARIFF")
                                                    {
                                                        room_amt = room_ch.InnerText;

                                                    }
                                                    if (room_ch.Name == "EXTRA_TARIFF")
                                                    {
                                                        room_xtra = room_ch.InnerText;
                                                    }

                                                    if (room_ch.Name == "EXTRA")
                                                    {
                                                        room_pxtra = room_ch.InnerText;
                                                    }

                                                }

                                            }

                                        }
                                    }
                                }
                                if (Convert.ToInt32(ccount[i]) == Convert.ToInt32( room_pcount))
                                {
                                    room_amount = Convert.ToInt32(room_amt);
                                }
                                else
                                {
                                    room_amount = Convert.ToInt32(room_amt)+Convert.ToInt32(room_xtra);
                                }
                                TimeSpan diff = DateTime.Now.Date - DateTime.Parse(checkind[i]);
                                TimeSpan cd = TimeSpan.Parse(checkint[i]);
                                int chour = Convert.ToInt32(cd.Days);
                                int d = Convert.ToInt32(diff.Days);
                                if (DateTime.Now.Hour > 11)
                                {
                                    d++;
                                }
                                if (chour < 10)
                                {
                                    d++;
                                }

                                int val = i + 1;
                                discount =Convert.ToDouble(cdiscount[i]);
                                advance= Convert.ToDouble(cadvance[i]);
                                advance_used = Convert.ToBoolean(cadvance_use[i]);
                                kot_used= Convert.ToBoolean(ckot_use[i]);
                                post_used = Convert.ToBoolean(cpost_use[i]);
                                room_used = Convert.ToBoolean(croom_use[i]);
                                double kd = Convert.ToDouble(ckot[i]) - (Convert.ToDouble(ckot[i]) * (discount / 100));
                                double kp= Convert.ToDouble(cpost[i]) - (Convert.ToDouble(cpost[i]) * (discount / 100));
                                double kr= Convert.ToDouble(d * room_amount) - (Convert.ToDouble(d * room_amount) * (discount / 100));
                                if (kot_used)
                                    kd = 0;
                                if (post_used)
                                    kp = 0;
                                if (room_used)
                                    kr = 0;
                                _items.Add(new Item {NUM=(val).ToString(), ROOMNO=roomno[i],CHECKIN=checkind[i]+" "+checkint[i],KOT=kd.ToString(),POST=kp.ToString(),TARIFF=kr.ToString(),kot_check=false,post_check=false,room_check=false,all_check=false ,all_dis=true});
                                d = 0;
                                chour = 0;

                            }
                            advance_checkbox.IsEnabled = !advance_used;
                            checkout_adv.Text = (advance).ToString();
                            checkout_dist.Text = (discount).ToString();
                            dataGrid.ItemsSource=Items;
                            
                        }
                    }
                    else
                    {
                        MessageBox.Show("customer doesn't exist");
                    }
                }
            }
        }

        private void backbut_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/front_desk.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
