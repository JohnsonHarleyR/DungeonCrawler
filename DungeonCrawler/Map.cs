using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawler
{
    class Map
    {
        // variables
        private readonly Random random = new Random();
        private readonly int numRooms; // the number or rooms the character go through
        private readonly List<string> locations = new List<string> {"Eerie Entrance", "Creepy Cavern", 
            "Room of Urns", "Bloody Kitchen", "Prison Cells", "Piano Room", "Open Skylight",
            "Nightmare Den"};
        private readonly Queue<string> nextLocations = new Queue<string>();

        // constructor
        public Map()
        {
            string location = locations[random.Next(0, locations.Count)];
            string lastLocation;
            nextLocations.Enqueue(location);

            // randomize the number of rooms
            numRooms = random.Next(5, 11);


            // fill the queue with random locations
            for (int i = 1; i < numRooms; i++)
            {
                // make sure the next location is not the same as the last one
                do
                {
                    lastLocation = location;
                    location = locations[random.Next(0, locations.Count)];

                    if (!location.Equals(lastLocation))
                    {
                        nextLocations.Enqueue(location);
                    }


                } while (location.Equals(lastLocation));
                
            }
        }

        // Get the next location in the queue
        public string GetNextLocation()
        {
            return nextLocations.Dequeue();
        }

        // Get the queue of next locations for reference
        public Queue<string> GetLocationQueue()
        {
            return nextLocations;
        }


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
                    number = -1;
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
