using BusinessLogic.Clubs;
using BusinessLogic.TimeTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Carts
{
    class TempCart : ClubCart
    {
        public TempCart(Club club, ITimeTable table) : base(club, table)
        {
        }
    }
}
