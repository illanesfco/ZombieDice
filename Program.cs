using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieDice
{
    class Program
    {
        static void Main(string[] args)
        {
            Program myApp = new Program();
            Random rand = new Random();
            Stack<IZombieDie> cup = new Stack<IZombieDie>(13); // creates a "dice cup" that contains at most 13 dice
            //myApp.TestDice(rand);
            myApp.PopulateCup(cup, rand);
        
        }

        /*public void TestDice(Random rand)
        {
            GreenZombieDie green = new GreenZombieDie(rand);
            YellowZombieDie yellow = new YellowZombieDie(rand);
            RedZombieDie red = new RedZombieDie(rand);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Green: Roll = " + green.RollDie() + " (" + green.Roll + ")");
                Console.WriteLine("Yellow: Roll = " + yellow.RollDie() + " (" + yellow.Roll + ")");
                Console.WriteLine("Red: Roll = " + red.RollDie() + " (" + red.Roll + ")");
                Console.WriteLine();
            }
        }*/

        public void PopulateCup(Stack<IZombieDie> cup, Random rand) 
            // Fills the cup with a random proportion of green, yellow, and red zombie dice. The total number of dice in the cup is 13.
        {
            int seed;
            for (int i = 0; i <= 12; i++)
            {
                seed = rand.Next(1, 4);
                if (seed == 1)
                    cup.Push(new RedZombieDie(rand));
                else if (seed == 2)
                    cup.Push(new YellowZombieDie(rand));
                else
                    cup.Push(new GreenZombieDie(rand));
                Console.WriteLine(i + 1);
                Console.WriteLine();
            }
            //DeclareDice(cup);
        }

        public void DeclareDice(Stack<IZombieDie> cup) //tells you how many of each die there is in the cup
        {
            int greenDice = 0, yellowDice = 0, redDice = 0;
            foreach (GreenZombieDie die in cup)
                greenDice++;
            foreach (YellowZombieDie die in cup)
                yellowDice++;
            foreach (RedZombieDie die in cup)
                redDice++;
            Console.WriteLine("Green Dice: " + greenDice);
            Console.WriteLine("Yellow Dice: " + yellowDice);
            Console.WriteLine("Red Dice: " + redDice);
        }

    }
}
