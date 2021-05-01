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

namespace SimplyRugby
{
    /// <summary>
    /// Interaction logic for CoachScreen.xaml
    /// </summary>
    public partial class CoachScreen : Window
    {
        JSONManager json = new JSONManager();
        public CoachScreen()
        {
            InitializeComponent();

            // Displays all the Players in a list
            lstDisplay.Items.Clear();
            dynamic JSON = json.ConvertFromJSON("Players.json");

            // Goes through each index in the array and adds it to the list
            foreach (var player in JSON)
            {
                lstDisplay.Items.Add(player.name);
            }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            //Creates an interactive box with Yes and No
            var logoutConfirm = MessageBox.Show("Are you sure you want to logout?\nAnything unsaved will be lost!", "Logout", MessageBoxButton.YesNo);

            //Asks the user if they really want to go back to the login screen, if they haven't saved their work then it doesn't get saved
            //If the user picks no then they go back to the screen, if they pick yes then they go back to the Login Screen
            if (logoutConfirm == MessageBoxResult.Yes)
            {
                MainWindow loginScreen = new MainWindow();
                loginScreen.Show();
                this.Close();
            }
            else
            {
                return;
            }
        }

        private void lstDisplay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Retrieves the JSON array
            dynamic JSON = json.ConvertFromJSON("Players.json");
            foreach (var player in JSON)
            {
                lstDisplay.SelectedItem.ToString();
                if (player.name == lstDisplay.SelectedItem.ToString())
                {
                    MessageBox.Show("FOUND THEM!!!!");
                    txtRunning.Text = player.running.ToString();
                    txtTackling.Text = player.tackling.ToString();
                    txtThrowing.Text = player.throwing.ToString();
                    txtPassing.Text = player.passing.ToString();
                    txtComment.Text = player.comments.ToString();
                    return;
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
