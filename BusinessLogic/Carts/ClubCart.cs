using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Clubs;
using Entities.TimeTables;

namespace Entities.Carts
{
    class ClubCart : Cart
    {
        protected readonly int clubId;

        public ClubCart() : this(null, null) { }

        public ClubCart(Club club, ITimeTable table) : base(table)
        {
            this.clubId = club.Id;
        }

        public override bool CheckCart(Club club)
        {
            return clubId == club.Id;
        }

        public override string ToString()
        {
            return $"Club Cart [{Id}] ClubId: {clubId}";
        }
    }
}
