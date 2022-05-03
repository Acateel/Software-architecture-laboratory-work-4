using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.TimeTables;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            ITimeTable time = new TimeTable();
            time.SetConsonant(19, 21);
            Console.WriteLine(time.IsTimeFree(18));
            Console.WriteLine(time.IsTimeFree(19));
            Console.WriteLine(time.IsTimeFree(21));
            Console.WriteLine(time.IsTimeFree(22));
        }
    }
}
