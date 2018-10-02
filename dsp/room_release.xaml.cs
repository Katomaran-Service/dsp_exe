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
    /// Interaction logic for room_release.xaml
    /// </summary>
    public partial class room_release : Page
    {
        public room_release()
        {
            InitializeComponent();
            for (int i = DateTime.Now.Hour; i < 24; i++)
                release_time.Items.Add(i);
            release_time.Text = DateTime.Now.TimeOfDay.Hours.ToString();
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

        private void release_but_Click(object sender, RoutedEventArgs e)
        {
            if (room_no.Text != "")
            {
                if (release_remark.Text == null)
                    release_remark.Text = "RELEASE";
                room_update block = new room_update();
                block.room_no = room_no.Text;
                block.room_type = rtype.Text;
                block.status = "1";
                block.s_name = dbhandler.name;
                block.checkin_date = "0";
                block.checkin_time = "0";
                block.checkout_date = releasedate.Text;
                block.checkout_time = release_time.Text;
                block.remark = release_remark.Text;
                block.phonenumber = "0";
                bool success = dbhandler.room_status_update(block);

                switch (success)
                {
                    case true:
                        dbhandler.msgbox("ROOM:\n" + room_no.Text + "\nRELEASED AND MOVED TO VACANT STATE", "ROOM RELEASED", "Ok", "", false);
                        break;
                    case false:
                        MaterialMessageBox.ShowError("ROOM:\n" + room_no.Text + "\nNOT RELEASED");
                        break;
                }
            }
            else
            {
                MaterialMessageBox.ShowError("EMPTY CREDENTIALS");
            }
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
                            if (type.Attributes[0].InnerText == "3")
                            {
                                room_no.Items.Add(type.InnerText);

                            }


                        }
                    }

                }
            }
        }

        private void backbut_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/hk.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
