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
    /// Interaction logic for AdminScreen.xaml
    /// </summary>
    public partial class AdminScreen : Window
    {
        Player players = new Player();
        JSONManager json = new JSONManager();

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
            string squad;
            int age = Int32.Parse(txtPlayerAge.Text);
            Player player = new Player();

            #region Squad Age Check
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

        private void btnAddCoach_Click(object sender, RoutedEventArgs e)
        {
            Coach coach = new Coach();

            // Package the Coach Details into an Object
            coach.name = txtCoachName.Text;
            coach.email = txtCoachEmail.Text;

            json.ConvertToJSON("Coaches.json", null, coach);

            // I make a formatted string with all of the information pulled from the Coach Class and display it to the user
            string formattedString = string.Format("Successfully added a Coach!\n\nCoach Details:\nName: {0}\nE-Mail: {1}", coach.name, coach.email);
            MessageBox.Show(formattedString);
        }
    }
}
