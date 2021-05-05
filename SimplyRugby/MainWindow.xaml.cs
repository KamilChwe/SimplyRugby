using System;
using System.IO;
using System.Windows;

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
            // Retrives the inputted string from Text Boxes and stores them in these variables
            string username = txtUsername.Text, password = txtPassword.Password;

            // Checks the inputted username and password and compares it to the stored values, if either Admin or Coach details match then the user is taken to the respective window
            // otherwise they are told they have to re-input the login or password
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
                // Checks if the password or login is wrong
                if (username != "Admin" && username != "Coach")
                {
                    MessageBox.Show("The Username you have entered is wrong!");
                }
                else
                {
                    MessageBox.Show("The password you have entered is wrong!");
                }
            }
        }

        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            string filePath = Path.Combine(Environment.CurrentDirectory,
                                @"..\..\Documentation\documentation.html");
            System.Diagnostics.Process.Start(filePath);
            MessageBox.Show("A web window should've opened!");
        }
    }
}
