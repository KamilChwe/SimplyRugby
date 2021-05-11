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
                    txtLastChanged.Text = "Last Changed: " + player.lastChanged.ToString();

                    txtStandard.Text = player.standard.ToString();
                    txtSpin.Text = player.spin.ToString();
                    txtPop.Text = player.pop.ToString();

                    txtFront.Text = player.front.ToString();
                    txtRear.Text = player.rear.ToString();
                    txtSide.Text = player.side.ToString();
                    txtScrabble.Text = player.scrabble.ToString();

                    txtDrop.Text = player.drop.ToString();
                    txtPunt.Text = player.punt.ToString();
                    txtGrubber.Text = player.grubber.ToString();
                    txtGoal.Text = player.goal.ToString();

                    txtPassComment.Text = player.passingComments.ToString();
                    txtTackComment.Text = player.tacklingComments.ToString();
                    txtKickComment.Text = player.kickingComments.ToString();
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
                    players.dob = player.dob;
                    players.phoneNo = player.phoneNo;
                    players.email = player.email;
                    players.lastChanged = DateTime.UtcNow;
                    players.squad = player.squad;

                    players.standard = Int32.Parse(txtStandard.Text);
                    players.spin = Int32.Parse(txtSpin.Text);
                    players.pop = Int32.Parse(txtPop.Text);

                    players.front = Int32.Parse(txtFront.Text);
                    players.rear = Int32.Parse(txtRear.Text);
                    players.side = Int32.Parse(txtSide.Text);
                    players.scrabble = Int32.Parse(txtScrabble.Text);

                    players.drop = Int32.Parse(txtDrop.Text);
                    players.punt = Int32.Parse(txtPunt.Text);
                    players.grubber = Int32.Parse(txtGrubber.Text);
                    players.goal = Int32.Parse(txtGoal.Text);

                    players.passingComments = txtPassComment.Text;
                    players.tacklingComments = txtTackComment.Text;
                    players.kickingComments = txtKickComment.Text;
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
