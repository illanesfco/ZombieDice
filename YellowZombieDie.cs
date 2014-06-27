using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieDice
{
    class YellowZombieDie: IZombieDie // 1-2 = shot, 3-4 = runner, 5-6 = brain 
    {
        #region Properties
        private Random Rand;
        private int Roll; 
        private ZombieDieValue ValueRolled;
        #endregion

        #region Constructors
        public YellowZombieDie()
        {
        }
        public YellowZombieDie(Random rand)
        {
            Rand = rand;
            //DisplayType();
        }
        #endregion

        #region Methods
        public ZombieDieValue RollDie()
        {
            Roll = Rand.Next(1, 7);
            if (Roll <= 2)
            {
                ValueRolled = ZombieDieValue.Shot;
                return ZombieDieValue.Shot;
            }
            else if (Roll <= 4)
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
            return ZombieDieColor.Yellow;
        }

        public ZombieDieValue GetValueRolled()
        {
            return ValueRolled;
        }

        public void DisplayType()
        {
            Console.WriteLine("Yellow");
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Yellow: " + ValueRolled);
        }
        #endregion
    }
}
