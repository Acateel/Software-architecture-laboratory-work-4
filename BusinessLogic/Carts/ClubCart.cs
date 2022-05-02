using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Clubs;
using BusinessLogic.TimeTables;

namespace BusinessLogic.Carts
{
    class ClubCart : Cart
    {
        private readonly Club club;

        public ClubCart(Club club, ITimeTable table) : base(table)
        {
            this.club = club;
        }

        public override bool CheckCart(Club club)
        {
            return this.club.Equals(club);
        }
    }
}
