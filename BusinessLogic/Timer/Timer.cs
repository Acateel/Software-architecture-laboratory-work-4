﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Timer
{
    class Timer
    {
        protected static int time = 0;

        public static int GetTime()
        {
            return time;
        }
    }
}
