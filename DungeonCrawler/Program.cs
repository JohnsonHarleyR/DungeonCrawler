using System;
using System.Collections.Generic;

namespace DungeonCrawler
{
    class Program
    {
        static void Main()
        {
            //Console.WriteLine("Dungeon Crawler");

            // variables
            Enemy enemy = new Enemy();
            Map map = new Map();
            string location;
            List<Character> adventurers = new List<Character>();
            int NUM_ADVENT = 6;
            Random random = new Random();


            Console.WriteLine("Dungeon Crawler\n");

            // Name the adventurers
            CreateAdventurers(adventurers, NUM_ADVENT, enemy.GetTypes(), map.GetLocations());

            Console.WriteLine("\n\nLet's begin!");

            
            // loop until there are no rooms left or no character left
            do
            {
                // variables
                Character fighter;
                string thisEnemy = enemy.GetEnemy();

                // characters enter a new room
                location = map.GetNextLocation();
                int adventsLeft = CharactersLeft(adventurers);
                int enemiesInRoom = map.GetEnemies(location);
                if (adventsLeft > 1)
                {
                    Console.Write($"\nThe {CharactersLeft(adventurers)} adventurers enter the {location}.");

                }
                else
                {
                    Console.Write($"\nThe single adventurer enters the {location}.");

                }
                if (enemiesInRoom == 1)
                    Console.Write($"\nThere is {enemiesInRoom} enemy to fight!\n");
                else
                    Console.Write($"\nThere are {enemiesInRoom} enemies to fight!\n");
                ShowStats(adventurers);

                // pause
                Pause();


                // NOTE may not need to record lastEnemy and last location, may only need
                // to record if they took damage in tht particular room - to simplify things

                // loop until all the enemies in the room are defeated
                while (enemiesInRoom > 0)
                {

                    // Tell the next enemy
                    // change the sentence if the enemy starts with a vowel
                    if (thisEnemy.Substring(0, 1).Equals("a") ||
                        thisEnemy.Substring(0, 1).Equals("e") ||
                        thisEnemy.Substring(0, 1).Equals("i") ||
                        thisEnemy.Substring(0, 1).Equals("o") ||
                        thisEnemy.Substring(0, 1).Equals("u"))
                    {
                        Console.Write($"\nAn {thisEnemy} appears!");
                    }
                    else
                    {
                        Console.Write($"\nA {thisEnemy} appears!");

                    }

                    // now use a fighter to attack - until one of them defeats the enemy
                    do
                    {
                        bool enemyAlive = false; // for the sake of displaying the words right

                        // select random fighter
                        fighter = adventurers[random.Next(0, adventurers.Count)];

                        // make sure this fighter didn't already take damage in this location
                        if (!fighter.GetTookDamage())
                        {
                            // tell who is fighting
                            Console.Write($" {fighter.GetName()} steps up to fight!\n");

                            // Check if it's a bad enemy or bad location
                            if (fighter.GetBadEnemy().Equals(thisEnemy) ||
                            fighter.GetBadLocation().Equals(location))
                            {
                                // if so, then set the fighter's tookDamage to true
                                fighter.SetTookDamage(true);

                                // the character takes damage
                                int damage = enemy.GetDamage(thisEnemy);
                                fighter.SetHp(fighter.GetHp() - damage);

                                // Inform the player about what happened
                                if (fighter.GetBadEnemy().Equals(thisEnemy))
                                {
                                    Console.WriteLine($"{fighter.GetName()} is feeble against this enemy and takes {damage} HP damage!");
                                }
                                else if (fighter.GetBadLocation().Equals(location))
                                {
                                    Console.WriteLine($"{fighter.GetName()} struggles to fight in the {location}, thus taking {damage} HP damage!");

                                }

                                // Console.WriteLine($"They take {damage} HP damage.");

                                // if the hp is less than 0, set it to 0
                                if (fighter.GetHp() <= 0)
                                {
                                    fighter.SetHp(0); // set it to 0 just in case it's needed in the future
                                    Console.WriteLine($"\n{fighter.GetName()} has died! That is unfortunate.");
                                }

                                // let the player know the enemy is still alive
                                Pause();
                                ShowStats(adventurers);
                                Console.Write($"\nThe {thisEnemy} is still alive!");
                                enemyAlive = true;

                            }
                            else // otherwise, the character defeats the enemy
                            {
                                Console.WriteLine($"{fighter.GetName()} comes out strong to defeat the enemy!");
                                // Decrease the enemies in the room
                                enemiesInRoom -= 1;
                                // Display enemies left if the room
                                if (enemiesInRoom == 1)
                                    Console.WriteLine($"\nThere is {enemiesInRoom} enemy in this room left to fight!\n");
                                else
                                    Console.WriteLine($"\nThere are {enemiesInRoom} enemies in this room left to fight!\n");
                            }

                            if (!enemyAlive)
                            {
                                Pause();

                                if (enemiesInRoom > 0)
                                    ShowStats(adventurers);
                                else
                                {
                                    Console.WriteLine("\nThe room is cleared, so the party moves on to the next." +
                                        $"\n(There are {map.GetLocationQueue().Count} more rooms to enter before escape is possible.)\n");

                                }

                            }


                            // set their lastRoom to the current location
                            //fighter.SetLastRoom(location);
                        }
                        else // if they have taken damage in this location or against this enemy in this room,
                             // move on to a different fighter
                        {
                            // this should happen automatically, but keep the else clause just in case
                        }


                    } while (//fighter.GetLastRoom().Equals(location) ||
                            fighter.GetBadEnemy().Equals(thisEnemy) ||
                            fighter.GetBadLocation().Equals(location) ||
                            fighter.GetTookDamage());

                    // get a new enemy
                    thisEnemy = enemy.GetEnemy();

                    // loop through the characters to set tookDamage to false - after an enemy is defeated
                    foreach (Character adventurer in adventurers)
                    {
                        adventurer.SetTookDamage(false);
                    }
                }


                // if the rooms are out and characters are still alive, tell them they win
                // if there are still rooms but no characters, they lose
                if (CharactersLeft(adventurers) == 0)
                    Console.WriteLine("\n\nAll the adventurers are dead.\nGAME OVER!");
                else if (map.GetLocationQueue().Count == 0)
                    Console.WriteLine("\n\nThe remaining party escapes the dungeon alive." +
                        "\nYOU WIN!");



            } while (map.GetLocationQueue().Count > 0 && CharactersLeft(adventurers) > 0);

            
            

        }

