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
        static void ShowDb(Logic logic)
        {
            Console.WriteLine("Clubs:");
            foreach (var club in logic.Clubs.GetClubs())
            {
                Console.WriteLine(club);
            }
            Console.WriteLine("Carts:");
            foreach(var cart in logic.Carts.GetCarts())
            {
                Console.WriteLine(cart);
            }
        }
    }
}
