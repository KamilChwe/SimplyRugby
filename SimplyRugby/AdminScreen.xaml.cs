using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;

namespace SimplyRugby
{
    /// <summary>
    /// Interaction logic for AdminScreen.xaml
    /// </summary>
    public partial class AdminScreen : Window
    {
        JSONManager json = new JSONManager();

        // Later in the code I need to delete entries so I'm using the same technique as in CoachScreen code where I delete the entry and save all the others and rewrite the file
        // I use this bool to check if the Coach or Player object should be used
        bool playersDisplayed = false;

        public AdminScreen()
        {
            InitializeComponent();
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

        //Adding Player Details to a JSON File
        private void btnAddPlayer_Click(object sender, RoutedEventArgs e)
        {
            int age = 0;

            // Checks if any fields are empty
            if (txtPlayerName.Text == null || txtPlayerAge.Text == null)
            {
                MessageBox.Show("Please make sure ALL of the Player fields are filled in!");
            }
            else
            {
                // Checks if the age field has an INT, if no then throw an error
                try
                {
                    age = Int32.Parse(txtPlayerAge.Text);
                }
                catch
                {
                    MessageBox.Show("The age field only accepts numbers!");
                    return;
                }

                Player player = new Player();

                #region Squad Age Check
                string squad;
                // Automatically checks which Squad the Player should be in depending on their age
                if (age <= 14)
                {
                    squad = "Under 15s";
                }
                else if (age == 15)
                {
                    squad = "Under 16s";
                }
                else if (age == 16 || age == 17)
                {
                    squad = "Under 18s";
                }
                else if (age == 18 || age == 19)
                {
                    squad = "Under 20s";
                }
                else
                {
                    squad = "Seniors";
                }
                #endregion

                #region Creating a Player Object
                // Package the Player Details into an Object
                player.name = txtPlayerName.Text;
                player.age = age;
                player.squad = squad;
                // The 0s are because Admins are not allowed to change or add Skill data, the coach can change these values
                player.running = 0;
                player.tackling = 0;
                player.passing = 0;
                player.throwing = 0;
                player.comments = "";
                #endregion

                json.ConvertToJSON("Players.json", player, null);

                // I make a formatted string with all of the information pulled from the Player Class and display it to the user
                string formattedString = string.Format("Successfully added a Player!\n\nPlayer Details:\nName: {0}\nAge: {1}\nSquad: {2}", player.name, player.age, player.squad);
                MessageBox.Show(formattedString);
            }
        }

        private void btnAddCoach_Click(object sender, RoutedEventArgs e)
        {
            // Checks if any fields are empty
            if(txtCoachName.Text == null || txtCoachEmail.Text == null)
            {
                MessageBox.Show("Make sure ALL of the Coach fields are filled in!");
            }
            else
            {
                Coach coach = new Coach();

                // Package the Coach Details into an Object
                coach.name = txtCoachName.Text;

                // Checks if the entered email is correct format
                string email = txtCoachEmail.Text;
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(email);
                if (match.Success)
                {
                    coach.email = txtCoachEmail.Text;
                }
                else
                {
                    MessageBox.Show("You have entered an incorrect email address!");
                    return;
                }

                json.ConvertToJSON("Coaches.json", null, coach);

                // I make a formatted string with all of the information pulled from the Coach Class and display it to the user
                string formattedString = string.Format("Successfully added a Coach!\n\nCoach Details:\nName: {0}\nE-Mail: {1}", coach.name, coach.email);
                MessageBox.Show(formattedString);
            }
        }

        private void btnDisplayAllPlayers_Click(object sender, RoutedEventArgs e)
        {
            playersDisplayed = true;
            lstDisplay.Items.Clear();
            dynamic JSON = json.ConvertFromJSON("Players.json");

            foreach(var player in JSON)
            {
                lstDisplay.Items.Add(player.name);
            }
        }

        private void btnDisplayAllCoaches_Click(object sender, RoutedEventArgs e)
        {
            playersDisplayed = false;
            lstDisplay.Items.Clear();
            dynamic JSON = json.ConvertFromJSON("Coaches.json");

            foreach (var coach in JSON)
            {
                lstDisplay.Items.Add(coach.name);
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (playersDisplayed)
            {
                MessageBox.Show("Deleted Player: " + lstDisplay.SelectedItem.ToString());
                json.DeleteFromJSON(lstDisplay.SelectedItem.ToString(), "Players.json");

                // Resets the List 
                lstDisplay.Items.Clear();
                dynamic JSON = json.ConvertFromJSON("Players.json");

                foreach (var player in JSON)
                {
                    lstDisplay.Items.Add(player.name);
                }
            }
            else
            {
                MessageBox.Show("Deleted Coach: " + lstDisplay.SelectedItem.ToString());
                json.DeleteFromJSON(lstDisplay.SelectedItem.ToString(), "Coaches.json");

                // Resets the List
                lstDisplay.Items.Clear();
                dynamic JSON = json.ConvertFromJSON("Coaches.json");
                foreach (var coach in JSON)
                {
                    lstDisplay.Items.Add(coach.name);
                }
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if(playersDisplayed)
            {
                Player players = new Player();
                dynamic JSON = json.ConvertFromJSON("Players.json");

                foreach (var player in JSON)
                {
                    if(players.name == lstDisplay.SelectedItem.ToString())
                    {
                        // I save the edited information of the player before deleting them
                        // I have to delete the player from the JSON otherwise they will be duplicated
                        players.name = txtPlayerName.Text;
                        players.age = Int32.Parse(txtPlayerAge.Text);
                        players.squad = players.squad;
                        players.running = players.running;
                        players.tackling = players.tackling;
                        players.throwing = players.throwing;
                        players.passing = players.passing;
                        players.comments = players.comments;
                        json.DeleteFromJSON(lstDisplay.SelectedItem.ToString(), "Players.json");

                        // This is a bit hacky but basically I removed the old player details from the JSON and am now overwriting the file with the non edited players as to not get any duplicate Players
                        File.WriteAllText("Players.json", "[]");
                        foreach (var thePlayer in JSON)
                        {
                            json.ConvertToJSON("Players.json", thePlayer, null);
                        }
                    }
                }
            }
            else
            {
                Coach coach = new Coach();
                dynamic JSON = json.ConvertFromJSON("Coaches.json");
                foreach(var coaches in JSON)
                {
                    if(coaches.name == lstDisplay.SelectedItem.ToString())
                    {
                        coaches.name = txtCoachName.Text;
                        coaches.email = txtCoachEmail.Text;
                        json.DeleteFromJSON(lstDisplay.SelectedItem.ToString(), "Coaches.json");

                        // This is a bit hacky but basically I removed the old coach details from the JSON and am now overwriting the file with the non edited coaches as to not get any duplicate Coaches
                        File.WriteAllText("Coaches.json", "[]");
                        foreach (var theCoaches in JSON)
                        {
                            json.ConvertToJSON("Coaches.json", null, theCoaches);
                        }
                    }
                }
            }
        }

        private void lstDisplay_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (playersDisplayed)
            {
                dynamic JSON = json.ConvertFromJSON("Players.json");

                foreach(var player in JSON)
                {
                    if(player.name == lstDisplay.SelectedItem.ToString())
                    {
                        int age = player.age;
                        txtPlayerName.Text = player.name;
                        txtPlayerAge.Text = age.ToString();
                    }
                }
            }
            else
            {
                dynamic JSON = json.ConvertFromJSON("Coaches.json");

                foreach (var coach in JSON)
                {
                    if (coach.name == lstDisplay.SelectedItem.ToString())
                    {
                        txtCoachName.Text = coach.name;
                        txtCoachEmail.Text = coach.email;
                    }
                }
            }
        }
    }
}
