using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Xml;
using System.Collections.ObjectModel;
using static dsp.structdata;
using BespokeFusion;
using System.Text;

namespace dsp
{
    /// <summary>
    /// Interaction logic for checkin.xaml
    /// </summary>
    public partial class checkin : Page
    {
        public String room_amt, room_xtra, room_pcount, room_pxtra,room_no_val="",book_room="",book_count="";
        public int r_total,val=0,ramttotal=0;
        public ObservableCollection<string> roomtype1 { get; set; }
        public ObservableCollection<string> roomno1 { get; set; }
        public class Item
        {
            public string STATUS { get; set; }
            public string ROOMTYPE { get; set; }
            public string ROOMNO { get; set; }
            public string CHECKIN1 { get; set; }
            public string CHECKOUT1 { get; set; }
            public string COUNT { get; set; }
            public string AMOUNT { get; set; }
            public string butname { get; set; }
            public string but_color { get; set; }
            public string but_stat { get; set; }
        }
        public List<Item> _items = new List<Item>();
        public List<Item> Items
        {
            get { return _items; }
            set { _items = value; }
        }
        public checkin()
        {
            InitializeComponent();
            val = 1;
            checkin_time.Items.Add("0");
            checkout_time.Items.Add("0");
            modify_book_but.Visibility = Visibility.Hidden;
            visit_count.Text = "0";
            for (int i = DateTime.Now.Hour; i < 24; i++)
                checkin_time.Items.Add(i);
            for (int i = 0; i < 24; i++)
            {
                checkout_time.Items.Add(i);
            }
            checkin_date.SelectedDate = DateTime.Today;
            checkout_date.DisplayDateStart= DateTime.Today.AddDays(1);
            checkout_date.SelectedDate = DateTime.Today.AddDays(1);
            checkout_time.Text = "10";
            checkin_time.Text = DateTime.Now.TimeOfDay.Hours.ToString();
            info_single.IsChecked = true;
            
            info_other_id1.IsEnabled = false;
            string[] id = dbhandler.Id_proofs.Split(',');
            foreach (var item in id)
            {
                info_idproof.Items.Add(item);
            }
            string[] plan = dbhandler.plan_hotel.Split(',');
            foreach (var item in plan)
                info_plan.Items.Add(item);
            string[] seg = dbhandler.Segment.Split(',');
            foreach (var item in seg)
                info_segment.Items.Add(item);
            string[] mod1 = dbhandler.Mode.Split(',');
            foreach (var item in mod1)
                info_mode.Items.Add(item);
            XmlReader reader = XmlReader.Create("hotel_tariff.xml");
            while (reader.Read())
            {
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "HOTEL"))
                {
                    if (reader.HasAttributes)
                    {
                        hotel_name.Items.Add(reader.GetAttribute("name"));
                    }
                }
            }
            dbhandler.roomxml();
            hotel_name.SelectedItem = hotel_name.Items[0];
            room_type.SelectedItem = room_type.Items[0];
            info_plan.SelectedItem = info_plan.Items[0];
            hotel_name.IsEnabled = false;
            cform_grid.IsEnabled = false;
            
        }

        public class checkedBoxIte
        {
            public bool MyBool { get; set; }
            public string rtypes { get; set; }
            public string rnos { get; set; }
            public string count { get; set; }

        }

        private void info_name_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (info_name1.Text == "NAME")
            {
                info_name1.Text = "";
                info_name1.Foreground = new SolidColorBrush(Colors.Black);
            }
            else if (info_name1.Text == "")
            {
                info_name1.Text = "NAME";
                info_name1.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void textBox_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (info_str1.Text == "ADDRESS LINE")
            {
                info_str1.Text = "";
                info_str1.Foreground = new SolidColorBrush(Colors.Black);
            }
            else if (info_str1.Text == "")
            {
                info_str1.Text = "ADDRESS LINE";
                info_str1.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void infod_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

            if (info_dist1.Text == "DISTRICT NAME")
            {
                info_dist1.Text = "";
                info_dist1.Foreground = new SolidColorBrush(Colors.Black);
            }
            else if (info_dist1.Text == "")
            {
                info_dist1.Text = "DISTRICT NAME";
                info_dist1.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void info_state_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (info_state1.Text == "STATE NAME")
            {
                info_state1.Text = "";
                info_state1.Foreground = new SolidColorBrush(Colors.Black);
            }
            else if (info_state1.Text == "")
            {
                info_state1.Text = "STATE NAME";
                info_state1.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void info_country_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (info_country1.Text == "COUNTRY NAME")
            {
                info_country1.Text = "";
                info_country1.Foreground = new SolidColorBrush(Colors.Black);
            }
            else if (info_country1.Text == "")
            {
                info_country1.Text = "COUNTRY NAME";
                info_country1.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void info_post_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (info_pincode1.Text == "PIN CODE")
            {
                info_pincode1.Text = "";
                info_pincode1.Foreground = new SolidColorBrush(Colors.Black);
            }
            else if (info_pincode1.Text == "")
            {
                info_pincode1.Text = "PIN CODE";
                info_pincode1.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void info_ph_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (info_ph1.Text == "PHONE NUMBER")
            {
                info_ph1.Text = "";
                info_ph1.Foreground = new SolidColorBrush(Colors.Black);
            }
            else if (info_ph1.Text == "")
            {
                info_ph1.Text = "PHONE NUMBER";
                info_ph1.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void info_mail_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (info_mail1.Text == "MAIL ID")
            {
                info_mail1.Text = "";
                info_mail1.Foreground = new SolidColorBrush(Colors.Black);
            }
            else if (info_mail1.Text == "")
            {
                info_mail1.Text = "MAIL ID";
                info_mail1.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void cc1_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (cc1.Text == "+91")
            {
                cc1.Text = "";
                cc1.Foreground = new SolidColorBrush(Colors.Black);
            }
            else if (cc1.Text == "")
            {
                cc1.Text = "+91";
                cc1.Foreground = new SolidColorBrush(Colors.Black);
            }

        }

        private void infopass_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (info_passport1.Text == "PASSPORT NUMBER")
            {
                info_passport1.Text = "";
                info_passport1.Foreground = new SolidColorBrush(Colors.Black);
            }
            else if (info_passport1.Text == "")
            {
                info_passport1.Text = "PASSPORT NUMBER";
                info_passport1.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void info_otherid_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (info_other_id1.Text == "OTHERS")
            {
                info_other_id1.Text = "";
                info_other_id1.Foreground = new SolidColorBrush(Colors.Black);
            }
            else if (info_other_id1.Text == "")
            {
                info_other_id1.Text = "OTHERS";
                info_other_id1.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void info_idnum_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (info_id_num1.Text == "ID NUMBER")
            {
                info_id_num1.Text = "";
                info_id_num1.Foreground = new SolidColorBrush(Colors.Black);
            }
            else if (info_id_num1.Text == "")
            {
                info_id_num1.Text = "ID NUMBER";
                info_id_num1.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void infoplace_pass_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (info_place_pass1.Text == "PLACE OF ISSUE")
            {
                info_place_pass1.Text = "";
                info_place_pass1.Foreground = new SolidColorBrush(Colors.Black);
            }
            else if (info_place_pass1.Text == "")
            {
                info_place_pass1.Text = "PLACE OF ISSUE";
                info_place_pass1.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void info_place_visa_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (info_place_visa1.Text == "PLACE OF ISSUE")
            {
                info_place_visa1.Text = "";
                info_place_visa1.Foreground = new SolidColorBrush(Colors.Black);
            }
            else if (info_place_visa1.Text == "")
            {
                info_place_visa1.Text = "PLACE OF ISSUE";
                info_place_visa1.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void info_arrived_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

            if (info_arrived1.Text == "ARRIVED FROM")
            {
                info_arrived1.Text = "";
                info_arrived1.Foreground = new SolidColorBrush(Colors.Black);
            }
            else if (info_arrived1.Text == "")
            {
                info_arrived1.Text = "ARRIVED FROM";
                info_arrived1.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void infoduration_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (info_duration1.Text == "DURATION OF STAY")
            {
                info_duration1.Text = "";
                info_duration1.Foreground = new SolidColorBrush(Colors.Black);
            }
            else if (info_duration1.Text == "")
            {
                info_duration1.Text = "DURATION OF STAY";
                info_duration1.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void add_room_Click(object sender, RoutedEventArgs e)
        {

        }

        private void info_adv_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (info_advance_paid.Text == "ADVANCE PAID")
            {
                info_advance_paid.Text = "";
                info_advance_paid.Foreground = new SolidColorBrush(Colors.Black);
            }
            else if (info_advance_paid.Text == "")
            {
                info_advance_paid.Text = "ADVANCE PAID";
                info_advance_paid.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void infodis_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (info_discount.Text == "DISCOUNT")
            {
                info_discount.Text = "";
                info_discount.Foreground = new SolidColorBrush(Colors.Black);
            }
            else if (info_discount.Text == "")
            {
                info_discount.Text = "DISCOUNT";
                info_discount.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void infotid_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (info_tid.Text == "TRANSACTION ID")
            {
                info_tid.Text = "";
                info_tid.Foreground = new SolidColorBrush(Colors.Black);
            }
            else if (info_tid.Text == "")
            {
                info_tid.Text = "TRANSACTION ID";
                info_tid.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void infoAMT_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (info_ramount.Text == "ROOM AMOUNT")
            {
                info_ramount.Text = "";
                info_ramount.Foreground = new SolidColorBrush(Colors.Black);
            }
            else if (info_ramount.Text == "")
            {
                info_ramount.Text = "ROOM AMOUNT";
                info_ramount.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void info_ph1_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (Regex.Match(info_ph1.Text, @"^([0-9]{10})$").Success)
            {
               /* phone_state.Text = "";
                info_ph1.Foreground = new SolidColorBrush(Colors.Black);
                check checkin = dbhandler.checkifPhonenumberavailable(cc1.Text,info_ph1.Text);
                if (checkin.available)
                {
                    MessageBoxResult result = MessageBox.Show("Phone number already exist\nDo you want to load?", "CUSTOMER DETAILS", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        info_name1.Text = checkin.customer.name;
                        info_str1.Text = checkin.customer.address;
                        info_state1.Text = checkin.customer.state;
                        info_dist1.Text = checkin.customer.district;
                        info_country1.Text = checkin.customer.country;
                        info_pincode1.Text = checkin.customer.pincode;
                        info_mail1.Text = checkin.customer.mail;
                        info_dob.SelectedDate = DateTime.Parse(checkin.customer.dob);
                        if (checkin.customer.marital_status == "no")
                            info_single.IsChecked = true;
                        else
                            info_married.IsChecked = true;
                        if(checkin.customer.anniversary_date!="NA")
                            info_marriage_d.SelectedDate = DateTime.Parse(checkin.customer.anniversary_date);
                        visit_count.Text = checkin.customer.visit_count;
                        bool itemExists = false;
                        foreach (string cbi in info_idproof.Items)
                        {
                            itemExists = cbi.Equals(checkin.customer.idproof);
                            if (itemExists)
                            {
                                info_idproof.SelectedItem = checkin.customer.idproof;
                                info_other_id1.Text = "OTHERS";
                                break;
                            }
                            else
                            {
                                info_other_id1.Text = checkin.customer.idproof;
                            }
                        }
                        
                        info_id_num1.Text = checkin.customer.id_proof_number;
                        if (checkin.customer.foreigner == "yes")
                            info_foreign.IsChecked = true;
                        cutomer_grid.IsEnabled = false;
                        book_avail avail = new book_avail();
                        avail = dbhandler.book_retrieve(cc1.Text,info_ph1.Text); 
                        if (avail.available == "true")
                        {
                            string[] roomtypet = avail.room_type.Split(',');
                            string[] bokkedtt = avail.book_time.Split(',');
                            string[] checkoutd = avail.checkout_date.Split(',');
                            string[] checkoutt = avail.checkout_time.Split(',');
                            string[] countt = avail.count.Split(',');
                            string[] advancet = avail.advance_paid.Split(',');
                            string[] ramountt = avail.amount.Split(',');
                            for(int i = 0; i < (roomtypet.Length - 1); i++)
                            {
                                //room_list_con.Items.Add(new roomlist() { ROOMNO = "", ROOMTYPE = roomtypet[i], COUNT = countt[i], AMOUNT = ramountt[i], CHECKIN1 = (avail.book_date + " " + bokkedtt[i] + ":00 HR"), CHECKOUT1 = (checkoutd[i] + " " + checkoutt[i] + ":00 HR"), STATUS = "booked" });
                            }
                            
                       
                            

                        }
                    }
                    else
                    {
                        info_ph1.Text = "PHONE NUMBER";
                        info_ph1.Foreground = new SolidColorBrush(Colors.Gray);
                        cutomer_grid.IsEnabled = true;
                    }

                }
                else
                {
                    MessageBox.Show("PHONE NUMBER DOESN'T EXIST");
                }
                */

            }
            else if (info_ph1.Text == "PHONE NUMBER")
            {
                phone_state.Text = "";
                info_ph1.Foreground = new SolidColorBrush(Colors.Gray);
            }
            else
            {
                phone_state.Text = "* invalid phone number";
                info_ph1.Foreground = new SolidColorBrush(Colors.Red);
               
            }
        }

        private void info_mail1_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (valid_email(info_mail1.Text))
            {
                email_valid.Text = "";
                info_mail1.Foreground = new SolidColorBrush(Colors.Black);
            }

            else if (info_mail1.Text == "MAIL ID")
            {
                email_valid.Text = "";
                info_mail1.Foreground = new SolidColorBrush(Colors.Gray);
            }

            else
            {
                email_valid.Text = "* invalid mail id";
                info_mail1.Foreground = new SolidColorBrush(Colors.Red);
            }
        }
        bool valid_email(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void info_foreign_Click(object sender, RoutedEventArgs e)
        {
            if (info_foreign.IsChecked == true)
            {
                cform_grid.IsEnabled = true;

            }
            else
            {
                cform_grid.IsEnabled = false;
            }
        }

        private void hotel_name_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            room_type.Items.Clear();
            room_no.Items.Clear();
            count.Text = "COUNT";
            XmlDocument doc = new XmlDocument();
            doc.Load("hotel_tariff.xml");
            XmlNode node = doc.DocumentElement;

            try
            {
                if (!hotel_name.Items.IsEmpty)
                {
                    foreach (XmlNode pnode in node)
                    {
                        if (pnode.Attributes[0].InnerText == hotel_name.SelectedItem.ToString())
                        {

                            XmlNodeList child = pnode.ChildNodes;
                            foreach (XmlNode room in child)
                            {
                                if (room.Attributes[0].Name == "r_name")
                                {
                                    room_type.Items.Add(room.Attributes[0].InnerText);
                                    
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception m)
            {
                MessageBox.Show(m.Message);
            }


        }
        private void checkchange(object sender, RoutedEventArgs e)
        {
            var checkbox = sender as CheckBox;
            if (checkbox.IsChecked == true)
            {
                List<checkedBoxIte> item = new List<checkedBoxIte>();
                for (int i = 0; i < 1; i++)
                {
                    checkedBoxIte ite = new checkedBoxIte();
                    ite.MyBool = true;
                    ite.rtypes = "Romantic Duo Dwell";
                    ite.rnos = "RD01";
                    ite.count = "1";
                    item.Add(ite);
                }
                //room_grid.ItemsSource = item;
            }
        }
        private void RtypeChanged(object sender, SelectionChangedEventArgs e)
        {
            int val = 0;
            dbhandler.roomxml();
            var comboBox = sender as ComboBox;
            /*var selectedItem = this.room_grid.CurrentItem;
            string s = JsonConvert.SerializeObject(selectedItem);
            var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(s);*/
            Console.WriteLine(comboBox.SelectedItem);
            string rty = comboBox.SelectedItem.ToString();
            XmlDocument doc = new XmlDocument();
                    doc.Load("room.xml");
                    XmlNode node = doc.DocumentElement;
                    foreach (XmlNode pnode in node)
                    {
                       // Console.WriteLine(String.Compare(pnode.Attributes[0].InnerText, item.Value, StringComparison.CurrentCultureIgnoreCase));

                        if (pnode.Attributes[0].InnerText== rty )
                        {

                            foreach (XmlNode type in pnode)
                            {
                                if (type.Attributes[0].InnerText == "1")
                                {
                                    if (val == 0)
                                    {
                                        val = 1;
                                        roomno1 = new ObservableCollection<string> { type.InnerText };
                                    }
                                    else
                                    {
                                        roomno1.Add(type.InnerText);
                                    }
                                }


                            }
                            //roomnocol.ItemsSource = roomno1;
                        }

                    }   
                     
        }
        
        private void checkin_time_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void count_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (count.Text == "COUNT")
            {
                count.Text = "";
                count.Foreground = new SolidColorBrush(Colors.Black);
            }
            else if (count.Text == "")
            {
                count.Text = "COUNT";
                count.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
        private void edit_list_but_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hey");
        }
        private void delete_list_but_Click(object sender, RoutedEventArgs e)
        {
            dynamic list = roomgrid.SelectedItems[0];
            if (list.but_stat=="0")
            {
                var msg = new CustomMaterialMessageBox
                {
                    TxtMessage = { Text = "are you sure ? ", Foreground = Brushes.Black },
                    TxtTitle = { Text = "DELETE ROOM", Foreground = Brushes.Black },
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

                    ramttotal -= Convert.ToInt32(list.AMOUNT);
                    info_ramount.Text = ramttotal.ToString();
                    if (ramttotal == 0)
                    {
                        info_ramount.Text = "ROOM AMOUNT";
                        info_ramount.Foreground = new SolidColorBrush(Colors.Gray);
                    }
                    string[] rv = room_no_val.Split(',');
                    room_no_val = "";
                    for (int i = 0; i < rv.Length - 1; i++)
                    {
                        if (rv[i] != list.ROOMNO)
                        {
                            room_no_val += rv[i] + ",";
                        }
                    }
                    Items.Remove(list);
                    MessageBox.Show(list.ROOMNO + " room removed ");
                    room_type.SelectedItem = null;
                    roomgrid.ItemsSource = null;
                    roomgrid.ItemsSource = Items;
                    add_room_but.Visibility = Visibility.Visible;
                    modify_book_but.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                add_room_but.Visibility = Visibility.Hidden;
                modify_book_but.Visibility = Visibility.Visible;
                room_type.SelectedItem = list.ROOMTYPE;
                count.Text = list.COUNT;
                info_ramount_inv.Text = list.AMOUNT;
                if (list.ROOMNO != "book")
                {
                    string[] rv = room_no_val.Split(',');
                    room_no_val = "";
                    for (int i = 0; i < rv.Length - 1; i++)
                    {
                        if (rv[i] != list.ROOMNO)
                        {
                            room_no_val += rv[i] + ",";
                        }
                    }
                    room_no.Text = list.ROOMNO;
                    room_type.SelectedItem = list.ROOMTYPE;
                }
            }
            
            

            
        }

        private void rtype_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!room_type.Items.IsEmpty)
            {
                if (room_type.SelectedItem == null)
                {
                    room_type.SelectedItem = room_type.Items[0];
                }
                info_advance_paid.Text = "ADVANCE PAID";
                info_advance_paid.Foreground = new SolidColorBrush(Colors.Gray);
                count.Text = "COUNT";
                count.Foreground = new SolidColorBrush(Colors.Gray);
                room_no.Items.Clear();
                XmlDocument doc = new XmlDocument();
                doc.Load("room.xml");
                XmlNode node = doc.DocumentElement;
                string[] rv = room_no_val.Split(',');
                foreach (XmlNode pnode in node)
                {

                     if (pnode.Attributes[0].InnerText == room_type.SelectedItem.ToString())
                    {

                        foreach (XmlNode type in pnode)
                        {
                            if (type.Attributes[0].InnerText == "1")
                            {
                                room_no.Items.Add(type.InnerText);
                                if(room_no_val!="")
                                {
                                    for (int i = 0; i < rv.Length - 1; i++)
                                    {
                                        room_no.Items.Remove(rv[i]);
                                    }
                                }
                                
                                
                            }


                        }
                    }

                }
            }
        }

        private void checkin_date_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (val == 1)
            {
                try
                {
                    checkin_time.Items.Clear();
                    checkout_time.Items.Clear();
                    if (checkin_date.SelectedDate == DateTime.Today)
                    {
                        for (int i = DateTime.Now.Hour; i < 24; i++)
                            checkin_time.Items.Add(i);
                        checkin_time.Text = DateTime.Now.TimeOfDay.Hours.ToString();
                        room_no.Visibility = Visibility.Visible;
                        image_Copy2.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        for (int i = 0; i < 24; i++)
                            checkin_time.Items.Add(i);
                        checkin_time.Text = "10";
                        image_Copy2.Visibility = Visibility.Hidden;
                        room_no.Visibility = Visibility.Hidden;

                    }
                    checkout_date.DisplayDateStart = DateTime.Parse(checkin_date.SelectedDate.ToString()).AddDays(1);
                    checkout_date.SelectedDate = DateTime.Parse(checkin_date.SelectedDate.ToString()).AddDays(1);
                    for (int i = 0; i < 24; i++)
                    {
                        checkout_time.Items.Add(i);
                    }
                    checkout_time.Text = "10";
                    info_ramount_inv.Text = "ROOM AMOUNT";
                    info_ramount_inv.Foreground = new SolidColorBrush(Colors.Gray);
                    count.Text = "COUNT";
                    count.Foreground = new SolidColorBrush(Colors.Gray);

                }

                catch(Exception m)
                {
                    MessageBox.Show(m.Message);
                }
            }
            
            
            

        }

        private void infoAMT_inv_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (info_ramount_inv.Text == "ROOM AMOUNT")
            {
                info_ramount_inv.Text = "";
                info_ramount_inv.Foreground = new SolidColorBrush(Colors.Black);
            }
            else if (info_ramount_inv.Text == "")
            {
                info_ramount_inv.Text = "ROOM AMOUNT";
                info_ramount_inv.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void checkout_date_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            info_ramount_inv.Text = "ROOM AMOUNT";
            info_ramount_inv.Foreground = new SolidColorBrush(Colors.Gray);
            count.Text = "COUNT";
            count.Foreground = new SolidColorBrush(Colors.Gray);
        }

        private void info_idproof_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (info_idproof.SelectedItem.ToString() == "OTHERS" && info_idproof.SelectedItem!=null)
            {
                info_other_id1.IsEnabled = true;
            }
            else
            {
                info_other_id1.IsEnabled = false;
            }
        }

        private void backbut_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/front_desk.xaml", UriKind.RelativeOrAbsolute));
        }

        

        private void modify_book_but_Click(object sender, RoutedEventArgs e)
        {
            
            
            
        }
        void modify_room()
        {
            add_room_but.Visibility = Visibility.Hidden;
            modify_book_but.Visibility = Visibility.Visible;
            dynamic select = roomgrid.SelectedItems[0];
            if (select.STATUS == "current")
            {
                room_no.Text = select.ROOMNO;
            }
            room_type.Text = select.ROOMTYPE;
            count.Text = select.COUNT;
        }

        private void checkin_but_Click(object sender, RoutedEventArgs e)
        {
            if ((info_ph1.Text == "PHONE NUMBER") || (info_name1.Text == "NAME") || (info_str1.Text == "STREET ADDRESS") || (info_dist1.Text == "DISTRICT NAME") || (info_state1.Text == "STATE NAME") || (info_country1.Text == "COUNTRY NAME") || (info_pincode1.Text == "PIN CODE") || (info_id_num1.Text == "ID NUMBER") || ((info_idproof.SelectedItem == null) && (info_other_id1.Text == "OTHERS")) || (info_dob.SelectedDate == null)||(info_segment.Text=="")||(info_mode.Text=="")||(info_tid.Text=="TRANSACTION ID")||(info_ramount.Text=="ROOM AMOUNT"))
            {
                MaterialMessageBox.ShowError(@"Empty credential");

            }
            else
            {
                if (phone_state.Text == "*new customer")
                {
                    basic_info basic = new basic_info();
                    basic.cc = cc1.Text;
                    basic.phonenumber = info_ph1.Text;
                    basic.name = info_name1.Text;
                    basic.address = info_str1.Text;
                    basic.district = info_dist1.Text;
                    basic.state = info_state1.Text;
                    basic.country = info_country1.Text;
                    basic.pincode = info_pincode1.Text;
                    basic.mail = info_mail1.Text;
                    basic.dob = info_dob.Text;
                    if (info_single.IsChecked == true)
                    {
                        basic.marital_status = "no";
                        basic.anniversary_date = "no";
                    }
                        
                    else
                    {
                        basic.marital_status = "yes";
                        basic.anniversary_date = info_marriage_d.Text;
                    }
                       
                    basic.visit_count = "1";
                    if (info_foreign.IsChecked == true)
                    {
                        basic.foreigner = "yes";
                        basic.cform_fill = "later";
                        basic.foreigner_details = "no";
                        if (cform_box.IsChecked == true)
                        {
                             basic.cform_fill = "yes";
                            string employment = "no";
                            if (emp_yes.IsChecked == true)
                                employment = "yes";
                             basic.foreigner_details ="Passport no:" +info_passport1.Text+ ",Passport date issue:" + passport_date_issue.Text + ",Passport place issue:" + info_place_pass1.Text + ",Date of arrival:" + date_arrived.Text + ",Employed in India: " + employment + ",VISA Place of issue" + info_place_visa1.Text + ",VISA date of issue:" + visa_date_issue.Text+ ",Arrived from:" + info_arrived1.Text + ",duration of stay:" + info_duration1.Text;
                        }

                    }
                    else
                    {
                        basic.foreigner = "no";
                        basic.foreigner_details = "no";
                        basic.cform_fill = "no";
                    }
                    if (info_idproof.Text == "OTHERS")
                    {
                        basic.idproof = info_other_id1.Text;
                    }
                    else
                    {
                        basic.idproof = info_idproof.Text;
                    }
                    basic.id_proof_number = info_id_num1.Text;
                    bool success = dbhandler.BasicInfoEntry(basic);
                    if (success)
                    {
                        MessageBox.Show("CUSTOMER ADDED");
                        dbhandler.sms_sender("Welcome to DREAM STAR PARADISE\nYOUR REGISTRATION IS SUCCESSFUL",basic.cc+basic.phonenumber);
                        add_db_room();
                        
                    }
                }
                else if(phone_state.Text=="*existing customer")
                {
                    add_db_room();
                }
            }
            
        }
        void add_db_room()
        {
            StringBuilder room1 = new StringBuilder();
            if (Items.Count > 0)
            {
                check_in_struct checkin = new check_in_struct();
                room_update room = new room_update();
                checkin.phonenumber = cc1.Text + info_ph1.Text;
                int count = roomgrid.Items.Count;
                if (count == 1)
                {
                    checkin.room_group = "0";
                }
                else
                {
                    checkin.room_group = "1";
                }
                dynamic list = roomgrid.Items;
                for (int i = 0; i < count; i++)
                {
                    dynamic list2 = list[i];
                    room.phonenumber = info_ph1.Text;
                    checkin.hotel_name = hotel_name.Text;
                    checkin.room_no = list2.ROOMNO;
                    room.room_no = list2.ROOMNO;
                    checkin.room_type = list2.ROOMTYPE;
                    room.room_type = list2.ROOMTYPE;
                    checkin.room_amt = list2.AMOUNT;
                    checkin.no_of_persons = list2.COUNT;

                    string[] chin = list2.CHECKIN1.Split(' ');
                    checkin.checkin_date = chin[0];
                    checkin.checkin_time = chin[1];
                    room.checkin_date = chin[0];
                    room.checkin_time = chin[1];
                    string[] chout = list2.CHECKOUT1.Split(' ');
                    checkin.checkout_date = chout[0];
                    checkin.checkout_time = chout[1];
                    room.checkout_date = chout[0];
                    room.checkout_time = chout[1];
                    room.status = "0";
                    room.s_name = dbhandler.name;
                    room.remark = "CHECKIN";
                    checkin.advance_used = "false";
                    checkin.advance_paid = info_advance_paid.Text;
                    checkin.discount = info_discount.Text;
                    checkin.total_amt = info_ramount.Text;
                    checkin.referral = info_segment.Text;
                    checkin.transaction = info_tid.Text;

                    checkin.kot_amount = "0";
                    checkin.kot_paid = "false";
                    checkin.nc_kot_count = "0";
                    checkin.plan = info_plan.Text;
                    checkin.post_charges = "0";
                    checkin.post_paid = "false";
                    checkin.Invoice_number = "0";
                    checkin.room_paid = "false";
                    checkin.check_out = "0";
                    bool suc = dbhandler.Checkin(checkin);
                    bool suc1 = dbhandler.room_status_update(room);
                    if (suc)
                    {
                        MessageBox.Show(list2.ROOMNO + " checked in");
                        room1.Append(list2.ROOMNO+",");
                    }
                    
                }
                if (room1.Length != 0)
                    dbhandler.sms_sender("DREAM STAR PARADISE\nROOMS CHECKED IN:" + room1, checkin.phonenumber);


            }
        }
        private void info_advance_paid_TextChanged(object sender, TextChangedEventArgs e)
        {
            double parsedvalue;
            if (info_advance_paid.Text != "ADVANCE PAID")
            {
                if ((double.TryParse(info_advance_paid.Text, out parsedvalue)) && (info_ramount.Text != "ROOM AMOUNT"))
                {
                    if (info_ramount.Text == "")
                    {
                        info_ramount.Text = ramttotal.ToString();
                    }
                    if (Convert.ToDouble(ramttotal) > 0)
                    {
                        Double discount=0.0;
                        if (info_discount.Text != "DISCOUNT")
                        {
                            discount = Convert.ToDouble(ramttotal) * (Convert.ToDouble(info_discount.Text) / 100.0);
                        }
                        double val = Convert.ToDouble(ramttotal) - Convert.ToDouble(info_advance_paid.Text)-discount;
                        info_ramount.Text = val.ToString();
                    }
                }
            }
            else
            {
                if (ramttotal != 0)
                {
                    info_ramount.Text = ramttotal.ToString();
                }
                
            }
        }

        private void info_discount_TextChanged(object sender, TextChangedEventArgs e)
        {
            double parsedvalue;
            if (info_discount.Text != "DISCOUNT")
            {
                if ((double.TryParse(info_discount.Text, out parsedvalue)) && (info_ramount.Text != "ROOM AMOUNT" ))
                {
                    if (info_ramount.Text == "")
                    {
                        info_ramount.Text = ramttotal.ToString();
                    }
                    if (Convert.ToDouble(ramttotal) > 0)
                    {
                        int advance = 0;
                        if(info_advance_paid.Text!="ADVANCE PAID")
                        {
                            advance = Convert.ToInt32(info_advance_paid.Text);
                        }
                        double val = Convert.ToDouble(ramttotal-advance) * (Convert.ToDouble(info_discount.Text) / 100.0);
                        info_ramount.Text = (Convert.ToDouble(ramttotal-advance) - val).ToString();
                    }
                }
            }
        }

        private void info_ph1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(info_ph1.Text!="PHONE NUMBER" && info_ph1.Text!="" && Regex.Match(info_ph1.Text, @"^([0-9]{10})$").Success)
            {
                phone_state.Text = "";
                info_ph1.Foreground = new SolidColorBrush(Colors.Black);
                check checkin = dbhandler.checkifPhonenumberavailable(cc1.Text, info_ph1.Text);
                if (checkin.available)
                {
                    var msg = new CustomMaterialMessageBox
                    {
                        TxtMessage = { Text = "Phone number already exist\nDo you want to load?", Foreground = Brushes.Black },
                        TxtTitle = { Text = "CUSTOMER DETAILS", Foreground = Brushes.Black },
                        BtnOk = { Content = "Yes" },
                        BtnCancel = { Content = "No" },
                       // MainContentControl = { Background = Brushes.MediumVioletRed },
                        TitleBackgroundPanel = { Background = Brushes.Yellow },

                        BorderBrush = Brushes.Yellow
                    };

                    msg.Show();
                    var results = msg.Result;
                    if (results==MessageBoxResult.OK)
                    {
                        phone_state.Text = "*existing customer";
                        phone_state.Foreground = new SolidColorBrush(Colors.Green);
                        info_name1.Text = checkin.customer.name;
                        info_name1.Foreground = new SolidColorBrush(Colors.Black);
                        info_str1.Text = checkin.customer.address;
                        info_str1.Foreground = new SolidColorBrush(Colors.Black);
                        info_state1.Text = checkin.customer.state;
                        info_state1.Foreground = new SolidColorBrush(Colors.Black);
                        info_dist1.Text = checkin.customer.district;
                        info_dist1.Foreground = new SolidColorBrush(Colors.Black);
                        info_country1.Text = checkin.customer.country;
                        info_country1.Foreground = new SolidColorBrush(Colors.Black);
                        info_pincode1.Text = checkin.customer.pincode;
                        info_pincode1.Foreground = new SolidColorBrush(Colors.Black);
                        info_mail1.Text = checkin.customer.mail;
                        info_mail1.Foreground = new SolidColorBrush(Colors.Black);
                        info_dob.SelectedDate = DateTime.Parse(checkin.customer.dob);
                        if (checkin.customer.marital_status == "no")
                            info_single.IsChecked = true;
                        else
                            info_married.IsChecked = true;
                        if (checkin.customer.anniversary_date != "no")
                            info_marriage_d.SelectedDate = DateTime.Parse(checkin.customer.anniversary_date);
                        visit_count.Text = checkin.customer.visit_count;
                        visit_count.Foreground = new SolidColorBrush(Colors.Black);
                        bool itemExists = false;
                        foreach (string cbi in info_idproof.Items)
                        {
                            itemExists = cbi.Equals(checkin.customer.idproof);
                            if (itemExists)
                            {
                                info_idproof.SelectedItem = checkin.customer.idproof;
                                info_other_id1.Text = "OTHERS";
                                break;
                            }
                            else
                            {
                                info_other_id1.Text = checkin.customer.idproof;
                                info_other_id1.Foreground = new SolidColorBrush(Colors.Black);
                            }
                        }

                        info_id_num1.Text = checkin.customer.id_proof_number;
                        info_id_num1.Foreground = new SolidColorBrush(Colors.Black);
                        if (checkin.customer.foreigner == "yes")
                            info_foreign.IsChecked = true;
                        cutomer_grid.IsEnabled = false;
                        book_avail avail = new book_avail();
                        avail = dbhandler.book_retrieve(cc1.Text, info_ph1.Text);
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
                                _items.Add(new Item { ROOMNO = "book", ROOMTYPE = roomtypet[i], COUNT = countt[i], AMOUNT = ramountt[i], CHECKIN1 = (avail.book_date + " " + bokkedtt[i] + ":00 HR"), CHECKOUT1 = (checkoutd[i] + " " + checkoutt[i] + ":00 HR"), STATUS = "booked", butname="EDIT",but_color= "Blue",but_stat="1" });
                               
                                ramttotal += Convert.ToInt32(ramountt[i]);
                                info_ramount.Text = ramttotal.ToString();
                                info_ramount.Foreground = new SolidColorBrush(Colors.Black);
                                //room_list_con.Items.Add(new roomlist() { ROOMNO = "", ROOMTYPE = roomtypet[i], COUNT = countt[i], AMOUNT = ramountt[i], CHECKIN1 = (avail.book_date + " " + bokkedtt[i] + ":00 HR"), CHECKOUT1 = (checkoutd[i] + " " + checkoutt[i] + ":00 HR"), STATUS = "booked" });
                            }
                            roomgrid.ItemsSource = Items;



                        }
                    }
                    else
                    {
                        Keyboard.ClearFocus();
                        info_ph1.Text = "PHONE NUMBER";
                        info_ph1.Foreground = new SolidColorBrush(Colors.Gray);
                        cutomer_grid.IsEnabled = true;
                    }

                }
                else
                {
                    phone_state.Text = "*new customer";
                    phone_state.Foreground = new SolidColorBrush(Colors.Green);
                }
            }
            else
            {
                customer_clear();
            }
        }
        void customer_clear()
        {
            cutomer_grid.IsEnabled = true;
            info_name1.Text = "NAME";
            info_name1.Foreground = new SolidColorBrush(Colors.Gray);
            info_str1.Text = "ADDRESS LINE";
            info_str1.Foreground = new SolidColorBrush(Colors.Gray);
            info_dist1.Text = "DISTRICT NAME";
            info_dist1.Foreground = new SolidColorBrush(Colors.Gray);
            info_state1.Text = "STATE NAME";
            info_state1.Foreground = new SolidColorBrush(Colors.Gray);
            info_country1.Text = "COUNTRY NAME";
            info_country1.Foreground = new SolidColorBrush(Colors.Gray);
            info_pincode1.Text = "PIN CODE";
            info_pincode1.Foreground = new SolidColorBrush(Colors.Gray);
            info_mail1.Text = "MAIL ID";
            info_mail1.Foreground = new SolidColorBrush(Colors.Gray);
            info_dob.SelectedDate = null;
            info_single.IsChecked = true;
            info_married.IsChecked = false;
            info_marriage_d.SelectedDate = null;
            visit_count.Text = "COUNT";
            visit_count.Foreground = new SolidColorBrush(Colors.Gray);
            info_idproof.SelectedItem="";
            info_other_id1.Text = "OTHERS";
            info_other_id1.Foreground = new SolidColorBrush(Colors.Gray);
            info_other_id1.IsEnabled = false;
            info_id_num1.Text = "ID NUMBER";
            info_id_num1.Foreground = new SolidColorBrush(Colors.Gray);
            info_foreign.IsChecked = false;
        }
        private void info_ph1_KeyDown(object sender, KeyEventArgs e)
        {
            if(info_ph1.Text!="PHONE NUMBER")
            {
                

            }
        }

        private void modify_clicck(object sender, RoutedEventArgs e)
        {
            add_room_but.Visibility = Visibility.Visible;
            modify_book_but.Visibility = Visibility.Hidden;
            dynamic list = roomgrid.SelectedItems[0];
            ramttotal -= Convert.ToInt32(list.AMOUNT);
            info_ramount.Text = ramttotal.ToString();
            if (ramttotal == 0)
            {
                info_ramount.Text = "ROOM AMOUNT";
                info_ramount.Foreground = new SolidColorBrush(Colors.Gray);
            }
            /*string[] rv = room_no_val.Split(',');
            room_no_val = "";
            for (int i = 0; i < rv.Length - 1; i++)
            {
                if (rv[i] != list.ROOMNO)
                {
                    room_no_val += rv[i] + ",";
                }
            }*/
            book_room = room_no.Text;
            book_count = count.Text;
            Items.Remove(list);
            roomgrid.ItemsSource = null;
            roomgrid.ItemsSource = Items;
            room_type.SelectedItem = null;
            room_add(1);
        }

        private void add_room_but_Click(object sender, RoutedEventArgs e)
        {
            room_add(0);
        }
        void room_add(int stat)
        {
            string status = "current";
            string rval = "book";
            if ((hotel_name.Text != "") && (room_type.Text != "") && (room_no.Text != "" || book_room!="") && ((count.Text != "COUNT") || book_count!="") && (info_plan.Text != ""))
            {
                roomgrid.ItemsSource = null;
                if ((checkin_date.SelectedDate > DateTime.Now.AddDays(1)) && (Convert.ToInt32(checkin_time.SelectedItem) > 10))
                {
                    status = "booking";

                }
                else
                {
                    if(room_no.Text != "")
                    {
                        rval = room_no.Text;
                        room_no_val += room_no.Text + ",";
                    }
                    else if (book_room != "")
                    {
                        rval = book_room;
                        room_no_val += book_room + ",";
                    }
                }
                if (stat == 0)
                {
                    _items.Add(new Item { ROOMNO = rval, ROOMTYPE = room_type.Text, COUNT = count.Text, AMOUNT = info_ramount_inv.Text, CHECKIN1 = (checkin_date.Text + " " + checkin_time.Text + ":00 HR"), CHECKOUT1 = (checkout_date.Text + " " + checkout_time.Text + ":00 HR"), STATUS = status, butname = "DELETE", but_color = "Red", but_stat = "0" });
                }
                else
                {
                    
                    _items.Add(new Item { ROOMNO = rval, ROOMTYPE = room_type.Text, COUNT = book_count, AMOUNT = info_ramount_inv.Text, CHECKIN1 = (checkin_date.Text + " " + checkin_time.Text + ":00 HR"), CHECKOUT1 = (checkout_date.Text + " " + checkout_time.Text + ":00 HR"), STATUS = "booked", butname = "EDIT", but_color = "Blue", but_stat = "1" });
                }
                ramttotal += Convert.ToInt32(info_ramount_inv.Text);
                info_ramount.Text = ramttotal.ToString();
                info_ramount.Foreground = new SolidColorBrush(Colors.Black);
            }
            roomgrid.ItemsSource = Items;
            room_type.SelectedItem = null;
            count.Text = "COUNT";
            count.Foreground = new SolidColorBrush(Colors.Gray);
            info_ramount_inv.Text = "ROOM AMOUNT";
            info_ramount_inv.Foreground = new SolidColorBrush(Colors.Gray);
        }
        public class roomlist
        {
            public string ROOMTYPE { get; set; }
            public string ROOMNO { get; set; }
            public string CHECKIN1 { get; set; }
            public string CHECKOUT1 { get; set; }
            public string COUNT { get; set; }
            public string AMOUNT { get; set; }
            public string STATUS { get; set; }

        }

        private void count_TextChanged(object sender, TextChangedEventArgs e)
        {
            int parsedvalue;
            if ((int.TryParse(count.Text, out parsedvalue)) && (!room_type.Items.IsEmpty))
            {

                String date_dif;
                if (checkin_date.SelectedDate == null && checkin_time.SelectedItem == null)
                {
                    date_dif = "1";
                }
                else
                {
                    DateTime in_date = checkin_date.SelectedDate.Value;
                    DateTime out_date = checkout_date.SelectedDate.Value;
                    date_dif = (out_date - in_date).TotalDays.ToString();
                }
                XmlDocument doc = new XmlDocument();
                doc.Load("hotel_tariff.xml");

                XmlNode node = doc.DocumentElement;
                foreach (XmlNode pnode in node)
                {
                    if (pnode.Attributes[0].InnerText == hotel_name.SelectedItem.ToString())
                    {
                        XmlNodeList child = pnode.ChildNodes;
                        foreach (XmlNode room in child)
                        {

                            if (room.Attributes[0].InnerText == room_type.SelectedItem.ToString())
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

                if (Convert.ToInt32(count.Text) > (Convert.ToInt32(room_pcount) + Convert.ToInt32(room_pxtra)) || Convert.ToInt32(count.Text) < 1)
                {

                    MessageBox.Show("COUNT INVALID");
                    info_ramount_inv.Text = "ROOM AMOUNT";
                    
                    Keyboard.ClearFocus();
                    count.Text = "COUNT";
                    count.Foreground = new SolidColorBrush(Colors.Gray);
                }
                else if(Convert.ToInt32(count.Text) <= (Convert.ToInt32(room_pcount))){
                    info_ramount_inv.Text = (Convert.ToDouble(room_amt)*Convert.ToDouble(date_dif)).ToString();
                }
                else if (Convert.ToInt32(count.Text) == (Convert.ToInt32(room_pcount) + Convert.ToInt32(room_pxtra)))
                {

                    info_ramount_inv.Text = ((Convert.ToInt32(room_amt) + Convert.ToInt32(room_xtra))*Convert.ToInt32(date_dif)).ToString();
                    r_total = Convert.ToInt32(info_ramount_inv.Text);
                }
                else
                {
                    if (room_type.SelectedItem.ToString() == "Dormitory Territory")
                    {
                        UInt64 parsei;
                        if (UInt64.TryParse(count.Text, out parsei))
                        {
                            info_ramount_inv.Text = (((Convert.ToInt32(count.Text)) * int.Parse(room_amt))*Convert.ToInt32(date_dif)).ToString();
                            r_total = Convert.ToInt32(info_ramount_inv.Text);
                        }
                    }

                }

            }

    }
    }
    }

