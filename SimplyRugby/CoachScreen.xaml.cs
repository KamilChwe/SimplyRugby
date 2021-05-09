using System;
using System.Windows;
using System.Windows.Controls;
using System.IO;

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

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            Player players = new Player();

            // Retrieves the JSON array
            dynamic JSON = json.ConvertFromJSON("Players.json");
            foreach (var player in JSON)
            {
                lstDisplay.SelectedItem.ToString();
                if (player.name == lstDisplay.SelectedItem.ToString())
                {
                    // I save the edited information of the player before deleting them
                    // I have to delete the player from the JSON otherwise they will be duplicated
                    players.name = player.name;
                    players.age = player.age;
                    players.squad = player.squad;
                    players.running = Int32.Parse(txtRunning.Text);
                    players.tackling = Int32.Parse(txtTackling.Text);
                    players.throwing = Int32.Parse(txtThrowing.Text);
                    players.passing = Int32.Parse(txtPassing.Text);
                    players.comments = txtComment.Text;
                    JSON.Remove(player);

                    // This is a bit hacky but basically I removed the old player details from the JSON and am now overwriting the file with the non edited players as to not get any duplicate Players
                    File.WriteAllText("Players.json", "[]");
                    foreach(var thePlayer in JSON)
                    {
                        json.ConvertToJSON("Players.json", thePlayer, null);
                    }

                    // After rewriting the Players I add the edited player back into the JSON
                    json.ConvertToJSON("Players.json", players, null);
                    return;
                }
                else
                {
                    continue;
                }

            }
        }

        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            string filePath = Path.Combine(Environment.CurrentDirectory,
                    @"..\..\Documentation\coach.html");
            System.Diagnostics.Process.Start(filePath);
            MessageBox.Show("A web window should've opened!");
        }
    }
}
