using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Timers
{
    class ClasicTimer : Timer
    {
        public ClasicTimer(int _time)
        {
            time = _time;
        }

        public void setTime(int newTime)
        {
            time = newTime;
        }
    }
}
