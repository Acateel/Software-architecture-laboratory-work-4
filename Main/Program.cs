using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.TimeTables;
using Entities.Clubs;
using Entities.Carts;
using Entities;
using System.Data.Entity;
using UnitOfWork;
using UnitOfWork.Interfaces;
using UnitOfWork.UnitOfWorks.Interfaces;
using UnitOfWork.UnitOfWorks.Services;
using BusinessLogic;
using Presentation;
using Presentation.Servises;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            IUnitOfWork unitOfWork = new UnitOfWork.UnitOfWorks.Services.UnitOfWork();
            Logic logic = new Logic(unitOfWork);

            MainMenu.Start(logic);
        }
        static void Testing()
        {
            ClubsContext context = new ClubsContext();
            //GetTestData(context);

            foreach(var club in context.Clubs.Include("Table"))
            {
                InputHelper.ShowTimeTable(club.Table);
            }

            Console.ReadLine();
        }
        private static void GetTestData(ClubsContext context)
        {
            TimeTable time1 = new TimeTable();
            time1.SetConsonant(1);
            Club club1 = new LocClub("Sport", "Rivne", time1);
            TimeTable time2 = new TimeTable();
            time2.SetConsonant(2);
            Club club2 = new LocClub("Nox", "Rivne", time2);
            TimeTable time3 = new TimeTable();
            time3.SetConsonant(3);
            Club club3 = new LocClub("Odo", "Odesa", time3);
            context.Clubs.Add(club1);
            context.Clubs.Add(club2);
            context.Clubs.Add(club3);

            context.TimeTables.Add(time1);
            context.TimeTables.Add(time2);
            context.TimeTables.Add(time3);
            context.SaveChanges();
        }
    }
}
