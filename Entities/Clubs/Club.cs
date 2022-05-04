using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.TimeTables;
using Entities.Timers;
using Entities.Carts;

namespace Entities.Clubs
{
    public abstract class Club : Entity
    {
        public ITimeTable Table { get; set; }

        protected Club(ITimeTable table)
        {
            this.Table = table;
        }

        public void Visit()
        {
            throw new ClubException("Cannot visit club without cart");
        }
        public abstract bool Visit(Cart cart);
        public abstract Cart BuyClubCart(ITimeTable timeTable);
        public abstract Cart BuySpecialCart(ITimeTable timeTable);
        public abstract Cart SingUp(int time);
        public abstract bool SingUp(Cart cart, int time);
    }
}
