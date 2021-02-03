using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawler
{
    class Game
    {
        // variables
        List<string> characters = new List<string>();

        // constructor

        // methods

        // Add a character to the list
        public void AddCharacter(string name)
        {
            characters.Add(name);
        }


        // Shuffle a stack
        public void Shuffle(Stack<string> stack)
        {
            // variables
            Random random = new Random();
            List<string> list = new List<string>(); // this will be changed to a new stack
            List<int> nums = new List<int>(); // use random to pull position from list
            int max = stack.Count; // decreases with each random number

            // add values to nums depending on size of stack stack
            for (int i = 0; i < stack.Count; i++)
            {
                nums.Add(i);
            }

            var values = stack.ToArray();
            stack.Clear();

            // test
            //Console.Write(nums.Count);

            // testing the shuffle method
            //Console.Write("\nTesting shuffle: ");

            while (nums.Count > 0)
            {
                // get random value from list
                int num = nums[random.Next(0, nums.Count)]; // the next value to add
                nums.Remove(num); // remove that value from list
                string value = values[num];
                // add random value to the stack
                stack.Push(value);

                //Console.Write($"{value}, "); //testing
            }


        }
        
    }
}
