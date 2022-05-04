using Entities.Carts;
using Entities.TimeTables;
using Entities.Timers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Clubs
{
    public class LocClub : Club
    {
        public string Location { get; private set; }
        public string Name { get; private set; }

        public LocClub() : this(null, null, null) { }
        public LocClub(string name ,string location , ITimeTable table) : base(table)
        {
            Name = name;
            Location = location;
        }

        public override bool Visit(Cart cart)
        {
            int time = Timer.GetTime();
            if (!Table.IsTimeFree(time))
            {
                return false;
            }
            return cart.VisitClub(this, time);
        }

        public override Cart BuyClubCart(ITimeTable timeTable)
        {
            return new ClubCart(this, timeTable);
        }

        public override Cart BuySpecialCart(ITimeTable timeTable)
        {
            return new SpecialCart(Location, timeTable);
        }

        public override Cart SingUp(int time)
        {
            ITimeTable timeTable = new TimeTable();
            timeTable.SetTemporary(time);
            return new TempCart(this, timeTable);
        }

        public override bool SingUp(Cart cart, int time)
        {
            if (cart.CheckTime(time) || !cart.CheckCart(this))
            {
                return false;
            }
            cart.Table.SetTemporary(time);
            return true;
        }

        public override string ToString()
        {
            return $"Club {Name} [{Id}] Loc: {Location}";
        }
    }
}
