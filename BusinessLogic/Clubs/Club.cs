﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.TimeTables;
using BusinessLogic.Timer;
using BusinessLogic.Carts;

namespace BusinessLogic.Clubs
{
    public abstract class Club
    {
        protected ITimeTable table;

        protected Club(ITimeTable table)
        {
            this.table = table;
        }

        public void Visit()
        {
            throw new ClubException("Cannot visit club without cart");
        }
        public abstract bool Visit(Cart cart);
        public abstract Cart BuyClubCart();
        public abstract Cart BuySpecialCart();
        public abstract Cart SingUp();
        public abstract bool SingUp(Cart cart);
    }
}
