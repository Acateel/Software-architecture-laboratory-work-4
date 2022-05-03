﻿using Entities.Clubs;
using Entities.TimeTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Carts
{
    class TempCart : ClubCart
    {
        public TempCart(Club club, ITimeTable table) : base(club, table)
        {
        }
    }
}
