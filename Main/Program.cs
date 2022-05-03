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

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            ClubsContext context = new ClubsContext();

            Club club = new LocClub("Default", "DefaultCity", new TimeTable());

            context.Clubs.Add(club);
            context.Carts.Add(club.BuyClubCart(new TimeTable()));

            ShowContext(context);
        }
        static void ShowContext(ClubsContext context)
        {
            Console.WriteLine("Carts:");
            foreach (var entity in context.Carts.Local)
            {
                Console.WriteLine(entity.ToString());
            }
            Console.WriteLine("Clubs:");
            foreach (var entity in context.Clubs.Local)
            {
                Console.WriteLine(entity.ToString());
            }
        }
    }
}
