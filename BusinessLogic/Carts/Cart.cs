using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.TimeTables;
using BusinessLogic.Clubs;

namespace BusinessLogic.Carts
{
    public abstract class Cart
    {
        protected ITimeTable table;

        protected Cart(ITimeTable table)
        {
            this.table = table;
        }

        public abstract bool checkCart(Club club);
    }
}
