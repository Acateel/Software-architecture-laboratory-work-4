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
        public String Table { get; set; }

        public TimeTable()
        {
            Table = "FFFFFFFFFFFFFFFFFFFFFFFF";
        }

        public TimeTable(int id, string table)
        {
            Id = id;
            Table = table;
        }

        public bool IsTimeFree(int time)
        {
            return Table[time] == 'F';
        }

        public bool IsTimeConstant(int time)
        {
            return Table[time] == 'C';
        }

        public bool IsTimeTemporary(int time)
        {
            return Table[time] == 'T';
        }

        public void SetFree(int time)
        {
            SetStatus(time, 'F');
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
            SetStatus(time, 'C');
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
            SetStatus(time, 'T');
        }

        public void SetTemporary(int beginTime, int endTime)
        {
            for (int time = beginTime; time <= endTime; time++)
            {
                SetTemporary(time);
            }
        }

        private void SetStatus(int time, char status)
        {
            String newTable = "";
            for (int i = 0; i < Table.Length; i++)
            {
                if (i == time)
                {
                    newTable += status;
                }
                else
                {
                    newTable += Table[i];
                }
            }
            Table = newTable;
        }
    }
}
