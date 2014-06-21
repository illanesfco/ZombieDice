using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieDice
{
    class GreenZombieDie: IZombieDie // 1 = shot, 2-3 = runner, 4+ = brain
    {
        #region Properties
        private Random Rand;
        public int Roll; // TODO: change to private once testing is done
        #endregion 

        #region Constructors
        public GreenZombieDie()
        {

        }
        public GreenZombieDie(Random rand)
        {
            Rand = rand;
            //DisplayType();
        }
        #endregion

        #region Methods
        public ZombieDieValue RollDie()
        {
            Roll = Rand.Next(1, 7);
            if (Roll == 1)
                return ZombieDieValue.Shot;
            else if (Roll <= 3)
                return ZombieDieValue.Runner;
            else
                return ZombieDieValue.Brain;
        }

        public ZombieDieColor DieType()
        {
            return ZombieDieColor.Green;
        }

        public void DisplayType()
        {
            Console.WriteLine("Green");
        }
        #endregion
    }
}
