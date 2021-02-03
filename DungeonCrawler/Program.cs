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
                    Console.WriteLine($"\nThe {CharactersLeft(adventurers)} adventurers enter the {location}. " +
                        $"\nThere are {enemiesInRoom} enemies to fight!\n");

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


                // NOTE may not need to record lastEnemy and last location, may only need
                // to record if they took damage in tht particular room - to simplify things


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
                do {
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
                                Console.WriteLine($"The character is feeble against this enemy and takes {damage} HP damage!");
                            }
                            else if (fighter.GetBadLocation().Equals(location))
                            {
                                Console.WriteLine($"This character struggles to fight in the {location}, thus they take {damage} HP damage against the enemy!");

                            }
                            
                           // Console.WriteLine($"They take {damage} HP damage.");

                            // if the hp is less than 0, set it to 0
                            if (fighter.GetHp() <= 0)
                            {
                                fighter.SetHp(0); // set it to 0 just in case it's needed in the future
                                Console.WriteLine($"\n{fighter.GetName()} has died! That is unfortunate.");
                            }

                            // let the player know the enemy is still alive
                            Console.Write($"\nThe {thisEnemy} is still alive!");

                        }
                        else // otherwise, the character defeats the enemy
                        {
                            Console.WriteLine($"This character comes out strong and defeats the enemy!");

                        }

                        Pause();


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
                        fighter.GetBadLocation().Equals(location));

                // loop through the characters to set tookDamage to false - after an enemy is defeated
                foreach (Character adventurer in adventurers)
                {
                    adventurer.SetTookDamage(false);
                }

                // AFTER CHARACTERS ARE DONE FIGHTING ENEMIES IN THE ROOM
                // now set all the characters last locations to the last location


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
