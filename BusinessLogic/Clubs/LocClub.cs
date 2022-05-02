using BusinessLogic.Carts;
using BusinessLogic.TimeTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Clubs
{
    class LocClub : Club
    {
        public string Location { get; private set; }
        public string Name { get; private set; }
        public LocClub(string name ,string location , ITimeTable table) : base(table)
        {
            Name = name;
            Location = location;
        }

        public override bool Visit(Cart cart)
        {
            throw new NotImplementedException();
        }

        public override Cart BuyClubCart()
        {
            throw new NotImplementedException();
        }

        public override Cart BuySpecialCart()
        {
            throw new NotImplementedException();
        }

        public override Cart SingUp()
        {
            throw new NotImplementedException();
        }

        public override bool SingUp(Cart cart)
        {
            throw new NotImplementedException();
        }
    }
}
