using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Timers
{
    public class Timer
    {
        protected static int time = DateTime.Now.Hour;

        public static int GetTime()
        {
            return time;
        }
    }
}
