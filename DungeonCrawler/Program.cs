using System;
using System.Collections.Generic;

namespace DungeonCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            // variables
            List<string> adventurers = new List<string>();
            int NUM_ADVENT = 6;


            Console.WriteLine("Dungeon Crawler");

            // Name the adventurers
            NameAdventurers(adventurers, NUM_ADVENT);
        }

        // Pause
        public static void Pause()
        {
            Console.WriteLine("\n(Hit enter to continue.)");
            Console.ReadLine();
        }


        // Name the adventurers
        public static void NameAdventurers(List<string> list, int numAdventurers)
        {
            // loop for the number of adventurers
            for (int i = 0; i < numAdventurers; i++)
            {
                string temp;

                do // keep asking until a name is entered
                {
                    // ask the name of the adventure
                    Console.Write($"\nName for adventurer #{i + 1}: ");

                    // store name of adventurer in temporary variable
                    temp = Console.ReadLine();

                    temp.Trim();

                    // if there's no entry, tell them invalid entry.
                    if (temp.Equals(""))
                    {
                        Console.Write("Invalid Entry.");
                    }
                } while (temp.Equals(""));

                // capitalize the first letter just in case - to make the  better
                if (temp.Length > 1)
                {
                    temp = char.ToUpper(temp[0]) + temp.Substring(1);
                }
                else
                {
                    temp = temp.ToUpper();
                }

                // add it to the list
                list.Add(temp);

                //Console.WriteLine(temp); // test
            }
        }

    }
    

}
