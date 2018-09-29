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

namespace dsp
{
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Window
    {
        int value;
        public login()
        {
            InitializeComponent();
            value = 0;
        }

        private void main_pg_call(object sender, RoutedEventArgs e)
        {
            main_call();
        }

        public void main_call()
        {
            if (usernam.Text != "User name" && PASSWORD.Password != String.Empty)
            {
                value = dbhandler.user_db(usernam.Text, PASSWORD.Password.ToString());
                if (value == 1)
                {
                    
                    dbhandler.name = usernam.Text;
                    this.Hide();
                    MainWindow m1 = new MainWindow();
                    m1.Show();
                    this.Close();
                }
                else
                {

                    MessageBox.Show("incorrect user name and password");
                }

            }
            else
            {

                if (usernam.Text == "User name" && String.IsNullOrEmpty(PASSWORD.Password))
                {
                    MessageBox.Show("Enter user name and password");
                }
                else if (usernam.Text == "User name")
                {
                    MessageBox.Show("Enter user name");
                }
                else if (String.IsNullOrEmpty(PASSWORD.Password))
                {
                    MessageBox.Show("Enter password");
                }
            }
        }

        private void PASSWORD_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Enter)
                main_call();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
