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
        private List<IZombieDie> testPlayerDice = new List<IZombieDie>();

        static void Main(string[] args)
        {
            bool gameOver = false;
            Program myApp = new Program();
            Random rand = new Random();
            List<IZombieDie> cup = myApp.CupSetup();
            //myApp.TestDice();
            List<ZombieDicePlayer> players = myApp.PlayerSetup();

            myApp.RunGame(cup, players);

            /*while (gameOver == false)
            {
                
            }*/


            Console.WriteLine("Press any key to quit...");
            Console.ReadLine();
        
        }

        /*public void TestDice()
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
        }*/

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
            Console.WriteLine("Total Dice: " + cup.Count);
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
            //DeclarePlayers(playerList);
            Console.WriteLine();
            return playerList;
        }

        public void DeclarePlayers(List<ZombieDicePlayer> playerList) // tells you the names of each player in the game
        {
            foreach (ZombieDicePlayer player in playerList)
                Console.WriteLine(player.giveName());

            Console.WriteLine("Total Players: " + playerList.Count);
        }

        public void RunGame(List<IZombieDie> cup, List<ZombieDicePlayer> players)
        {
            int brainsRolled = 0;
            int runnersRolled = 0;
            int shotsRolled = 0;
            List<IZombieDie> playerDice = new List<IZombieDie>(); // collection of the three dice player will roll
            IZombieDie tempDie;
            int seed;
            string keepRolling = "";

            foreach (ZombieDicePlayer player in players)
            {
                Console.WriteLine("---------- " + player.giveName() + "'s Turn ----------");
                Console.WriteLine();

takedice:       Console.WriteLine("Taking dice from cup: "); // TODO: think of a way to do this more cleanly
               
                while (playerDice.Count<3) // take dice from the cup unti player has 3
                {
                    seed = Rand.Next(0, cup.Count);
                    tempDie = cup.ElementAt(seed); // assign a random die from the cup as the die to roll
                    cup.RemoveAt(seed); // remove the die from the cup
                    playerDice.Add(tempDie);
                }
                foreach (IZombieDie die in playerDice)
                    die.DisplayType();

                Console.WriteLine();
                Console.WriteLine("Rolling dice...");
                foreach (IZombieDie die in playerDice) // roll and "score" each die 
                {
                    die.RollDie();
                    die.DisplayInfo();
                    if (die.GetValueRolled() == ZombieDieValue.Brain)
                    {
                        brainsRolled++; 
                        //playerDice.Remove(die);
                    }
                    else if (die.GetValueRolled() == ZombieDieValue.Shot)
                    {
                        shotsRolled++;
                        //playerDice.Remove(die);
                    }
                    else // runner dice are not discarded
                        runnersRolled++;
                }
                Console.WriteLine();
                Console.WriteLine("Brains: " + brainsRolled + "\t Shots: " + shotsRolled + "\t Runners: " + runnersRolled);
                Console.WriteLine();

                if (shotsRolled >= 3)// end turn for player if they've been shot 3 or more times
                {
                    Console.WriteLine(player.giveName() + " has been shot 3 or more times! " + player.giveName() + "'s turn is over!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();

                    //clear data for next player
                    keepRolling = "";
                    brainsRolled = 0;
                    shotsRolled = 0;
                    runnersRolled = 0;
                    playerDice.Clear();
                    Console.WriteLine();
                }

                else
                {
                    while (keepRolling != "y" && keepRolling != "n")
                    {
                        Console.Write("Would you like to continue rolling (y), or to stop and score your brains (n)? :");
                        keepRolling = Console.ReadLine();
                    }

                    switch (keepRolling)
                    {
                        case "y":
                            //go back to rolling dice
                            keepRolling = "";
                            playerDice = removeNonRunners(playerDice);
                            Console.WriteLine("Dice in playerDice (in game): ");
                            foreach (IZombieDie die in playerDice)
                                die.DisplayType();
                            Console.WriteLine();
                            goto takedice;
                            break;

                        case "n":
                            player.AddToBank(brainsRolled);
                            player.DisplayInfo();
                            break;
                        default:
                            break;
                    }

                    //clear data for next player
                    keepRolling = "";
                    brainsRolled = 0;
                    shotsRolled = 0;
                    runnersRolled = 0;
                    playerDice.Clear();
                    Console.WriteLine();
                }
                
            } // end of foreach loop

        } // end of RunGame

        public List<IZombieDie> removeNonRunners(List<IZombieDie> playerDice) // takes in rolled dice, and remove all dice except those rolled as runners
            // doesn't currently properly pass saved dice back
        {
            Console.WriteLine("Removing Brains and Shots from Dice to be rolled...");
            List<IZombieDie> temp = new List<IZombieDie>();
            foreach (IZombieDie die in playerDice)
            {
                if (die.GetValueRolled() == ZombieDieValue.Runner)
                    temp.Add(die);
            }
            playerDice.Clear(); // remove all dice

            Console.WriteLine("Dice to be saved: ");
            foreach (IZombieDie die in temp)
                die.DisplayType();
            Console.WriteLine();

            playerDice = temp; // put "saved" dice back in playerDice
            Console.WriteLine("Dice in playerDice (in method): ");
            foreach (IZombieDie die in playerDice)
                die.DisplayType();
            Console.WriteLine();
            temp.Clear();
            return playerDice;
        }
    }
}
