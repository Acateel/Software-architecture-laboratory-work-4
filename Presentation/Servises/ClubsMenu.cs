using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using Presentation.Interfaces;
using Entities.Clubs;
using Entities.TimeTables;

namespace Presentation.Servises
{
    class ClubsMenu : IClubsMenu
    {
        private readonly Logic logic;
        private readonly ICartMenu cartMenu;
        private readonly IClubMenu clubMenu;

        public ClubsMenu(Logic logic)
        {
            this.logic = logic;
            cartMenu = new CartMenu(logic);
            clubMenu = new ClubMenu(logic);
        }

        public void CartMenu()
        {
            cartMenu.Start();
        }

        public void CreateClub()
        {
            Console.WriteLine("Create Club:");

            string name = InputHelper.GetName();

            string location = InputHelper.GetLocation();

            TimeTable table = InputHelper.GetTimeTable();

            LocClub club = new LocClub(name, location, table);

            logic.Clubs.CreateClub(club);

            Console.WriteLine(club + " added");
        }

        public void DeleteClub()
        {
            Console.WriteLine("Delete club id:");
            int number = InputHelper.GetCommant();
            logic.Clubs.DeleteClub(number);
        }

        public void GetClubs()
        {
            foreach(var club in logic.Clubs.GetClubs())
            {
                Console.WriteLine(club);
            }
        }

        public void SetClub()
        {
            Console.WriteLine("Club id:");
            int id = InputHelper.GetCommant();
            logic.Clubs.SetClub(id);
            clubMenu.Start();
        }

        public void SetTime()
        {
            int time = InputHelper.GetTime();
            Entities.Timers.ClasicTimer.setTime(time);
        }

        public void ShowMenu()
        {
            ConsoleColor color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Time: " + Entities.Timers.Timer.GetTime());
            Console.WriteLine("1 - CartMenu | 2 - CreateClub | 3 - DeleteClub | 4 - SetClub | 5 - SetTime | 6 - Stop");
            Console.ForegroundColor = color;
        }

        public void Start()
        {
            bool running = true;
            while (running)
            {
                GetClubs();
                ShowMenu();
                int command = InputHelper.GetCommant();
                switch (command)
                {
                    case 1:
                        CartMenu();
                        break;
                    case 2:
                        CreateClub();
                        break;
                    case 3:
                        DeleteClub();
                        break;
                    case 4:
                        SetClub();
                        break;
                    case 5:
                        SetTime();
                        break;
                    case 6:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Command not found");
                        break;
                }
            }
        }
    }
}
