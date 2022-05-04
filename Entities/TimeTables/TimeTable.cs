using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.TimeTables
{
    public class TimeTable : ITimeTable
    {
        private readonly TimeState[] table;

        public TimeTable()
        {
            table = new TimeState[24];
            for(int i = 0; i<table.Length; i++)
            {
                table[i] = TimeState.Free;
            }
        }

        public bool IsTimeFree(int time)
        {
            return table[time] == TimeState.Free;
        }

        public bool IsTimeConstant(int time)
        {
            return table[time] == TimeState.Constant;
        }

        public bool IsTimeTemporary(int time)
        {
            return table[time] == TimeState.Temporary;
        }

        public void SetFree(int time)
        {
            table[time] = TimeState.Free;
        }

        public void SetFree(int beginTime, int endTime)
        {
            for(int time = beginTime; time <= endTime; time++)
            {
                SetFree(time);
            }
        }
        
        public void SetConsonant(int time)
        {
            table[time] = TimeState.Constant;
        }

        public void SetConsonant(int beginTime, int endTime)
        {
            for (int time = beginTime; time <= endTime; time++)
            {
                SetConsonant(time);
            }
        }

        public void SetTemporary(int time)
        {
            table[time] = TimeState.Temporary;
        }

        public void SetTemporary(int beginTime, int endTime)
        {
            for (int time = beginTime; time <= endTime; time++)
            {
                SetTemporary(time);
            }
        }

    }
    
}
