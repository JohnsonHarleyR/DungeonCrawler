using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawler
{
    class Character
    {
        private string name;
        private string badEnemy; // enemy and location where character can't fight
        private string badLocation;


        // constructor
        public Character(string name,string enemy, string location)
        {
            this.name = name;
            badEnemy = enemy;
            badLocation = location;

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

    }
}
