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

namespace dsp
{
    /// <summary>
    /// Interaction logic for occupancy.xaml
    /// </summary>
    public partial class occupancy : Page
    {
        public static string url = String.Empty;
        public occupancy()
        {
            InitializeComponent();

            
        }

        private void backbut_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri(url, UriKind.RelativeOrAbsolute));
        }
        public void color_load()
        {
            var datetime = DateTime.Now;
            // dbhandler.room_check(occu_date.Text, DateTime.Now.TimeOfDay.Hours.ToString());
            dbhandler.roomxml();
            XmlDocument doc = new XmlDocument();
            doc.Load("room.xml");
            XmlNode node = doc.DocumentElement;

            foreach (XmlNode pnode in node)
            {
                XmlNodeList cnode = pnode.ChildNodes;
                foreach (XmlNode c in cnode)
                {
                    String value = c.InnerText;
                    String id = c.Attributes[0].InnerText;
                    var rec = (Rectangle)this.FindName("r"+value);
                        if (id == "1")
                            rec.Fill = new SolidColorBrush(Color.FromRgb(0, 226, 102));
                        else if (id == "0")
                            rec.Fill = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                            
                        else if (id == "2")
                            rec.Fill = new SolidColorBrush(Color.FromRgb(250, 191, 143));
                        else if (id == "3")
                            rec.Fill = new SolidColorBrush(Colors.Black);
                        else if (id == "4")
                            rec.Fill = new SolidColorBrush(Color.FromRgb(0, 112, 192));

                }
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            color_load();
        }
    }
}
