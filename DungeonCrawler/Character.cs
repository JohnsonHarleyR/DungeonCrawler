using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawler
{
    class Character
    {
        private readonly Random random = new Random();
        private readonly string name;
        private readonly string badEnemy; // enemy and location where character can't fight
        private readonly string badLocation;
        private int hp;
        private string lastRoom = "none";
        //private string lastEnemy = "none";
        private bool tookDamage = false;


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
        // set the hp
        public void SetHp(int hp)
        {
            this.hp = hp;
        }
        public string GetLastRoom()
        {
            return lastRoom;
        }
        // set the last room
        public void SetLastRoom(string room)
        {
            lastRoom = room;
        }
        // Get last enemy
        /*
        public string GetLastEnemy()
        {
            return lastRoom;
        }
        // set the last room
        public void SetLastEnemy(string enemy)
        {
            lastEnemy = enemy;
        }
        */
        // Get tookDamage
        public bool GetTookDamage()
        {
            return tookDamage;
        }
        // set the last room
        public void SetTookDamage(bool damage)
        {
            tookDamage = damage;
        }

    }
}
