using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Carts;
using Entities.Clubs;

namespace Entities.TimeTables
{
    public class TimeTable : Entity
    {
        public TimeState[] Table { get; set; }

        public TimeTable()
        {
            Table = new TimeState[24];
            for (int i = 0; i < Table.Length; i++)
            {
                Table[i] = TimeState.Free;
            }
        }

        public bool IsTimeFree(int time)
        {
            return Table[time] == TimeState.Free;
        }

        public bool IsTimeConstant(int time)
        {
            return Table[time] == TimeState.Constant;
        }

        public bool IsTimeTemporary(int time)
        {
            return Table[time] == TimeState.Temporary;
        }

        public void SetFree(int time)
        {
            Table[time] = TimeState.Free;
        }

        public void SetFree(int beginTime, int endTime)
        {
            for (int time = beginTime; time <= endTime; time++)
            {
                SetFree(time);
            }
        }

        public void SetConsonant(int time)
        {
            Table[time] = TimeState.Constant;
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
            Table[time] = TimeState.Temporary;
        }

        public void SetTemporary(int beginTime, int endTime)
        {
            for (int time = beginTime; time <= endTime; time++)
            {
                SetTemporary(time);
            }
        }
    }
    public enum TimeState
    {
        Free,
        Constant,
        Temporary
    }
}
