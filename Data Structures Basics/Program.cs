/*This is a program that creates a queue that is 100 people long, and then allows the people to go through the "burger line"
 * and order burgers. A random number is generated for each time the person's name is shown up in the queue and the 
 * total number of burgers is stored in the dictionary that uses each person's name as the key. When finished, the results
 * are printed out. 
*/

// Author: Kory Hutchison
// Date: 9/21/2016

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures_Basics
{
    class Program
    {
        // This is the random number object
        public static Random random = new Random();

        // This is the random name function that returns a name from the array in a random fashion.
        public static string randomName()
        {
            string[] names = new string[8] { "Dan Morain", "Emily Bell", "Carol Roche", "Ann Rose", "John Miller", "Greg Anderson", "Arthur McKinney", "Joann Fisher" };
            int randomIndex = Convert.ToInt32(random.NextDouble() * 7);
            return names[randomIndex];
        }

        // This returns the number of burgers.
        public static int randomNumberInRange()
        {
            return Convert.ToInt32(random.NextDouble() * 20);
        }

        static void Main(string[] args)
        {
            // Create the queue and Dictionary and create a vaiable to store the customer name called sCustName
            Queue<string> CustLine = new Queue<string>();
            Dictionary<string, int> CustDictionary = new Dictionary<string, int>();

            // This for loop loads up the Queue with 100 people 
            for(int iCount = 0; iCount < 100; iCount++)
            {
                CustLine.Enqueue(randomName());
            }

            // This for loop takes a name out of the queue and puts it in the dictionary.
            foreach(string sCustName in CustLine)
            {
                // This if statement checks to see if the name already exists in the dictionary, and if it doesn't, it will put the name in.
                if (!CustDictionary.ContainsKey(sCustName))
                {
                    CustDictionary.Add(sCustName, 0);                   
                }
                // Add the number to the dictionary
                CustDictionary[sCustName] += randomNumberInRange();
            }

            //This foreach loop prints out all the results.
            foreach(var CustList in CustDictionary)
            {
                Console.WriteLine(CustList.Key.PadRight(25, ' ') + CustList.Value);
            }
            Console.Read();

        }
    }
}
