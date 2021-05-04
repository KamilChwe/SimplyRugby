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
        // I have to retrieve both the Player and Coach details but cannot package them into a generic object so I need to request these 2 and just send null in one of them
        public void ConvertToJSON(string filePath, Player playerDetails, Coach coachDetails)
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

                if (filePath == "Players.json")
                {
                    // Deserializes the JSON and turns it into a list writing all current info into the list
                    var newList = JsonSerializer.Deserialize<List<Player>>(jsonString) ?? new List<Player>();

                    // Package all the Player Information into the List
                    newList.Add(new Player()
                    {
                        name = playerDetails.name,
                        age = playerDetails.age,
                        squad = playerDetails.squad,
                        running = playerDetails.running,
                        tackling = playerDetails.tackling,
                        passing = playerDetails.passing,
                        throwing = playerDetails.throwing,
                        comments = playerDetails.comments
                    });

                    // Turns the list into a JSON
                    jsonString = JsonSerializer.Serialize(newList, options);
                }
                else
                {
                    // Deserializes the JSON and turns it into a list writing all current info into the list
                    var newList = JsonSerializer.Deserialize <List<Coach>>(jsonString) ?? new List<Coach>();

                    // Package all the Coach Information into the List
                    newList.Add(new Coach()
                    {
                        name = coachDetails.name,
                        email = coachDetails.email
                    });

                    // Turns the list into a JSON
                    jsonString = JsonSerializer.Serialize(newList, options);
                }

                // Overwrites the file
                File.WriteAllText(filePath, jsonString);
            }
            else
            {
                if (filePath == "Players.json")
                {
                    // Create a list with all the Player Details
                    List<Player> List = new List<Player>();

                    List.Add(new Player()
                    {
                        name = playerDetails.name,
                        age = playerDetails.age,
                        squad = playerDetails.squad,
                        running = playerDetails.running,
                        tackling = playerDetails.tackling,
                        passing = playerDetails.passing,
                        throwing = playerDetails.throwing,
                        comments = playerDetails.comments
                    });

                    // Turns the list into a JSON
                    string jsonString = JsonSerializer.Serialize(List, options);

                    // Adds text to the file, if no File exists then creates it
                    File.AppendAllText(filePath, jsonString);
                }
                else
                {
                    // Create a list with all the Player Details
                    List<Coach> List = new List<Coach>();

                    List.Add(new Coach()
                    {
                        name = coachDetails.name,
                        email = coachDetails.email
                    });

                    // Turns the list into a JSON
                    string jsonString = JsonSerializer.Serialize(List, options);

                    // Adds text to the file, if no File exists then creates it
                    File.AppendAllText(filePath, jsonString);
                }
            }
        }

        // Retrieves the JSON string and deserializes it into an object
        public dynamic ConvertFromJSON(string filePath)
        {
            var jsonString = File.ReadAllText(filePath);

            // Checks if the Player JSON got called or if the Coach JSON got called
            // Returns a Dynamic JSON Object, behaves kinda like an Array
            if (filePath == "Players.json")
            {
                // Gives back an Array
                dynamic JSON = JsonSerializer.Deserialize<List<Player>>(jsonString);
                return JSON;
            }
            else
            {
                // Gives back an Array
                dynamic JSON = JsonSerializer.Deserialize<List<Coach>>(jsonString);
                return JSON;
            }
        }

        // Recieves a JSON entry and JSON file path and deletes that Entry
        public void DeleteFromJSON(string entry, string filePath)
        {
            dynamic JSON = ConvertFromJSON(filePath);

            // Deletes a specified entry in the Players JSON
            if (filePath == "Players.json")
            {
                // Checks the provided name with all the names in the JSON
                foreach (var player in JSON)
                {
                    // Upon finding the name it deletes it and rewrites the whole JSON
                    if (player.name == entry)
                    {
                        JSON.Remove(player);

                        File.WriteAllText("Players.json", "[]");
                        foreach (var players in JSON)
                        {
                            ConvertToJSON("Players.json", players, null);
                        }
                        return;
                    }
                }
            }
            // Deletes a specified entry in the Coaches JSON
            else
            {
                // Checks the provided name with all the names in the JSON
                foreach (var coach in JSON)
                {
                    // Upon finding the name it deletes it and rewrites the whole JSON
                    if (coach.name == entry)
                    {
                        JSON.Remove(coach);

                        File.WriteAllText("Coaches.json", "[]");
                        foreach (var coaches in JSON)
                        {
                            ConvertToJSON("Coaches.json", null, coaches);
                        }
                        return;
                    }
                }
            }
        }
    }
}
