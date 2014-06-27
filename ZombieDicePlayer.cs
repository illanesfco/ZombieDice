using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieDice
{
    class ZombieDicePlayer
    {
        #region Properties
        private string Name; // The player's name
        private int Score; // Keeps track of the brains that a player has banked (game ends after a player banks 13 brains)
        private int Strikes; // Keepts track of how many times a player has been shot on his/her turn. 3 strikes means the turn is over and no brains are banked
        #endregion

        #region Constructors
        public ZombieDicePlayer(string name)
        {
            Name = name;
            Score = 0;
            Strikes = 0;
        }
        #endregion

        #region Methods
        public string giveName()
        {
            return Name;
        }

        public void AddToBank(int brains) // Adds brains accrued during a player's turn to their score.
        {
            Score += brains;
        }

        public bool CheckForTurnOver(int timesShot) // Add shots accrued in the most recent roll to the Player's strikes. Returns true if the player has been shot three
            // or more times on their turn (indicating that their turn is over)
        {
            Strikes += timesShot;
            if (Strikes >= 3)
                return true;
            else return false;
        }
        #endregion
    }
}
