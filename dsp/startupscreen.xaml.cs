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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace dsp
{
    /// <summary>
    /// Interaction logic for startupscreen.xaml
    /// </summary>
    
    public partial class startupscreen : Window
    {
        DispatcherTimer dt = new DispatcherTimer();
        public startupscreen()
        {
            InitializeComponent();
            new dbhandler();
            dt.Tick += new EventHandler(dt_Tick);
            dt.Interval = new TimeSpan(0, 0, 3);
            dt.Start();
        }
        private void dt_Tick(object sender, EventArgs e)
        {

            login l1 = new login();
            l1.Show();
            dt.Stop();
            this.Close();
        }
    }
}
