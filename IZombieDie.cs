﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieDice
{
    interface IZombieDie
    {
        ZombieDieValue RollDie();
        ZombieDieColor DieType();
        ZombieDieValue GetValueRolled();
        void DisplayType();
        void DisplayInfo();
    }
}
