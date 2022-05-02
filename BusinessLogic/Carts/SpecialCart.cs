using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Clubs;
using BusinessLogic.TimeTables;

namespace BusinessLogic.Carts
{
    class SpecialCart : Cart
    {
        private readonly string location;

        public SpecialCart(string location, ITimeTable time) : base(time)
        {
            this.location = location;
        }

        public override bool CheckCart(Club club)
        {
            LocClub locClub = club as LocClub;
            return locClub.Location == location;
        }
    }
}
