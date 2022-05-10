using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Clubs;
using Entities.TimeTables;

namespace Entities.Carts
{
    public class SpecialCart : Cart
    {
        

        public SpecialCart() : this(null, null) { }

        public SpecialCart(string location, TimeTable time) : base(time)
        {
            this.Location = location;
            if (Table != null)
            {
                Table.Cart = this;
                Table.Cart_Id = this.Id;
            }
        }

        public override bool CheckCart(Club club)
        {
            LocClub locClub = club as LocClub;
            return locClub.Location == Location;
        }

        public override string ToString()
        {
            return $"Special Cart [{Id}] location: {Location}";
        }
    }
}
