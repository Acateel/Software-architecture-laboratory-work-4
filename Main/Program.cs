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

namespace Main
{
    class Program
    {
        static IUnitOfWork unitOfWork = new UnitOfWork.UnitOfWorks.Services.UnitOfWork();
        static void Main(string[] args)
        {
            ShowClubs();
        }
        static void DeleteClub(int id)
        {
            unitOfWork.GetClubRepository().Delete(id);
            unitOfWork.Save();
        }
        static void ShowClubs()
        {
            Console.WriteLine("Clubs:");
            foreach(var club in unitOfWork.GetClubRepository().GetAll())
            {
                Console.WriteLine(club.ToString());
            }
        }
    }
}
