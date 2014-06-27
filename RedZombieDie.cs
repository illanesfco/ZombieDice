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
        private ZombieDieValue ValueRolled;
        #endregion

        #region Constructors
        public RedZombieDie()
        {

        }

        public RedZombieDie(Random rand)
        {
            Rand = rand;
            //DisplayType();
        }
        #endregion

        #region Methods
        public ZombieDieValue RollDie()
        {
            Roll = Rand.Next(1, 7);
            if (Roll <= 3)
            {
                ValueRolled = ZombieDieValue.Shot;
                return ZombieDieValue.Shot;
            }
            else if (Roll <= 5)
            {
                ValueRolled = ZombieDieValue.Runner;
                return ZombieDieValue.Runner;
            }
            else
            {
                ValueRolled = ZombieDieValue.Brain;
                return ZombieDieValue.Brain;
            }
        }

        public ZombieDieColor DieType()
        {
            return ZombieDieColor.Red;
        }

        public ZombieDieValue GetValueRolled()
        {
            return ValueRolled;
        }

        public void DisplayType()
        {
            Console.WriteLine("Red");
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Red: " + ValueRolled);
        }
        #endregion
    }
}
