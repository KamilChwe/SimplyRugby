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

            // Display all the Filters in the combobox
            boxFilter.Items.Clear();
            boxFilter.Items.Add("Show All");
            boxFilter.Items.Add("Under 15s");
            boxFilter.Items.Add("Under 16s");
            boxFilter.Items.Add("Under 18s");
            boxFilter.Items.Add("Under 20s");
            boxFilter.Items.Add("Seniors");

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
                try
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
                catch
                {
                    return;
                }
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            Player players = new Player();

            // Check if all fields are filled, comments not included as maybe the Coach doesn't have any comments
            if (txtStandard.Text == "" || txtSpin.Text == "" || txtPop.Text == "" || 
                txtFront.Text == "" || txtRear.Text == "" || txtSide.Text == "" || txtScrabble.Text == "" ||
                txtDrop.Text == "" || txtPunt.Text == "" || txtGrubber.Text == "" || txtGoal.Text == "")
            {
                MessageBox.Show("Be sure to fill out ALL the fields\n(Not including comment fields");
                return;
            }
            else 
            { 
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
                        players.sru = player.sru;
                        players.lastChanged = DateTime.UtcNow;
                        players.squad = player.squad;

                        // Checks if all the Skill Ratings are Digits
                        try
                        {
                            players.standard = int.Parse(txtStandard.Text);
                            players.spin = int.Parse(txtSpin.Text);
                            players.pop = int.Parse(txtPop.Text);

                            players.front = int.Parse(txtFront.Text);
                            players.rear = int.Parse(txtRear.Text);
                            players.side = int.Parse(txtSide.Text);
                            players.scrabble = int.Parse(txtScrabble.Text);

                            players.drop = int.Parse(txtDrop.Text);
                            players.punt = int.Parse(txtPunt.Text);
                            players.grubber = int.Parse(txtGrubber.Text);
                            players.goal = int.Parse(txtGoal.Text);
                        }
                        catch
                        {
                            MessageBox.Show("Skills MUST be in digits only!");
                            return;
                        }

                        // Checks if the ratings are between 1 and 5
                        if(int.Parse(txtStandard.Text) < 1  || int.Parse(txtStandard.Text) > 5 || 
                           int.Parse(txtSpin.Text) < 1 || int.Parse(txtSpin.Text) > 5 ||
                           int.Parse(txtPop.Text) < 1 || int.Parse(txtPop.Text) > 5 ||

                           int.Parse(txtFront.Text) < 1 || int.Parse(txtFront.Text) > 5 ||
                           int.Parse(txtRear.Text) < 1 || int.Parse(txtRear.Text) > 5 ||
                           int.Parse(txtSide.Text) < 1 || int.Parse(txtSide.Text) > 5 ||
                           int.Parse(txtScrabble.Text) < 1 || int.Parse(txtScrabble.Text) > 5 ||


                           int.Parse(txtDrop.Text) < 1 || int.Parse(txtDrop.Text) > 5 ||
                           int.Parse(txtPunt.Text) < 1 || int.Parse(txtPunt.Text) > 5 ||
                           int.Parse(txtGrubber.Text) < 1 || int.Parse(txtGrubber.Text) > 5 ||
                           int.Parse(txtGoal.Text) < 1 || int.Parse(txtGoal.Text) > 5)
                        {
                            MessageBox.Show("Skill Ratings can only go from 1 to 5!");
                            return;
                        }

                        players.passingComments = txtPassComment.Text;
                        players.tacklingComments = txtTackComment.Text;
                        players.kickingComments = txtKickComment.Text;
                        JSON.Remove(player);

                        // This is a bit hacky but basically I removed the old player details from the JSON and am now overwriting the file with the non edited players as to not get any duplicate Players
                        File.WriteAllText("Players.json", "[]");
                        foreach (var thePlayer in JSON)
                        {
                            json.ConvertToJSON("Players.json", thePlayer, null);
                        }

                        // After rewriting the Players I add the edited player back into the JSON
                        json.ConvertToJSON("Players.json", players, null);
                        MessageBox.Show("Skills Edited!");
                        return;
                    }
                    else
                    {
                        continue;
                    }
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

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lstDisplay.Items.Clear();
            dynamic JSON = json.ConvertFromJSON("Players.json");
            // Checks which filter option was selected and then displays all Players with that tag
            switch (boxFilter.SelectedItem)
            {
                case "Under 15s":
                    foreach (var player in JSON)
                    {
                        if(player.squad == "Under 15s")
                        {
                            lstDisplay.Items.Add(player.name);
                        }
                    }
                    break;
                case "Under 16s":
                    foreach (var player in JSON)
                    {
                        if (player.squad == "Under 16s")
                        {
                            lstDisplay.Items.Add(player.name);
                        }
                    }
                    break;
                case "Under 18s":
                    foreach (var player in JSON)
                    {
                        if (player.squad == "Under 18s")
                        {
                            lstDisplay.Items.Add(player.name);
                        }
                    }
                    break;
                case "Under 20s":
                    foreach (var player in JSON)
                    {
                        if (player.squad == "Under 20s")
                        {
                            lstDisplay.Items.Add(player.name);
                        }
                    }
                    break;
                case "Seniors":
                    foreach (var player in JSON)
                    {
                        if (player.squad == "Seniors")
                        {
                            lstDisplay.Items.Add(player.name);
                        }
                    }
                    break;
                default:
                    foreach (var player in JSON)
                    {
                        lstDisplay.Items.Add(player.name);
                    }
                    break;
            }
        }
    }
}
