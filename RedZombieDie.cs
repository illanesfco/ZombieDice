using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieDice
{
    class RedZombieDie: IZombieDie // 1-3 = shot, 4-5 = runner, 6 = brain
    {
        #region Properties
        private Random Rand;
        public int Roll;
        #endregion

        #region Constructors
        public RedZombieDie()
        {

        }

        public RedZombieDie(Random rand)
        {
            Rand = rand;
            Console.WriteLine(ToString());
        }
        #endregion

        #region Methods
        public ZombieDieValue RollDie()
        {
            Roll = Rand.Next(1, 7);
            if (Roll <= 3)
                return ZombieDieValue.Shot;
            else if (Roll <= 5)
                return ZombieDieValue.Runner;
            else
                return ZombieDieValue.Brain;
        }

        public override string ToString()
        {
            return "Red";
        }
        #endregion
    }
}
