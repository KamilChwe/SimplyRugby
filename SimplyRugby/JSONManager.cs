using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
// Had to install System.Text.Json through NuGet as apparently .NET Framework 4.7.2 does not have this pre-installed
using System.Text.Json;

namespace SimplyRugby
{
    class JSONManager
    {
        // ANY CREATED JSON CAN BE FOUND IN "SimplyRugby\bin\Debug" UNLESS IN RELEASE VERSION

        // Gets the details of the player or coach and serializes it into a JSON string
        public void ConvertToJSON(string filePath, Player details)
        {
            // Sets up the options for the formatting of the JSON file
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            // Checks if the supplied JSONPath exists
            if (File.Exists(filePath))
            {
                // Reads the whole JSON file
                var jsonString = File.ReadAllText(filePath);
                // Deserializes the JSON and turns it into a list writing all current info into the list
                var newPlayerList = JsonSerializer.Deserialize<List<Player>>(jsonString) ?? new List<Player>();

                // Package all the Player Information into the List
                newPlayerList.Add(new Player()
                {
                    name = details.name,
                    age = details.age,
                    squad = details.squad,
                    running = details.running,
                    tackling = details.tackling,
                    passing = details.passing,
                    throwing = details.throwing,
                    comments = details.comments
                });

                // Turns the list into a JSON
                jsonString = JsonSerializer.Serialize(newPlayerList, options);
                // Overwrites the file
                File.WriteAllText(filePath, jsonString);
            }
            else
            {
                // Create a list with all the Player Details
                List<Player> playerList = new List<Player>();

                playerList.Add(new Player()
                {
                    name = details.name,
                    age = details.age,
                    squad = details.squad,
                    running = details.running,
                    tackling = details.tackling,
                    passing = details.passing,
                    throwing = details.throwing,
                    comments = details.comments
                });

                // Turns the list into a JSON
                string jsonString = JsonSerializer.Serialize(playerList, options);
                // Adds text to the file, if no File exists then creates it
                File.AppendAllText(filePath, jsonString);
            }
        }

        // Retrieves the JSON string and deserializes it into an object
        public void ConvertFromJSON()
        {

        }

    }
}
