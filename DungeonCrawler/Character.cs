using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawler
{
    class Character
    {
        private Random random = new Random();
        private string name;
        private string badEnemy; // enemy and location where character can't fight
        private string badLocation;
        private int hp;


        // constructor
        public Character(string name,string enemy, string location)
        {
            this.name = name;
            badEnemy = enemy;
            badLocation = location;

            // randomly select how many hit points the character has
            hp = random.Next(50, 101);

        }

        // Get the different properties
        public string GetName()
        {
            return name;
        }
        public string GetBadEnemy()
        {
            return badEnemy;
        }
        public string GetBadLocation()
        {
            return badLocation;
        }
        public int GetHp()
        {
            return hp;
        }

    }
}
