using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.TimeTables
{
    public interface ITimeTable
    {
        TimeState[] Table { get; set; }
        bool IsTimeFree(int time);
        bool IsTimeConstant(int time);
        bool IsTimeTemporary(int time);
        void SetFree(int time);
        void SetFree(int beginTime, int endTime);
        void SetConsonant(int time);
        void SetConsonant(int beginTime, int endTime);
        void SetTemporary(int time);
        void SetTemporary(int beginTime, int endTime);
    }
    public enum TimeState
    {
        Free,
        Constant,
        Temporary
    }
}
