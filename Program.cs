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
            List<IZombieDie> testcup = myApp.CupSetup();
            myApp.TestDice();
            List<ZombieDicePlayer> players = myApp.PlayerSetup();
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        
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

        public List<IZombieDie> CupSetup()
        {
            Console.WriteLine("Creating cup of dice...");
            List<IZombieDie> cup = new List<IZombieDie>();
            int seed;
            for (int i = 0; i <= 12; i++)
            {
                //Console.Write(i + 1 + " - ");
                seed = Rand.Next(1, 4);
                if (seed == 1)
                    cup.Add(new RedZombieDie(Rand));
                else if (seed == 2)
                    cup.Add(new YellowZombieDie(Rand));
                else
                    cup.Add(new GreenZombieDie(Rand));

                //Console.WriteLine();
            }
            Console.WriteLine("...done");
            DeclareDice(cup);
            return cup;
        }

        public void DeclareDice(List<IZombieDie> cup) //tells you how many of each die there is in the cup
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

        public List<ZombieDicePlayer> PlayerSetup() //sets up the players in the game
        {
            int numPlayers = 0;
            do // validation loop
            {
                Console.Write("Please enter the number of players (2-8): ");
                numPlayers = Int32.Parse(Console.ReadLine());
            }
            while (numPlayers < 2 || numPlayers > 8);
                
            ZombieDicePlayer newPlayer;
            List<ZombieDicePlayer> playerList = new List<ZombieDicePlayer>();
            for (int i = 0; i < numPlayers; i++)
            {
                Console.Write("Player " + (i + 1) + ", please enter your name: ");
                newPlayer = new ZombieDicePlayer(Console.ReadLine());
                playerList.Add(newPlayer);
            }
            DeclarePlayers(playerList);
            return playerList;
        }

        public void DeclarePlayers(List<ZombieDicePlayer> playerList) // tells you the names of each player in the game
        {
            foreach (ZombieDicePlayer player in playerList)
                player.DisplayName();
        }

    }
}
