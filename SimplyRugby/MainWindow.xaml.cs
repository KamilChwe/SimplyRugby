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

namespace SimplyRugby
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text, password = txtPassword.Password;

            if(username == "Admin" && password == "securepassword123")
            {
                AdminScreen adminScreen = new AdminScreen();
                adminScreen.Show();
                this.Close();
            }
            else if (username == "Coach" && password == "coachpassword123")
            {
                CoachScreen coachScreen = new CoachScreen();
                coachScreen.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("You have entered an incorrect Username and/or Password!");
            }
        }
    }
}
