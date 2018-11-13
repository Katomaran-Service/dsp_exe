using BespokeFusion;
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
using System.Xml;
using static dsp.structdata;

namespace dsp
{
    /// <summary>
    /// Interaction logic for room_block_pg.xaml
    /// </summary>
    public partial class room_block_pg : Page
    {
        public int val = 0;
        public room_block_pg()
        {
            InitializeComponent();
            clear();
        }

        private void backbut_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/hk.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rtype_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!rtype.Items.IsEmpty)
            {
                if (rtype.SelectedItem == null)
                {
                    rtype.SelectedItem = rtype.Items[0];
                }
                room_no.Items.Clear();
                dbhandler.roomxml();
                XmlDocument doc = new XmlDocument();
                doc.Load("room.xml");
                XmlNode node = doc.DocumentElement;
                foreach (XmlNode pnode in node)
                {

                    if (pnode.Attributes[0].InnerText == rtype.SelectedItem.ToString())
                    {

                        foreach (XmlNode type in pnode)
                        {
                            if (type.Attributes[0].InnerText == "1")
                            {
                                room_no.Items.Add(type.InnerText);

                            }


                        }
                    }

                }
            }
        }

        private void block_but_Click(object sender, RoutedEventArgs e)
        {
            if(room_no.Text!="" && blockdate.SelectedDate!=null && block_time.Text!="" && releasedate.SelectedDate!=null && release_time.Text != "")
            {
                if (block_remark.Text == null)
                {
                    block_remark.Text = "nil";
                }
                   
                room_update block = new room_update();
                    block.room_no = room_no.Text;
                    block.room_type = rtype.Text;
                    block.status = "3";
                    block.s_name = dbhandler.name;
                    block.checkin_date = blockdate.Text;
                    block.checkin_time = block_time.Text;
                    block.checkout_date = releasedate.Text;
                    block.checkout_time = release_time.Text;
                    block.remark = block_remark.Text;
                    block.phonenumber = "0";
                    bool success = dbhandler.room_status_update(block);
                    
                    switch (success)
                    {
                        case true:
                        dbhandler.msgbox("ROOM:\n" + room_no.Text + "\nMOVED TO BLOCK STATE", "ROOM BLOCK","Ok","",false);
                        clear();
                        break;
                        case false:
                        MaterialMessageBox.ShowError("ROOM NOT BLOCKED\n" + room_no.Text);
                        clear();
                        break;
                    }
                
            }
            else
            {
                MaterialMessageBox.ShowError("EMPTY CREDENTIALS");
            }
        }

        private void blockdate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (val == 1)
            {
                try
                {
                    block_time.Items.Clear();
                    release_time.Items.Clear();
                    if (blockdate.SelectedDate == DateTime.Today)
                    {
                        for (int i = DateTime.Now.Hour; i < 24; i++)
                            block_time.Items.Add(i);
                        block_time.Text = DateTime.Now.TimeOfDay.Hours.ToString();
                    }
                    else
                    {
                        for (int i = 0; i < 24; i++)
                            block_time.Items.Add(i);
                        block_time.Text = "10";

                    }
                    releasedate.DisplayDateStart = DateTime.Parse(blockdate.SelectedDate.ToString()).AddDays(1);
                    releasedate.SelectedDate = DateTime.Parse(blockdate.SelectedDate.ToString()).AddDays(1);
                    for (int i = 0; i < 24; i++)
                    {
                        release_time.Items.Add(i);
                    }
                    release_time.Text = "10";

                }

                catch (Exception m)
                {
                    MessageBox.Show(m.Message);
                }
            }
        }
        public void clear()
        {
            val = 1;
            block_time.Items.Clear();
            release_time.Items.Clear();
            room_no.Items.Clear();
            rtype.Items.Clear();
            
            block_time.Items.Add("0");
            release_time.Items.Add("0");
            for (int i = DateTime.Now.Hour; i < 24; i++)
                block_time.Items.Add(i);
            for (int i = 0; i < 24; i++)
            {
                release_time.Items.Add(i);
            }
            blockdate.SelectedDate = DateTime.Today;
            releasedate.DisplayDateStart = DateTime.Today.AddDays(1);
            releasedate.SelectedDate = DateTime.Today.AddDays(1);
            release_time.Text = "10";
            block_time.Text = DateTime.Now.TimeOfDay.Hours.ToString();
            XmlDocument doc = new XmlDocument();
            doc.Load("hotel_tariff.xml");
            XmlNode node = doc.DocumentElement;

            try
            {
                foreach (XmlNode pnode in node)
                {
                    if (pnode.Attributes[0].InnerText == "LE CASTLE")
                    {

                        XmlNodeList child = pnode.ChildNodes;
                        foreach (XmlNode room in child)
                        {
                            if (room.Attributes[0].Name == "r_name")
                            {
                                rtype.Items.Add(room.Attributes[0].InnerText);

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
    }
}
