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
        private int Roll;
        private ZombieDieValue ValueRolled;
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
            {
                ValueRolled = ZombieDieValue.Shot;
                return ZombieDieValue.Shot;
            }
            else if (Roll <= 3)
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
            return ZombieDieColor.Green;
        }

        public ZombieDieValue GetValueRolled()
        {
            return ValueRolled;
        }

        public void DisplayType()
        {
            Console.WriteLine("Green");
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Green: " + ValueRolled);
        }
        #endregion
    }
}
