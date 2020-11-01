using System;
using System.Collections.Generic;
using System.Linq;



namespace DiceGame
{
    class Program
    {
        // Tracks dice rolls and amount of rolls
        public static List<int> rolls = new List<int>();
        public static int numOfRolls = 0;





        // Single dice roll - called by diceGame
        static int SingleRoll()
        {
            Console.WriteLine("Dice Roll!");
            numOfRolls++;
            Console.WriteLine("Roll no." + numOfRolls);
            Random rnd = new Random();
            return rnd.Next(1, 7);
        }





        static void DoubleRoll()
        {
            Console.WriteLine("You rolled a 1");

            int[] doubles = { SingleRoll(), SingleRoll() };

            foreach (var number in doubles)
            {
                if (number != 1)
                {
                    rolls.Add(number);
                }
            }

            if (doubles.Contains(1))
            {
                DoubleRoll();
            }
        }





        static void Main(string[] args)
        {
            // Reset roll trackers for each game
            rolls.Clear();
            numOfRolls = 0;



            // Ask user for number of rolls
            int rollOptions = 0;
            while (rollOptions < 1 | rollOptions > 4)
            {
                Console.WriteLine("How many rolls? (1 - 4)");
                rollOptions = Convert.ToInt32(Console.ReadLine());
            }



            // Roll dice as many times as user input
            for (int i = 0; i < rollOptions; i++)
            {
                int roll = SingleRoll();

                if (roll != 1)
                {
                    rolls.Add(roll);
                    Console.WriteLine("Total sum of rolls is: " + rolls.Sum());
                }
                else
                {
                    DoubleRoll();
                }
            }



            // Logs score and rolls
            Console.WriteLine("\nDice Game Summary:");
            Console.WriteLine("Your rolls: " + "[{0}]", string.Join(", ", rolls));
            Console.WriteLine("Total Sum: " + rolls.Sum());
            Console.WriteLine("Total Rolls: " + numOfRolls);

        }
    }
}
