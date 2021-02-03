using System;
using System.Collections.Generic;

namespace DungeonCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Dungeon Crawler");

            // variables
            Enemy enemy = new Enemy();
            Map map = new Map();
            string location;
            List<Character> adventurers = new List<Character>();
            int NUM_ADVENT = 6;


            Console.WriteLine("Dungeon Crawler");

            // Name the adventurers
           CreateAdventurers(adventurers, NUM_ADVENT, enemy.GetTypes(), map.GetLocations());

            Console.WriteLine("\n\nLet's begin!");

            
            // loop until there are no rooms left or no character left
            do
            {
                // characters enter a new room
                location = map.GetNextLocation();
                int numAdvents = CharactersLeft(adventurers);
                if (numAdvents > 1)
                {
                    Console.WriteLine($"\nThe {CharactersLeft(adventurers)} adventurers enter the {location}.\n");

                }
                else
                {
                    Console.WriteLine($"\nThe single adventurer enters the {location}.\n");

                }
                Console.WriteLine("**Stats**");
                // loop through the characters to show their hp
                foreach (Character adventurer in adventurers)
                {
                    Console.WriteLine($"{adventurer.GetName()}: {adventurer.GetHp()} HP");
                }

                // pause
                Pause();


            } while (map.GetLocationQueue().Count > 0 && CharactersLeft(adventurers) > 0);
            

        }

        // find out if any characters are still alive
        public static int CharactersLeft(List<Character> characters)
        {
            int numLeft = 0;
            for (int i = 0; i < characters.Count; i++)
            {
                if (characters[i].GetHp() > 0)
                {
                    numLeft += 1;
                }
                else // if a character is dead, remove it from the list
                {
                    characters.Remove(characters[i]);
                }
            }
            return numLeft;
        }

        // Pause
        public static void Pause()
        {
            Console.WriteLine("\n(Hit enter to continue.)");
            Console.ReadLine();
        }


        // Create the adventurers, give them enemies and locations they can't fight
        public static void CreateAdventurers(List<Character> list, int numAdventurers,
            List<string> enemies, List<string> locations)
        {
            Random random = new Random();

            // loop for the number of adventurers
            for (int i = 0; i < numAdventurers; i++)
            {
                string name;
                string badEnemy;
                string badLocation;
                Character character;

                do // keep asking until a name is entered
                {
                    // ask the name of the adventure
                    Console.Write($"\nName for adventurer #{i + 1}: ");

                    // store name of adventurer in temporary variable
                    name = Console.ReadLine();

                    name.Trim();

                    // if there's no entry, tell them invalid entry.
                    if (name.Equals(""))
                    {
                        Console.Write("Invalid Entry.");
                    }
                } while (name.Equals(""));

                // capitalize the first letter just in case - to make the  better
                if (name.Length > 1)
                {
                    name = char.ToUpper(name[0]) + name.Substring(1);
                }
                else
                {
                    name = name.ToUpper();
                }

                // decide a random enemy type and location where the adventurer can't fight
                badEnemy = enemies[random.Next(0, enemies.Count)];
                badLocation = locations[random.Next(0, locations.Count)];

                // create the new character
                character = new Character(name, badEnemy, badLocation);

                // add it to the list
                list.Add(character);

                /*
                Console.WriteLine($"Name: {character.GetName()}, Bad Enemy:" +
                    $" {character.GetBadEnemy()} Bad Location: {character.GetBadLocation()}"); // test
                */

            }
        }

    }
    

}
