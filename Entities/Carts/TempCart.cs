using Entities.Clubs;
using Entities.TimeTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Carts
{
    public class TempCart : ClubCart
    {
        public TempCart() : this(null, null) { }
        public TempCart(Club club, ITimeTable table) : base(club, table)
        {
        }

        public override string ToString()
        {
            return $"Temp Cart [{Id}] ClubId: {Club.Id}";
        }
    }
}
