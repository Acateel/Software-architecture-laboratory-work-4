﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.TimeTables;
using Entities.Clubs;

namespace Entities.Carts
{
    public abstract class Cart : Entity
    {
        public int Table_Id { get; set; }
        public TimeTable Table { get; set; }
        public int Club_Id { get; set; }
        public Club Club { get; set; }
        public string Location { get; set; }

        protected Cart(TimeTable table)
        {
            this.Table = table;
            if (Table != null)
            {
                this.Table_Id = Table.Id;
            }
        }

        public abstract bool CheckCart(Club club);

        public bool CheckTime(int time)
        {
            return !Table.IsTimeFree(time);
        }

        public bool VisitClub(Club club, int time)
        {
            if(CheckCart(club) && CheckTime(time))
            {
                ResetTemporaty(time);
                return true;
            }
            return false;
        }

        private void ResetTemporaty(int time)
        {
            if (Table.IsTimeTemporary(time))
            {
                Table.SetFree(time);
            }
        }
    }
}
