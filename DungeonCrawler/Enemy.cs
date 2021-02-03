using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawler
{
    class Enemy
    {
        // variables
        Random random = new Random();
        private List<string> types = new List<string> { "zombie", "insane clown", "demon",
        "possessed gnome", "giant spider", "vampire", "werewolf"}; // types of enemies
        private Stack<string> deck = new Stack<string>(); // randomly selected types
        private int DECK_SIZE = 50; // should be higher than the max number of enemies

        // constructor
        public Enemy()
        {
            // form the deck
            for (int i = 0; i < DECK_SIZE; i++)
            {
                // get random type to put in the deck each time
                deck.Push(types[random.Next(0, types.Count)]);
            }
        }

        // Get a new enemy - returns the next type
        public string GetEnemy()
        {
            return deck.Pop();
        }


        // Get the damage an enemy is doing
        public int GetDamage(string type)
        {
            int damage;

            // damage will depend on the enemy type
            switch (type)
            {
                case ("zombie"):
                    damage = random.Next(10, 16);
                    break;
                case ("insane clown"):
                    damage = random.Next(12, 19);
                    break;
                case ("possessed gnome"):
                    damage = random.Next(7, 13);
                    break;
                case ("giant spider"):
                    damage = random.Next(9, 15);
                    break;
                case ("vampire"):
                    damage = random.Next(16, 22);
                    break;
                case ("werewolf"):
                    damage = random.Next(18, 25);
                    break;
                case ("demon"):
                    damage = random.Next(25, 33);
                    break;
                default:
                    damage = 0;
                    break;
            }
            return damage;
        }

        // get the list of enemy types
        public List<string> GetTypes()
        {
            return types;
        }

    }
}
