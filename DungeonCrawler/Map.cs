using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawler
{
    class Map
    {
        // variables
        Random random = new Random();
        List<string> locations = new List<string> {"Eeerie Entrance", "Creepy Cavern", 
            "Room of Urns", "Bloody Kitchen", "Prison Cells", "Piano Room", "Open Skylight",
            "Nightmare Den"};


        // Get the number of enemies in a room
        public int GetEnemies(string location)
        {
            int number;
            switch (location)
            {
                case "Eerie Entrance":
                    number = random.Next(1, 4);
                    break;
                case "Creepy Cavern":
                    number = random.Next(2, 5);
                    break;
                case "Room of Urns":
                    number = random.Next(3, 6);
                    break;
                case "Bloody Kitchen":
                    number = random.Next(5, 9);
                    break;
                case "Prison Cells":
                    number = random.Next(3, 6);
                    break;
                case "Piano Room":
                    number = random.Next(1, 5);
                    break;
                case "Open Skylight":
                    number = random.Next(3, 8);
                    break;
                case "Nightmare Den":
                    number = random.Next(5, 11);
                    break;
                default:
                    number = 0;
                    break;
            }
            return number;
                
        }

        // Get the list of locations
        public List<string> GetLocations()
        {
            return locations;
        }

    }
}
