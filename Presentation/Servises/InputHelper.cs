using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Entities.TimeTables;

namespace Presentation.Servises
{
    public static class InputHelper
    {
        public static string GetName()
        {
            string name = "";
            while (!Regex.IsMatch(name, "[\\w]+[\\w ]*"))
            {
                Console.WriteLine("Write name:");
                name = Console.ReadLine();
            }
            return name;
        }

        public static string GetLocation()
        {
            string location = "";
            while (!Regex.IsMatch(location, "[\\w]+[\\w ]*"))
            {
                Console.WriteLine("Write location:");
                location = Console.ReadLine();
            }
            return location;
        }

        public static ITimeTable GetTimeTable()
        {
            ITimeTable timeTable = new TimeTable();
            timeTable = SetTimeTable(timeTable);
            return timeTable;
        }

        public static void ShowTimeTable(ITimeTable table)
        {
            Console.WriteLine("Time table");
            int count = 0;
            for(int i = 0; i < 24; i++)
            {
                string status = "";
                if (table.IsTimeFree(i))
                    status = "F";
                else if (table.IsTimeConstant(i))
                    status = "C";
                else
                    status = "T";
                if(i < 10)
                {
                    Console.Write(" ");
                }
                Console.Write(i + "-" + status +  " | ");
                count++;
                if (count == 4)
                {
                    count = 0;
                    Console.WriteLine();
                }
            }
        }

        public static ITimeTable SetTimeTable(ITimeTable table)
        {
            bool status = true;
            while (status)
            {
                ShowTimeTable(table);
                ShowTimeTableMenu();
                int command = GetCommant();
                switch (command)
                {
                    case 1:
                        table.SetFree(GetTime(), GetTime());
                        break;
                    case 2:
                        table.SetConsonant(GetTime(), GetTime());
                        break;
                    case 3:
                        table.SetTemporary(GetTime(), GetTime());
                        break;
                    case 4:
                        status = false;
                        break;
                    default:
                        Console.WriteLine("Command not found");
                        break;
                }
            }
            return table;
        }

        public static int GetTime()
        {
            int number = 0;

            while (true)
            {
                Console.WriteLine("Write time:");
                try
                {
                    number = Convert.ToInt32(Console.ReadLine());
                    if(0 < number && number < 24)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Non format (0-23)");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Non format");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Non format");
                }
            }

            return number;
        }

        public static int GetCommant()
        {
            int number = 0;

            while (true)
            {
                try
                {
                    number = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Non format");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Non format");
                }
            }

            return number;
        }

        private static void ShowTimeTableMenu()
        {
            ConsoleColor color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("1 - SetFree | 2 - SetConsonant | 3 - SetTemp | 4 - Stop");
            Console.ForegroundColor = color;
        }
    }
}
