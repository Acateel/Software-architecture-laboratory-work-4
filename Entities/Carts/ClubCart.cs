using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Clubs;
using Entities.TimeTables;

namespace Entities.Carts
{
    public class ClubCart : Cart
    {
        

        public ClubCart() : this(null, null) { }

        public ClubCart(Club club, ITimeTable table) : base(table)
        {
            this.Club = club;
            if (club != null)
            {
                this.Club_Id = club.Id;
            }
            if (table != null)
            {
                table.Cart = this;
                table.Cart_Id = this.Id;
            }
        }

        public override bool CheckCart(Club club)
        {
            return this.Club.Equals(club);
        }

        public override string ToString()
        {
            return $"Club Cart [{Id}] ClubId: {Club.Id}";
        }
    }
}
