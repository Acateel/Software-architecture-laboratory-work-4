﻿using System;
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

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            IUnitOfWork unitOfWork = new UnitOfWork.UnitOfWorks.Services.UnitOfWork();
            Logic logic = new Logic(unitOfWork);
            TimeTable table = new TimeTable();
            table.SetConsonant(10, 20);

            logic.Clubs.CreateClub(new LocClub("Nox", "Rivne", table));
            logic.Clubs.CreateClub(new LocClub("SportO", "Odesa", new TimeTable()));
            logic.Clubs.CreateClub(new LocClub("ClubHundred", "Rivne", new TimeTable()));

            logic.Clubs.SetClub(1);
            logic.Club.BuyClubCart(table);
            logic.Club.BuySpecialCart(new TimeTable());

            ShowDb(logic);
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
