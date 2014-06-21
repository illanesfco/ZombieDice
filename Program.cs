using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieDice
{
    class Program
    {
        private static Random Rand = new Random();

        static void Main(string[] args)
        {
            Program myApp = new Program();
            Random rand = new Random();
            Stack<IZombieDie> cup = new Stack<IZombieDie>(13); // creates a "dice cup" that contains at most 13 dice
            myApp.TestDice();
            myApp.PopulateCup(cup);
        
        }

        public void TestDice()
        {
            Console.WriteLine("Testing Dice...");
            Console.WriteLine();
            GreenZombieDie green = new GreenZombieDie(Rand);
            YellowZombieDie yellow = new YellowZombieDie(Rand);
            RedZombieDie red = new RedZombieDie(Rand);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Green: Roll = " + green.RollDie() + " (" + green.Roll + ")");
                Console.WriteLine("Yellow: Roll = " + yellow.RollDie() + " (" + yellow.Roll + ")");
                Console.WriteLine("Red: Roll = " + red.RollDie() + " (" + red.Roll + ")");
                Console.WriteLine();
            }
            Console.WriteLine("...done");
            Console.WriteLine();
        }

        public void PopulateCup(Stack<IZombieDie> cup) 
            // Fills the cup with a random proportion of green, yellow, and red zombie dice. The total number of dice in the cup is 13.
        {
            Console.WriteLine("Adding Dice to Cup...");
            int seed;
            for (int i = 0; i <= 12; i++)
            {
                //Console.Write(i + 1 + " - ");
                seed = Rand.Next(1, 4);
                if (seed == 1)
                    cup.Push(new RedZombieDie(Rand));
                else if (seed == 2)
                    cup.Push(new YellowZombieDie(Rand));
                else
                    cup.Push(new GreenZombieDie(Rand));
                
                //Console.WriteLine();
            }
            Console.WriteLine("...done");
            DeclareDice(cup);
        }

        public void DeclareDice(Stack<IZombieDie> cup) //tells you how many of each die there is in the cup
        {
            //Console.WriteLine("------------------------Declaring Contents of Dice Cup------------------------");
            int greenDice = 0, yellowDice = 0, redDice = 0;
            foreach (IZombieDie die in cup)
            {
                if (die.DieType() == ZombieDieColor.Green)
                    greenDice++;
                else if (die.DieType() == ZombieDieColor.Yellow)
                    yellowDice++;
                else
                    redDice++;
                //die.DisplayType();
            }
            Console.WriteLine();
            Console.WriteLine("Green Dice: " + greenDice);
            Console.WriteLine("Yellow Dice: " + yellowDice);
            Console.WriteLine("Red Dice: " + redDice);
            Console.WriteLine();
        }

    }
}
