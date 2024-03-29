﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Clubs;
using Entities.Carts;
using Entities.TimeTables;

namespace BusinessLogic.Interfaces
{
    public interface IClubLogic
    {
        Club Club { get; set; }
        string GetClubInfo();
        void ChangeInfo(Club club);
        bool VisitClub();
        bool VisitClub(Cart cart);

        Cart BuyClubCart(TimeTable timeTable);
        Cart BuySpecialCart(TimeTable timeTable);

        Cart SingUp(int time);
        bool SingUp(Cart cart, int time);
    }
}
