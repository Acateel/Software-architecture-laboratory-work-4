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
            using(var context = new ClubsContext())
            {
                var quare = context.Clubs.AsQueryable<Club>();
                foreach(var entity in quare)
                {
                    Console.WriteLine(entity.ToString());
                }
            }
        }
    }
}