        // Show all character stats
        public static void ShowStats(List<Character> adventurers)
        {
            Console.WriteLine("\n**Stats**");
            // loop through the characters to show their hp
            foreach (Character adventurer in adventurers)
            {
                if (adventurer.GetHp() != 0)
                    Console.WriteLine($"{adventurer.GetName()}: {adventurer.GetHp()} HP");
            }
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
                    characters.Remove(characters[i]); // does not work for some reason
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
                bool nameExists;

                do // keep asking until a name is entered
                {
                    nameExists = false;

                    // ask the name of the adventure
                    Console.Write($"Name for adventurer #{i + 1}: ");

                    // store name of adventurer in temporary variable
                    name = Console.ReadLine();

                    name = name.Trim();
                    //Console.WriteLine($"Name:~{name}~"); // test

                    // capitalize the first letter just in case - to make the  better
                    if (name.Length > 1)
                    {
                        name = char.ToUpper(name[0]) + name.Substring(1);
                    }
                    else
                    {
                        name = name.ToUpper();
                    }

                    // check if the name already exists - to avoid repeated names
                    foreach (Character adventurer in list)
                    {
                        if (adventurer.GetName().Equals(name))
                            nameExists = true;
                    }

                    // if there's no entry, tell them invalid entry.
                    if (name.Equals(""))
                    {
                        Console.Write("Invalid - a name must be entered.\n");
                    }
                    else if (nameExists)
                        Console.Write("Invalid - each name must be unique.\n");
                } while (name.Equals("") || nameExists);

                

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
