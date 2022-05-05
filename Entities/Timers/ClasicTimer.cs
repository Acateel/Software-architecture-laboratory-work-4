using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Timers
{
    public class ClasicTimer : Timer
    {

        public static void setTime(int newTime)
        {
            time = newTime;
        }
    }
}
